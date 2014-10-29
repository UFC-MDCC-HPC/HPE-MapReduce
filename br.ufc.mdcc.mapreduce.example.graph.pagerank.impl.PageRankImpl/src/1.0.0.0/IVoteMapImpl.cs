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
			string[] string_iteracoes = readInput ("/home/hpe/iteracoes").Split(new char[] {System.Environment.NewLine[0]});
			int iteracoes = int.Parse (string_iteracoes [0]);

			int count = 0;
			while (count++ < iteracoes) {
				this.Page_rank.go ();
			}
		}
		string readInput(string PATH){
			return System.IO.File.ReadAllText(PATH);
		}
		public static void writeFile(string PATH, string saida){
			using (System.IO.StreamWriter file = new System.IO.StreamWriter(@PATH, true)){
				file.WriteLine(saida);
			}
		}
	}
}
