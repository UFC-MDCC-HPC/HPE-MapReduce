using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PageRank;

namespace br.ufc.mdcc.mapreduce.example.graph.pagerank.impl.PageRankImpl { 

	public class IMasterImpl<PLATFORM> : BaseIMasterImpl<PLATFORM>, IMaster<PLATFORM> where PLATFORM:IPlatform{
		public IMasterImpl() { } 

		public override void main() { 
			System.Console.WriteLine ("################################################ Starting PageRankImpl Master ###########################################");
			this.Page_rank.go();
		}
	}
}
