/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.MapReduce;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PageNode;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.Double;
using br.ufc.mdcc.mapreduce.user.PartitionFunction;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.VoteMap;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PageRank;

namespace br.ufc.mdcc.mapreduce.example.graph.pagerank.impl.PageRankImpl { 
	public abstract class BaseIVoteMapImpl<PLATFORM>: Computation, BaseIVoteMap<PLATFORM> where PLATFORM:IPlatform{

		private IMapWorker<IInteger, IPageNode, IInteger, IDouble, IPartitionFunction<IInteger>, IVoteMap, PLATFORM> page_rank = null;
		protected IMapWorker<IInteger, IPageNode, IInteger, IDouble, IPartitionFunction<IInteger>, IVoteMap, PLATFORM> Page_rank {
			get {
				if (this.page_rank == null)
					this.page_rank = (IMapWorker<IInteger, IPageNode, IInteger, IDouble, IPartitionFunction<IInteger>, IVoteMap, PLATFORM>) Services.getPort("page_rank");
				return this.page_rank;
			}
		}
	}
}
