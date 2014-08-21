/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.MapReduce;
using br.ufc.mdcc.common.Platform;
//using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.common.Double;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PageRank;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.VoteReduce;

namespace br.ufc.mdcc.mapreduce.example.graph.pagerank.impl.PageRankImpl { 
	public abstract class BaseIVoteReduceImpl<PLATFORM>: Computation, BaseIVoteReduce<PLATFORM>
		where PLATFORM:IPlatform{
		//<OMK, OMV, ORV, Rf, PLATFORM>
		private IReduceWorker<IString, IDouble, IKVPair<IString, IDouble>, IVoteReduce, PLATFORM> page_rank = null;
		protected IReduceWorker<IString, IDouble, IKVPair<IString, IDouble>, IVoteReduce, PLATFORM> Page_rank {
			get {
				if (this.page_rank == null)
					this.page_rank = (IReduceWorker<IString, IDouble, IKVPair<IString, IDouble>, IVoteReduce, PLATFORM>) Services.getPort("page_rank");
				return this.page_rank;
			}
		}
	}
}
