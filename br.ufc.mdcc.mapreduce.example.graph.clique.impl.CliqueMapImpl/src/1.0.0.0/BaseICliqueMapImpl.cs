using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.mapreduce.example.graph.clique.CliqueNode;
using br.ufc.mdcc.mapreduce.example.graph.clique.CliqueMap;

namespace br.ufc.mdcc.mapreduce.example.graph.clique.impl.CliqueMapImpl { 

	public abstract class BaseICliqueMapImpl: Computation, BaseICliqueMap{

		private IIterator<IKVPair<IString, ICliqueNode>> output_data = null;
		public IIterator<IKVPair<IString, ICliqueNode>> Output_data {
			get {
				if (this.output_data == null)
					this.output_data = (IIterator<IKVPair<IString, ICliqueNode>>) Services.getPort("output_data");
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

		private ICliqueNode input_value = null;
		public ICliqueNode Input_value {
			get {
				if (this.input_value == null)
					this.input_value = (ICliqueNode) Services.getPort("input_value");
				return this.input_value;
			}
		}
	}
}
