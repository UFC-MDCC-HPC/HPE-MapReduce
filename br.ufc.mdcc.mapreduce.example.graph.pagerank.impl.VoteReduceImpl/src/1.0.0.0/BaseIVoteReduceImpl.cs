/* Automatically Generated Code */

using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
//using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.common.Double;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.VoteReduce;

namespace br.ufc.mdcc.mapreduce.example.graph.pagerank.impl.VoteReduceImpl { 
	public abstract class BaseIVoteReduceImpl: Computation, BaseIVoteReduce{

		private IKVPair<IString, IDouble> output_value = null;
		public IKVPair<IString, IDouble> Output_value {
			get {
				if (this.output_value == null)
					this.output_value = (IKVPair<IString, IDouble>) Services.getPort("output_value");
				return this.output_value;
			}
		}

		private IKVPair<IString,IIterator<IDouble>> input_values = null;
		public IKVPair<IString,IIterator<IDouble>> Input_values {
			get {
				if (this.input_values == null)
					this.input_values = (IKVPair<IString,IIterator<IDouble>> ) Services.getPort("input_values");
				return this.input_values;
			}
		}
	}
}
