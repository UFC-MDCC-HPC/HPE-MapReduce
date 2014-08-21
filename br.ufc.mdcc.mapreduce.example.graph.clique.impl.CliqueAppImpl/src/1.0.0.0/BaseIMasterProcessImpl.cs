/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.example.graph.clique.Clique;
using br.ufc.mdcc.mapreduce.example.graph.clique.CliqueApp;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.mapreduce.example.graph.clique.CliqueNode;

namespace br.ufc.mdcc.mapreduce.example.graph.clique.impl.CliqueAppImpl { 

	public abstract class BaseIMasterProcessImpl<PLATFORM>: Application, BaseIMasterProcess<PLATFORM>
		where PLATFORM:IPlatform {

		private IString input_data = null;
		protected IString Input_data {
			get {
				if (this.input_data == null)
					this.input_data = (IString) Services.getPort("input_data");
				return this.input_data;
			}
		}

		private IIterator<IKVPair<IString,ICliqueNode>> output_data = null;
		protected IIterator<IKVPair<IString,ICliqueNode>> Output_data {
			get {
				if (this.output_data == null)
					this.output_data = (IIterator<IKVPair<IString,ICliqueNode>>) Services.getPort("output_data");
				return this.output_data;
			}
		}

		private IMaster<PLATFORM> clique = null;
		protected IMaster<PLATFORM> Clique {
			get {
				if (this.clique == null)
					this.clique = (IMaster<PLATFORM>) Services.getPort("clique");
				return this.clique;
			}
		}
	}
}
