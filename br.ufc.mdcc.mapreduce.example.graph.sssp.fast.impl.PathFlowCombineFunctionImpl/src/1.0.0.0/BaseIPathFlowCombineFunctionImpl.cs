/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.mapreduce.example.graph.sssp.fast.PathFlowCombineFunction;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.mapreduce.example.graph.sssp.fast.PathInfo;

namespace br.ufc.mdcc.mapreduce.example.graph.sssp.fast.impl.PathFlowCombineFunctionImpl { 

public abstract class BaseIPathFlowCombineFunctionImpl<ORV, Out>: Computation, BaseIPathFlowCombineFunction<ORV, Out>
		where ORV: IKVPair<IInteger, IIterator<IPathInfo>>
		where Out: IKVPair<IInteger, IIterator<IPathInfo>>
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
