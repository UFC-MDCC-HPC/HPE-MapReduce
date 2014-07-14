/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.mapreduce.example.graph.clique.CliqueNode;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.mapreduce.example.graph.clique.BreakInCliqueNodes;

namespace br.ufc.mdcc.mapreduce.example.graph.clique.impl.BreakInCliqueNodesImpl { 

	public abstract class BaseIBreakInCliqueNodesImpl: Computation, BaseIBreakInCliqueNodes{

		private IString input_data = null;
		public IString Input_data {
			get {
				if (this.input_data == null)
					this.input_data = (IString) Services.getPort("input_data");
				return this.input_data;
			}
		}

		private IIterator<IKVPair<IInteger, ICliqueNode<IInteger>>> output_data = null;
		public IIterator<IKVPair<IInteger, ICliqueNode<IInteger>>> Output_data {
			get {
				if (this.output_data == null)
					this.output_data = (IIterator<IKVPair<IInteger, ICliqueNode<IInteger>>>) Services.getPort("output_data");
				return this.output_data;
			}
		}
	}
}
