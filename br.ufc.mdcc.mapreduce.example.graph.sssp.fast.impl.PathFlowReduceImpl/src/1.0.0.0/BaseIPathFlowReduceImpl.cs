/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.mapreduce.example.graph.sssp.fast.PathFlowReduce;
//using br.ufc.mdcc.mapreduce.example.graph.sssp.fast.DataPath;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.mapreduce.example.graph.sssp.fast.PathInfo;

namespace br.ufc.mdcc.mapreduce.example.graph.sssp.fast.impl.PathFlowReduceImpl { 

	public abstract class BaseIPathFlowReduceImpl: Computation, BaseIPathFlowReduce{

		private IKVPair<IInteger, IIterator<IPathInfo>> input_values = null;
		public IKVPair<IInteger, IIterator<IPathInfo>>  Input_values {
			get {
				if (this.input_values == null)
					this.input_values = (IKVPair<IInteger, IIterator<IPathInfo>> ) Services.getPort("input_values");
				return this.input_values;
			}
		}

		private IKVPair<IInteger, IIterator<IPathInfo>> output_value = null;
		public IKVPair<IInteger, IIterator<IPathInfo>> Output_value {
			get {
				if (this.output_value == null)
					this.output_value = (IKVPair<IInteger, IIterator<IPathInfo>>) Services.getPort("output_value");
				return this.output_value;
			}
		}

	}
}
