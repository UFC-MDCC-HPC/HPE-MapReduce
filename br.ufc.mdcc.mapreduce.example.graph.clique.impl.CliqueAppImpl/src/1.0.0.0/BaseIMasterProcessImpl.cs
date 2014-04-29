/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.example.graph.clique.Clique;
using br.ufc.mdcc.mapreduce.example.graph.clique.CliqueApp;
using br.ufc.mdcc.mapreduce.example.graph.clique.CliqueNode;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Integer;

namespace br.ufc.mdcc.mapreduce.example.graph.clique.impl.CliqueAppImpl { 
	public abstract class BaseIMasterProcessImpl<PLATFORM>: Application, BaseIMasterProcess<PLATFORM>
		where PLATFORM:IPlatform{

		private IIterator<ICliqueNode<IInteger>> input_data = null;
		public IIterator<ICliqueNode<IInteger>> Input_data {
			get {
				if (this.input_data == null)
					this.input_data = (IIterator<ICliqueNode<IInteger>>) Services.getPort("input_data");
				return this.input_data;
			}
		}

		private IIterator<IKVPair<IInteger,IIterator<IKVPair<IInteger, IIterator<IInteger>>>>> output_data = null;
		public IIterator<IKVPair<IInteger,IIterator<IKVPair<IInteger, IIterator<IInteger>>>>> Output_data {
			get {
				if (this.output_data == null)
					this.output_data = (IIterator<IKVPair<IInteger,IIterator<IKVPair<IInteger, IIterator<IInteger>>>>>) Services.getPort("output_data");
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

//ICombineFunction<ORV, O>
//IManagerMapReduce<In, IMK, IMV, Sf, Bf, OMK, ORV, Cf, Out, PLATFORM> 
//ISplitFunction<I, IMK, IMV>
//IMK:IInteger
//IMV:ICliqueNode<IInteger>
//OMK: IInteger
//OMV: IKVPair<IInteger, IIterator<IInteger>>
//ORV: IKVPair<IInteger, IIterator<IKVPair<IInteger, IIterator<IInteger>>>>
