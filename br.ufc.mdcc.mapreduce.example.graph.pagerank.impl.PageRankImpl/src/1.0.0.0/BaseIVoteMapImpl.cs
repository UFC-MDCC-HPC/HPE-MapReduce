/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.MapReduce;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PageRank;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.VoteReduce;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.common.Double;
using br.ufc.mdcc.common.Integer;

namespace br.ufc.mdcc.mapreduce.example.graph.pagerank.impl.PageRankImpl { 

	public abstract class BaseIVoteMapImpl<PLATFORM>: Computation, BaseIVoteMap<PLATFORM>
		where PLATFORM:IPlatform{

		private IReduceWorker<IInteger, IKVPair<IInteger, IDouble>, IVoteReduce, IDouble, PLATFORM> page_rank = null;
		protected IReduceWorker<IInteger, IKVPair<IInteger, IDouble>, IVoteReduce, IDouble, PLATFORM> Page_rank {
			get {
				if (this.page_rank == null)
					this.page_rank = (IReduceWorker<IInteger, IKVPair<IInteger, IDouble>, IVoteReduce, IDouble, PLATFORM>) 
						Services.getPort("page_rank");
				return this.page_rank;
			}
		}
	}
}
