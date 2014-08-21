/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.MapReduce;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Double;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PageRank;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PageNode;
using br.ufc.mdcc.mapreduce.user.PartitionFunction;
using br.ufc.mdcc.mapreduce.user.CombineFunction;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.BreakInPageNodes;

namespace br.ufc.mdcc.mapreduce.example.graph.pagerank.impl.PageRankImpl { 
	public abstract class BaseIMasterImpl<PLATFORM>: Computation, BaseIMaster<PLATFORM>
		where PLATFORM:IPlatform{

		private IIterator<IKVPair<IString,IDouble>> output_data = null;
		public IIterator<IKVPair<IString,IDouble>> Output_data {
			get {
				if (this.output_data == null)
					this.output_data = (IIterator<IKVPair<IString,IDouble>>) Services.getPort("output_data");
				return this.output_data;
			}
		}

		private IString input_data = null;
		public IString Input_data {
			get {
				if (this.input_data == null)
					this.input_data = (IString) Services.getPort("input_data");
				return this.input_data;
			}
		}
		//IManagerMapReduce<In, IMK, IMV, OMK, ORV, Out, Sf, Bf, Cf, PLATFORM>
		private IManagerMapReduce<IString, IInteger, IPageNode, IString, IKVPair<IString, IDouble>, IIterator<IKVPair<IString, IDouble>>, IBreakInPageNodes, IPartitionFunction<IInteger>, ICombineFunction<IKVPair<IString, IDouble>,IIterator<IKVPair<IString,IDouble>>>, PLATFORM> page_rank = null;
		protected IManagerMapReduce<IString, IInteger, IPageNode, IString, IKVPair<IString, IDouble>, IIterator<IKVPair<IString, IDouble>>, IBreakInPageNodes, IPartitionFunction<IInteger>, ICombineFunction<IKVPair<IString, IDouble>,IIterator<IKVPair<IString,IDouble>>>, PLATFORM> Page_rank {
			get {
				if (this.page_rank == null)
					this.page_rank = (IManagerMapReduce<IString, IInteger, IPageNode, IString, IKVPair<IString, IDouble>, IIterator<IKVPair<IString, IDouble>>, IBreakInPageNodes, IPartitionFunction<IInteger>, ICombineFunction<IKVPair<IString, IDouble>,IIterator<IKVPair<IString,IDouble>>>, PLATFORM>) Services.getPort("page_rank");
				return this.page_rank;
			}
		}

	}
}
