/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PageRank;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PageRankApp; 
using br.ufc.mdcc.common.Platform;

namespace br.ufc.mdcc.mapreduce.example.graph.pagerank.impl.PageRankAppImpl { 

	public abstract class BaseIVoteReduceProcessImpl<PLATFORM>: Application, BaseIVoteReduceProcess<PLATFORM>
		where PLATFORM:IPlatform{

		private IVoteReduce<PLATFORM> page_rank = null;
		protected IVoteReduce<PLATFORM> Page_rank {
			get {
				if (this.page_rank == null)
					this.page_rank = (IVoteReduce<PLATFORM>) Services.getPort("page_rank");
				return this.page_rank;
			}
		}
	}
}
