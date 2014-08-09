/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.MapReduce;
using br.ufc.mdcc.mapreduce.example.graph.clique.CliqueNode;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.mapreduce.user.PartitionFunction;
using br.ufc.mdcc.mapreduce.example.graph.clique.BreakInCliqueNodes;
using br.ufc.mdcc.mapreduce.user.CombineFunction;
using br.ufc.mdcc.mapreduce.example.graph.clique.Clique;

namespace br.ufc.mdcc.mapreduce.example.graph.clique.impl.CliqueImpl { 

	public abstract class BaseIMasterImpl<PLATFORM>: Computation, BaseIMaster<PLATFORM>
		where PLATFORM:IPlatform{

		private IString input_data = null;
		public IString Input_data {
			get {
				if (this.input_data == null)
					this.input_data = (IString) Services.getPort("input_data");
				return this.input_data;
			}
		}

		private IIterator<IKVPair<IString,ICliqueNode>> output_data = null;
		public IIterator<IKVPair<IString,ICliqueNode>> Output_data {
			get {
				if (this.output_data == null)
					this.output_data = (IIterator<IKVPair<IString,ICliqueNode>>) Services.getPort("output_data");
				return this.output_data;
			}
		}
		//IManagerMapReduce<        In,      IMK,       IMV,        OMK,         ORV,                           Out,                                     Sf,                    Bf,                             Cf,                                                                             PLATFORM>
		private IManagerMapReduce<IString, IInteger, ICliqueNode, IString, IKVPair<IString, ICliqueNode>, IIterator<IKVPair<IString, ICliqueNode>>, IBreakInCliqueNodes, IPartitionFunction<IInteger>, ICombineFunction<IKVPair<IString, ICliqueNode>,IIterator<IKVPair<IString,ICliqueNode>>>, PLATFORM> clique = null;
		protected IManagerMapReduce<IString, IInteger, ICliqueNode, IString, IKVPair<IString, ICliqueNode>, IIterator<IKVPair<IString, ICliqueNode>>, IBreakInCliqueNodes, IPartitionFunction<IInteger>, ICombineFunction<IKVPair<IString, ICliqueNode>,IIterator<IKVPair<IString,ICliqueNode>>>, PLATFORM> Clique {
			get {
				if (this.clique == null)
					this.clique = (IManagerMapReduce<IString, IInteger, ICliqueNode, IString, IKVPair<IString, ICliqueNode>, IIterator<IKVPair<IString, ICliqueNode>>, IBreakInCliqueNodes, IPartitionFunction<IInteger>, ICombineFunction<IKVPair<IString, ICliqueNode>,IIterator<IKVPair<IString,ICliqueNode>>>, PLATFORM>) Services.getPort("clique");
				return this.clique;
			}
		}
	}
}
