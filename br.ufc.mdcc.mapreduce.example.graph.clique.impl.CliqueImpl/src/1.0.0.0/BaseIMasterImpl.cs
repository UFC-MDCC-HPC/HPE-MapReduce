/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.MapReduce;
using br.ufc.mdcc.mapreduce.user.PartitionFunction;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.mapreduce.user.CombineFunction;
using br.ufc.mdcc.mapreduce.example.graph.clique.Clique;
using br.ufc.mdcc.mapreduce.example.graph.clique.BreakInCliqueNodes;
using br.ufc.mdcc.mapreduce.example.graph.clique.CliqueNode;

namespace br.ufc.mdcc.mapreduce.example.graph.clique.impl.CliqueImpl { 

	public abstract class BaseIMasterImpl<PLATFORM>: Computation, BaseIMaster<PLATFORM>
		where PLATFORM:IPlatform{
	
		private IIterator<ICliqueNode<IInteger>> input_data = null;
		public IIterator<ICliqueNode<IInteger>> Input_data {
			get {
				if (this.input_data == null)
					this.input_data = (IIterator<ICliqueNode<IInteger>>) Services.getPort("input_data");
				return this.input_data;
			}
		}

		private IIterator<IKVPair<IInteger, IIterator<IKVPair<IInteger, IIterator<IInteger>>>>> output_data = null;
		public IIterator<IKVPair<IInteger, IIterator<IKVPair<IInteger, IIterator<IInteger>>>>> Output_data {
			get {
				if (this.output_data == null)
					this.output_data = (IIterator<IKVPair<IInteger, IIterator<IKVPair<IInteger, IIterator<IInteger>>>>>) Services.getPort("output_data");
				return this.output_data;
			}
		}

		private IManagerMapReduce<IIterator<ICliqueNode<IInteger>>, IInteger, ICliqueNode<IInteger>, IBreakInCliqueNodes, IPartitionFunction<IInteger>, IInteger, IKVPair<IInteger, IIterator<IKVPair<IInteger, IIterator<IInteger>>>>, ICombineFunction<IKVPair<IInteger, IIterator<IKVPair<IInteger, IIterator<IInteger>>>>, IIterator<IKVPair<IInteger, IIterator<IKVPair<IInteger, IIterator<IInteger>>>>>>, IIterator<IKVPair<IInteger, IIterator<IKVPair<IInteger, IIterator<IInteger>>>>>, PLATFORM> clique = null;
		protected IManagerMapReduce<IIterator<ICliqueNode<IInteger>>, IInteger, ICliqueNode<IInteger>, IBreakInCliqueNodes, IPartitionFunction<IInteger>, IInteger, IKVPair<IInteger, IIterator<IKVPair<IInteger, IIterator<IInteger>>>>, ICombineFunction<IKVPair<IInteger, IIterator<IKVPair<IInteger, IIterator<IInteger>>>>, IIterator<IKVPair<IInteger, IIterator<IKVPair<IInteger, IIterator<IInteger>>>>>>, IIterator<IKVPair<IInteger, IIterator<IKVPair<IInteger, IIterator<IInteger>>>>>, PLATFORM> Clique {
			get {
				if (this.clique == null)
					this.clique = (IManagerMapReduce<IIterator<ICliqueNode<IInteger>>, IInteger, ICliqueNode<IInteger>, IBreakInCliqueNodes, IPartitionFunction<IInteger>, IInteger, IKVPair<IInteger, IIterator<IKVPair<IInteger, IIterator<IInteger>>>>, ICombineFunction<IKVPair<IInteger, IIterator<IKVPair<IInteger, IIterator<IInteger>>>>, IIterator<IKVPair<IInteger, IIterator<IKVPair<IInteger, IIterator<IInteger>>>>>>, IIterator<IKVPair<IInteger, IIterator<IKVPair<IInteger, IIterator<IInteger>>>>>, PLATFORM>) Services.getPort("clique");
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

/*Obs:
 * In, IIterator<ICliqueNode<IInteger>>
 * IMK, IInteger
 * IMV, ICliqueNode<IInteger>,
 * Sf, IBreakInCliqueNodes
 * Bf, IPartitionFunction<IInteger>,
 * OMK, IInteger
 * OMV, IDouble
 * ORV, IKVPair<IInteger, IDouble>, 
 * Cf, ICombineFunction<IKVPair<IInteger, IDouble>,IIterator<IKVPair<IInteger,IDouble>>>,	
 * Out, IIterator<IKVPair<IInteger, IDouble>>, 
 * PLATFORM> 
*/
