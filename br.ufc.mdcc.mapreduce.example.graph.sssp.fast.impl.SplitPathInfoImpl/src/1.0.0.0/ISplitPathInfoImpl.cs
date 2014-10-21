using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.example.graph.sssp.fast.SplitPathInfo;
using br.ufc.mdcc.mapreduce.user.SplitFunction;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.mapreduce.example.graph.sssp.fast.PathInfo;
using br.ufc.mdcc.common.Integer;
using System.Diagnostics;
using br.ufc.mdcc.common.KVPair;

namespace br.ufc.mdcc.mapreduce.example.graph.sssp.fast.impl.SplitPathInfoImpl 
{ 

	public class ISplitPathInfoImpl : BaseISplitPathInfoImpl, ISplitPathInfo
	{

		public override void main() 
		{ 
			Trace.WriteLine (Rank + ": START SPLIT PATH INFO 1");

			IIteratorInstance<IPathInfo> input_data_instance =  (IIteratorInstance<IPathInfo>) Input_data.Instance;
			IIteratorInstance<IKVPair<IInteger,IPathInfo>> output_data_instance = (IIteratorInstance<IKVPair<IInteger,IPathInfo>>) Output_data.Instance;

			Trace.WriteLine (Rank + ": START SPLIT PATH INFO 2");

			object path_info;
			while (input_data_instance.fetch_next(out path_info))
		    {
				Trace.WriteLine (Rank + ": LOOP SPLIT PATH INFO " + path_info.GetType());
				IPathInfoInstance path_info_instance = (IPathInfoInstance)path_info;
				IKVPairInstance<IInteger,IPathInfo> path_info_output = (IKVPairInstance<IInteger,IPathInfo>)Output_data.createItem ();


				((IIntegerInstance)path_info_output.Key).Value = ((Info)path_info_instance.Value).vertex;
				path_info_output.Value = path_info_instance;
				Trace.WriteLine (Rank + ": vertex = " + path_info_output.Key);
				output_data_instance.put(path_info_output);
			}

			output_data_instance.finish();

			Trace.Write (Rank + ": STOP SPLIT PATH INFO ");

		}

	}

}
