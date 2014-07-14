/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.example.graph.clique.CliqueReduce;

namespace br.ufc.mdcc.mapreduce.example.graph.clique.impl.CliqueReduceImpl { 
	public abstract class BaseICliqueReduceImpl: Computation, BaseICliqueReduce{

		private IKVPair<IInteger, IIterator<IKVPair<IInteger, IIterator<IInteger>>>> input_values = null;
		public IKVPair<IInteger, IIterator<IKVPair<IInteger, IIterator<IInteger>>>> Input_values {
			get {
				if (this.input_values == null)
					this.input_values = (IKVPair<IInteger, IIterator<IKVPair<IInteger, IIterator<IInteger>>>>) Services.getPort("input_values");
				return this.input_values;
			}
		}

		private IKVPair<IInteger, IIterator<IKVPair<IInteger, IIterator<IInteger>>>> output_value = null;
		public IKVPair<IInteger, IIterator<IKVPair<IInteger, IIterator<IInteger>>>> Output_value {
			get {
				if (this.output_value == null)
					this.output_value = (IKVPair<IInteger, IIterator<IKVPair<IInteger, IIterator<IInteger>>>>) Services.getPort("output_value");
				return this.output_value;
			}
		}

		private IIterator<IKVPair<IInteger, IIterator<IInteger>>> orv_value_factory = null;
		protected IIterator<IKVPair<IInteger, IIterator<IInteger>>> Orv_value_factory {
			get {
				if (this.orv_value_factory == null)
					this.orv_value_factory = (IIterator<IKVPair<IInteger, IIterator<IInteger>>>) Services.getPort("orv_value_factory");
				return this.orv_value_factory;
			}
		}
	}
}
