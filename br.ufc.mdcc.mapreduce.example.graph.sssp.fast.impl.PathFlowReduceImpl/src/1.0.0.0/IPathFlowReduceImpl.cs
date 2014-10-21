using System;
using System.Collections.Generic;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.example.graph.sssp.fast.PathFlowReduce;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.mapreduce.example.graph.sssp.fast.PathInfo;
using System.Diagnostics;

namespace br.ufc.mdcc.mapreduce.example.graph.sssp.fast.impl.PathFlowReduceImpl { 

	public class IPathFlowReduceImpl : BaseIPathFlowReduceImpl, IPathFlowReduce
	{
		IDictionary<int,IDictionary<int, int>> neighbours = new Dictionary<int, IDictionary<int,int>> ();

		public IPathFlowReduceImpl() { } 

		#region IPathFlowReduce implementation

		public void clearNeighbours ()
		{
			neighbours.Clear ();
		}

		#endregion

		public override void main() 
		{ 
			int di = int.MaxValue;
			int dmin = int.MaxValue;
			int done = 1;

			Trace.WriteLine (Rank + ": START REDUCE FUNCTION");

			IKVPairInstance<IInteger, IIterator<IPathInfo>> input_instance = (IKVPairInstance<IInteger, IIterator<IPathInfo>>)Input_values.Instance;
			IIntegerInstance k = (IIntegerInstance)input_instance.Key;
			IIteratorInstance<IPathInfo> v = (IIteratorInstance<IPathInfo>)input_instance.Value;

			int k_int = k.Value;
			if (!neighbours.ContainsKey (k_int))
				neighbours [k_int] = new Dictionary<int,int> ();

			object o;
			while (v.fetch_next (out o)) 
			{

				IPathInfoInstance item = (IPathInfoInstance) o;
				Info item_info = (Info) item.Value;

				Trace.WriteLine (Rank + ": REDUCE FUNCTION LOOP " + item_info);

				switch (item_info.info_type)
				{
					case Info.PATH_INFO_TYPE_DISTANCE_TRIAL:
						DistanceInfo distance_item_info_1 = (DistanceInfo)item_info;
						int tmp = distance_item_info_1.distance;
						dmin = (int) min (dmin, tmp);
						break;
					case Info.PATH_INFO_TYPE_DISTANCE_PARTIAL:
						DistanceInfo distance_item_info_2 = (DistanceInfo)item_info;
						di = distance_item_info_2.distance;
						break;
					case Info.PATH_INFO_TYPE_EDGE:
						EdgeInfo edge_item_info = (EdgeInfo)item_info;
						IDictionary<int, int> output_neibours = neighbours[k_int];
						int n = edge_item_info.vertex_other;
						int d = 0;
						if (!output_neibours.TryGetValue (n, out d))
							output_neibours[n] = edge_item_info.weight;
						else 
							if (edge_item_info.weight < d) 
								output_neibours[n] = edge_item_info.weight;
						break;
				}

			}

			Trace.WriteLine (Rank + ": REDUCE FUNCTION AFTER LOOP #1 ");

			IKVPairInstance<IInteger, IIterator<IPathInfo>> orv = (IKVPairInstance<IInteger, IIterator<IPathInfo>>) Output_value.newInstance();
			IIteratorInstance<IPathInfo> buffer = (IIteratorInstance<IPathInfo>) orv.Value;

			Trace.WriteLine (Rank + ": REDUCE FUNCTION OUT LOOP #2 ");

			//IPathInfo path_info = buffer.createItem();

			dmin = (int) min (dmin,di);
			if(dmin != di)
			{
				foreach (KeyValuePair<int, int> kv in neighbours[k_int])
				{
					//IPathInfoInstance path_info_instance = (IPathInfoInstance) path_info.newInstance ();
					IPathInfoInstance path_info_instance = (IPathInfoInstance) 	buffer.createItem ();
					DistanceInfo distance_info = new DistanceInfo();
					distance_info.info_type = Info.PATH_INFO_TYPE_DISTANCE_TRIAL;
					distance_info.vertex = kv.Key;
					distance_info.distance = kv.Value + dmin;
					path_info_instance.Value = distance_info;
					buffer.put (path_info_instance);
					Trace.WriteLine (Rank + ": REDUCE FUNCTION OTHER LOOP " + distance_info);
				}
				done = 0;
			}

			((IIntegerInstance)orv.Key).Value = done;


			IPathInfoInstance path_info_instance_2 = (IPathInfoInstance) buffer.createItem ();
			DistanceInfo distance_info_2 = new DistanceInfo();
			distance_info_2.info_type = Info.PATH_INFO_TYPE_DISTANCE_PARTIAL;
			distance_info_2.vertex = k.Value;
			distance_info_2.distance = dmin;
			path_info_instance_2.Value = distance_info_2;
			buffer.put (path_info_instance_2);

			Trace.WriteLine (Rank + ": REDUCE FUNCTION OTHER LOOP OUT " + distance_info_2);

			buffer.finish ();

			Trace.WriteLine (Rank + ": FINISH REDUCE FUNCTION");

		}

		public int min (int d1, int d2)
		{
			return d1 < d2 ? d1 : d2;
		}
	}
}
