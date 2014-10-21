using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.example.graph.sssp.fast.PathFlowCombineFunction;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using System.Diagnostics;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.mapreduce.example.graph.sssp.fast.PathInfo;

namespace br.ufc.mdcc.mapreduce.example.graph.sssp.fast.impl.PathFlowCombineFunctionImpl { 

	public class IPathFlowCombineFunctionImpl<ORV, Out> : BaseIPathFlowCombineFunctionImpl<ORV, Out>, IPathFlowCombineFunction<ORV, Out>
			where ORV: IKVPair<IInteger, IIterator<IPathInfo>>
			where Out: IKVPair<IInteger, IIterator<IPathInfo>>
	{	
		public override void main() 
		{ 
			Trace.WriteLine (Rank + ": START COMBINE FUNCTION #1");
			IIteratorInstance<ORV> input_data_instance = (IIteratorInstance<ORV>) Input_data.Instance;
			IKVPairInstance<IInteger, IIterator<IPathInfo>> output_data_instance = (IKVPairInstance<IInteger, IIterator<IPathInfo>>) Output_data.Instance;

			Trace.WriteLine (Rank + ": START COMBINE FUNCTION #2");
			IIntegerInstance done_flag = (IIntegerInstance) output_data_instance.Key;
			IIteratorInstance<IPathInfo> output_distances =	(IIteratorInstance<IPathInfo>) output_data_instance.Value;

			Trace.WriteLine (Rank + ": START COMBINE FUNCTION #3");
			bool done = true;		
			object o;

			while (input_data_instance.fetch_next (out o)) 
			{
				IKVPairInstance<IInteger, IIterator<IPathInfo>> kv = (IKVPairInstance<IInteger, IIterator<IPathInfo>>)o;
				IIntegerInstance k = (IIntegerInstance)kv.Key;

				Trace.WriteLine (Rank + ": LOOP #1 COMBINE FUNCTION " + k.Value);

				output_distances.putAll ((IIteratorInstance<IPathInfo>)kv.Value);

	            done = done && k.Value == 1;
			}

			output_distances.finish ();

			done_flag.Value = done ? 1 : 0;
			Trace.WriteLine (Rank + ": END COMBINE FUNCTION " + done);

		}

	}

}
