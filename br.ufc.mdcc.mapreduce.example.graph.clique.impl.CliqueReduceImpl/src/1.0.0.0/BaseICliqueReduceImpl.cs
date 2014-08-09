/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.mapreduce.example.graph.clique.CliqueNode;
using br.ufc.mdcc.mapreduce.example.graph.clique.CliqueReduce;

namespace br.ufc.mdcc.mapreduce.example.graph.clique.impl.CliqueReduceImpl { 
	public abstract class BaseICliqueReduceImpl: Computation, BaseICliqueReduce{

		private IKVPair<IString, IIterator<ICliqueNode>> input_values = null;
		public IKVPair<IString, IIterator<ICliqueNode>> Input_values {
			get {
				if (this.input_values == null)
					this.input_values = (IKVPair<IString, IIterator<ICliqueNode>>) Services.getPort("input_values");
				return this.input_values;
			}
		}

		private IKVPair<IString, ICliqueNode> output_value = null;
		public IKVPair<IString, ICliqueNode> Output_value {
			get {
				if (this.output_value == null)
					this.output_value = (IKVPair<IString, ICliqueNode>) Services.getPort("output_value");
				return this.output_value;
			}
		}
		// BaseIReduceFunction<OMK, OMV, ORV>:
		//	  IKVPair<OMK,IIterator<OMV>> Input_values {get;}
		//    ORV Output_value {get;}
	}
}
