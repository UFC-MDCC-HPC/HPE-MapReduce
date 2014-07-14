using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PageRankApp;

namespace br.ufc.mdcc.mapreduce.example.graph.pagerank.impl.PageRankAppImpl { 
	public class IVoteMapProcessImpl<PLATFORM> : BaseIVoteMapProcessImpl<PLATFORM>, IVoteMapProcess<PLATFORM> where PLATFORM:IPlatform{

		public IVoteMapProcessImpl() { 

		} 

		public override void main() { 
			Page_rank.go();
		}
	}
}
