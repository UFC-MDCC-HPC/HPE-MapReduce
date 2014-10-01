/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.mapreduce.example.graph.bsp.sssp.PathBspCombineFunction;

namespace br.ufc.mdcc.mapreduce.example.graph.bsp.sssp.impl.PathBspCombineFunctionImpl { 

public abstract class BaseIPathBspCombineFunctionImpl<ORV, Out>: Computation, BaseIPathBspCombineFunction<ORV, Out>
		where ORV: IKVPair<IString, IString>
		where Out: IString
{

private Out output_data = default(Out);

public Out Output_data {
	get {
		if (this.output_data == null)
			this.output_data = (Out) Services.getPort("output_data");
		return this.output_data;
	}
}

private IIterator<ORV> input_data = null;

public IIterator<ORV> Input_data {
	get {
		if (this.input_data == null)
			this.input_data = (IIterator<ORV>) Services.getPort("input_data");
		return this.input_data;
	}
}

}

}
