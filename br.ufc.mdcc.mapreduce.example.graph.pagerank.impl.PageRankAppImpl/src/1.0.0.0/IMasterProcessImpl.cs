using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PageRankApp;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.common.Double;
using br.ufc.mdcc.common.Integer;

namespace br.ufc.mdcc.mapreduce.example.graph.pagerank.impl.PageRankAppImpl { 
	public class IMasterProcessImpl<PLATFORM> : BaseIMasterProcessImpl<PLATFORM>, IMasterProcess<PLATFORM>
		where PLATFORM:IPlatform{

		public IMasterProcessImpl() { } 

		public override void main() {
			Input_data.Value = readInput();
			Page_rank.go();
			while (!Output_data.HasFinished) {
				IKVPair<IInteger,IDouble> kv = Output_data.fetch_next();
				Console.Out.Write (kv.Key + ":");
				Console.Out.WriteLine (kv.Value);
			}
		}

		string readInput (){
			throw new NotImplementedException ();
		}
	}
}
