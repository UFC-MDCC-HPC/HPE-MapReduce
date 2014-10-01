using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.example.graph.bsp.sssp.PathBspCombineFunction;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.String;
using System.Diagnostics;

namespace br.ufc.mdcc.mapreduce.example.graph.bsp.sssp.impl.PathBspCombineFunctionImpl { 

public class IPathBspCombineFunctionImpl<ORV, Out> : BaseIPathBspCombineFunctionImpl<ORV, Out>, IPathBspCombineFunction<ORV, Out>
		where ORV: IKVPair<IString, IString>
			where Out: IString
{	
	public override void main() 
	{ 
		IIteratorInstance<ORV> input_data_instance = (IIteratorInstance<ORV>) Input_data.Instance;
		IStringInstance output_data_instance = (IStringInstance) Output_data.Instance;

	    string setV = "";
		bool done = true;		
		object o;

		while (input_data_instance.fetch_next (out o)) 
		{
			IKVPairInstance<IString, IString> kv = (IKVPairInstance<IString, IString>)o;
			IStringInstance k = (IStringInstance)kv.Key;
			IStringInstance v = (IStringInstance)kv.Value;
			//Trace.WriteLine (Rank + ": COMBINE FUNCTION - done:" + k.Value + " {" + System.Environment.NewLine + v.Value + "}");
			setV = setV + v.Value;// + System.Environment.NewLine;

            done = done && k.Value.Equals ("1");
		}

		output_data_instance.Value = setV + done;

	}

}

}
