using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.mapreduce.example.graph.clique.CliqueNode;
using br.ufc.mdcc.mapreduce.example.graph.clique.CliqueMap;

namespace br.ufc.mdcc.mapreduce.example.graph.clique.impl.CliqueMapImpl { 

	public abstract class BaseICliqueMapImpl: Computation, BaseICliqueMap{

		private IIterator<IKVPair<IInteger, IKVPair<IInteger, IIterator<IInteger>>>> output_data = null;
		public IIterator<IKVPair<IInteger, IKVPair<IInteger, IIterator<IInteger>>>> Output_data {
			get {
				if (this.output_data == null)
					this.output_data = (IIterator<IKVPair<IInteger, IKVPair<IInteger, IIterator<IInteger>>>>) Services.getPort("output_data");
				return this.output_data;
			}
		}

		private IInteger input_key = null;
		public IInteger Input_key {
			get {
				if (this.input_key == null)
					this.input_key = (IInteger) Services.getPort("input_key");
				return this.input_key;
			}
		}

		private ICliqueNode<IInteger> input_value = null;
		public ICliqueNode<IInteger> Input_value {
			get {
				if (this.input_value == null)
					this.input_value = (ICliqueNode<IInteger>) Services.getPort("input_value");
				return this.input_value;
			}
		}
	}
}
