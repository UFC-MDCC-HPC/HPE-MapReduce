using System;
using System.IO;
using System.Collections.Generic;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.common.Double;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PageRankApp;
using System.Diagnostics;

namespace br.ufc.mdcc.mapreduce.example.graph.pagerank.impl.PageRankAppImpl { 
	public class IMasterProcessImpl<PLATFORM> : BaseIMasterProcessImpl<PLATFORM>, IMasterProcess<PLATFORM>
		where PLATFORM:IPlatform{

		private const string PATH = "/home/hpe/pagerank.txt";

		public IMasterProcessImpl() { 

		} 

		public override void main() { 
			((IStringInstance)Input_data.Instance).Value = readInput();
			IIteratorInstance<IKVPair<IString,IDouble>> output_data_instance = (IIteratorInstance<IKVPair<IString,IDouble>>) Output_data.Instance;

			long t0 = (long)(DateTime.UtcNow - (new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc))).TotalMilliseconds;
			Page_rank.go();
			long t1 = (long)(DateTime.UtcNow - (new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc))).TotalMilliseconds;

			string saida = ((IStringInstance)Input_data.Instance).Value;

			int count = 0;
			double X = 0.0;
			string[] lines = saida.Split(new char[] {System.Environment.NewLine[0]});
			foreach (string line in lines) {
				if (!line.Trim ().Equals ("")) {
					string[] prank = line.Split (' ');
					if (prank [0].Equals ("X")) {
						X = double.Parse (prank [1]);
					} else {
						count++;
					}
				}
			}
			saida = "";
			double slice = X / count;
			foreach (string line in lines) {
				if (!line.Trim ().Equals ("")) {
					string[] prank = line.Split (' ');
					if (!prank [0].Equals ("X")) {
						saida = saida + prank [0] +" "+ (double.Parse (prank [1])+slice) + System.Environment.NewLine;
					}
				}
			}


			//saida = saida + System.Environment.NewLine + "Time=" + (t1 - t0)+"PG";
			saida = "Time=" + (t1 - t0)+"PG";
			writeFile ("./outPageRankApp", saida);
		}
		string readInput(){
			return System.IO.File.ReadAllText(PATH);
		}
		public static void writeFile(string PATH, string saida){
			using (System.IO.StreamWriter file = new System.IO.StreamWriter(@PATH, true)){
				file.WriteLine(saida);
			}
		}
	}
}
