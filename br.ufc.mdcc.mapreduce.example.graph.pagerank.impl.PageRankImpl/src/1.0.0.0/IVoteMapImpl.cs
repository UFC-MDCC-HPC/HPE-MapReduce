using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PageRank;
using System.Diagnostics;

namespace br.ufc.mdcc.mapreduce.example.graph.pagerank.impl.PageRankImpl { 
	public class IVoteMapImpl<PLATFORM> : BaseIVoteMapImpl<PLATFORM>, IVoteMap<PLATFORM> where PLATFORM:IPlatform{
		public IVoteMapImpl() { 

		} 

		public override void main() { 
			Trace.WriteLine ("################################################ Starting PageRankImpl VoteMapImpl ###########################################");
			this.Page_rank.go();
		}
	}
}
