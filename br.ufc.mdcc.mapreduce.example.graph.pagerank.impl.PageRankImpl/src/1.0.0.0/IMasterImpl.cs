using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PageRank;
using System.Diagnostics;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.common.Double;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;

namespace br.ufc.mdcc.mapreduce.example.graph.pagerank.impl.PageRankImpl { 

	public class IMasterImpl<PLATFORM> : BaseIMasterImpl<PLATFORM>, IMaster<PLATFORM> where PLATFORM:IPlatform{
		public IMasterImpl() { } 

		public override void main() { 
			string[] string_iteracoes = readInput ("/home/hpe/iteracoes").Split(new char[] {System.Environment.NewLine[0]});
			int iteracoes = int.Parse (string_iteracoes [0]);

			IStringInstance input_data_instance = (IStringInstance) Input_data.Instance;
			IIteratorInstance<IKVPair<IString,IDouble>> output_data_instance = (IIteratorInstance<IKVPair<IString,IDouble>>) Output_data.Instance;

			int count = 0;
			while (count++ < iteracoes) {
				double X = 0.0;
				this.Page_rank.go ();
				object o;
				string saida = "";
				while (output_data_instance.fetch_next (out o)) {
					IKVPairInstance<IString,IDouble> kvp = (IKVPairInstance<IString,IDouble>)o;
					IStringInstance k = (IStringInstance)kvp.Key;
					IDoubleInstance v = (IDoubleInstance)kvp.Value;
					if (!k.Value.Equals ("X"))
						saida = saida + k.Value + " " + v.Value + System.Environment.NewLine;
					else
						X = v.Value;
				}
				input_data_instance.Value = "X "+ X + System.Environment.NewLine + saida;
				System.Console.WriteLine ("PAGERANK ITERATION: "+count + " X:"+X);
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
