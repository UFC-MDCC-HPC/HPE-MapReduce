/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.Double;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.VoteReduce;

namespace br.ufc.mdcc.mapreduce.example.graph.pagerank.impl.VoteReduceImpl { 
	public abstract class BaseIVoteReduceImpl: Computation, BaseIVoteReduce{

		private IKVPair<IInteger, IDouble> output_value = null;
		public IKVPair<IInteger, IDouble> Output_value {
			get {
				if (this.output_value == null)
					this.output_value = (IKVPair<IInteger, IDouble>) Services.getPort("output_value");
				return this.output_value;
			}
		}

		private IKVPair<IInteger,IIterator<IDouble>> input_values = null;
		public IKVPair<IInteger,IIterator<IDouble>> Input_values {
			get {
				if (this.input_values == null)
					this.input_values = (IKVPair<IInteger,IIterator<IDouble>> ) Services.getPort("input_values");
				return this.input_values;
			}
		}
	}
}
