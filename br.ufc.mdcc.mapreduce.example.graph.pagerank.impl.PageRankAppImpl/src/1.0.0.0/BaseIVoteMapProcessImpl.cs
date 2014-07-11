/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PageRank;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PageRankApp;

namespace br.ufc.mdcc.mapreduce.example.graph.pagerank.impl.PageRankAppImpl { 
	public abstract class BaseIVoteMapProcessImpl<PLATFORM>: Application, BaseIVoteMapProcess<PLATFORM> where PLATFORM:IPlatform{

		private IVoteMap<PLATFORM> page_rank = null;
		protected IVoteMap<PLATFORM> Page_rank {
			get {
				if (this.page_rank == null)
					this.page_rank = (IVoteMap<PLATFORM>) Services.getPort("page_rank");
				return this.page_rank;
			}
		}
	}
}
