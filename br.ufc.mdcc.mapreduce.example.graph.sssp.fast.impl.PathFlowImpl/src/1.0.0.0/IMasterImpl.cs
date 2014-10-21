using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.example.graph.sssp.fast.PathFlow;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.String;
using System.Collections.Generic;
using System.Diagnostics;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.mapreduce.example.graph.sssp.fast.PathInfo;
using br.ufc.mdcc.common.KVPair;

namespace br.ufc.mdcc.mapreduce.example.graph.sssp.fast.impl.PathFlowImpl { 

	public class IMasterImpl<PLATFORM> : BaseIMasterImpl<PLATFORM>, IMaster<PLATFORM>
	where PLATFORM:IPlatform
	{
		public override void main() 
		{ 
			int done = 0;
			IStringInstance input_data_instance = (IStringInstance)Input_data.Instance;
			IStringInstance output_data_instance = (IStringInstance)Output_data.Instance;
			IIteratorInstance<IPathInfo> initial_data_instance = (IIteratorInstance<IPathInfo>) Initial_data.Instance;
			IKVPairInstance<IInteger,IIterator<IPathInfo>> final_distances_instance = (IKVPairInstance<IInteger,IIterator<IPathInfo>>) Final_distances.Instance;
			IIntegerInstance termination_flag = (IIntegerInstance) Termination_flag.Instance;

			string setE = input_data_instance.Value;
			string setV = "1 c 0" + System.Environment.NewLine;
			IDictionary<int,int> vertices = new Dictionary<int,int>();
			foreach (string edge in setE.Split(System.Environment.NewLine.ToCharArray())) 
			{
				if (edge.Length > 0) 
				{
					int vertex = edge [0];
					if (!vertices.ContainsKey (vertex)) 
					{
						setV += edge [0] + " d " + int.MaxValue + System.Environment.NewLine;
						vertices.Add (vertex, vertex);
					}
				}
			}

			feedInitialData (setV + System.Environment.NewLine + setE, initial_data_instance);

			int count = 0;
			while (done == 0) 
			{
				Console.WriteLine (Rank + ": ITERATION PATH_FLOW FAST GO ! - " + (++count));

				this.Path_flow.go ();

				done = ((IIntegerInstance)final_distances_instance.Key).Value;

				termination_flag.Value = done;
				Set_termination_flag.go ();

				if (done == 0) 
				{
					Trace.WriteLine (Rank + ": Exchange #1");
					initial_data_instance.putAll ((IIteratorInstance<IPathInfo>)final_distances_instance.Value);
					initial_data_instance.finish ();
					Trace.WriteLine (Rank + ": Exchange #2");
				}
			}

			outputFinalDistances((IIteratorInstance<IPathInfo>)final_distances_instance.Value, output_data_instance);
		
			Trace.WriteLine (Rank + ": --- FINISH PATH_FLOW.GO !");
		}

		void feedInitialData (string setE, IIteratorInstance<IPathInfo> initial_data_instance)
		{
			string[] lines = setE.Split(new char[] {System.Environment.NewLine[0]});

			foreach (string line in lines) 
			{
				if (!line.Trim().Equals ("")) {
					Trace.WriteLine(Rank + ": LINE = " + line);
					string[] edge_info_items = line.Split (' ');
					IPathInfoInstance edge = (IPathInfoInstance)Initial_data.createItem ();
					char item_type = edge_info_items [1] [0];
					switch (item_type) 
					{
					case 'c':
						DistanceInfo dist_instance_c = new DistanceInfo ();
						dist_instance_c.info_type = Info.PATH_INFO_TYPE_DISTANCE_TRIAL;
						dist_instance_c.vertex = int.Parse (edge_info_items [0]);
						dist_instance_c.distance = int.Parse (edge_info_items [2]);						
						edge.Value = dist_instance_c;
						Trace.WriteLine (Rank + ": c " + dist_instance_c.info_type + " " + dist_instance_c.vertex + " " + dist_instance_c.distance);
						break;
					case 'd':
						DistanceInfo dist_instance_d = new DistanceInfo ();
						dist_instance_d.info_type = Info.PATH_INFO_TYPE_DISTANCE_TRIAL;
						dist_instance_d.vertex = int.Parse (edge_info_items [0]);
						dist_instance_d.distance = int.Parse (edge_info_items [2]);	
						edge.Value = dist_instance_d;
						Trace.WriteLine (Rank + ": d " + dist_instance_d.info_type + " " + dist_instance_d.vertex + " " + dist_instance_d.distance);
						break;
					default:
						EdgeInfo edge_info = new EdgeInfo ();
						edge_info.info_type = Info.PATH_INFO_TYPE_EDGE;
						edge_info.vertex = int.Parse(edge_info_items[0]);
						edge_info.vertex_other = int.Parse(edge_info_items[1]);
						edge_info.weight = int.Parse(edge_info_items[2]);
						edge.Value = edge_info;
						Trace.WriteLine (Rank + ": edge " + edge_info.info_type + " " + edge_info.vertex + " " + edge_info.vertex_other + " " + edge_info.weight);
						break;
					}
					initial_data_instance.put (edge);
				}
			}
			initial_data_instance.finish ();
		}

		void outputFinalDistances (IIteratorInstance<IPathInfo> final_distances_instance, IStringInstance output_data_instance)
		{
			string output_string = "";
			object o;
			while (final_distances_instance.fetch_next(out o))
			{
				IPathInfoInstance path_info = (IPathInfoInstance) o;
				DistanceInfo distance_info = (DistanceInfo) path_info.Value;
				if (distance_info.info_type.Equals(Info.PATH_INFO_TYPE_DISTANCE_PARTIAL)) {
					Console.WriteLine ("OUTPUT : " + path_info.Value);
					output_string += distance_info.vertex + " d " + distance_info.distance + System.Environment.NewLine;
				}
				else
					throw new Exception ("PathFlowImpl.IMasterImpl.outputFinalDistances: something goes wrong when reading output distances (unexpected result : " + distance_info + ")" 
					                     + distance_info.info_type + " --- " + Info.PATH_INFO_TYPE_DISTANCE_PARTIAL);
			}

			output_data_instance.Value = output_string;
		}
	}

}
