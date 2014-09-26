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

		private const string PATH = "/home/cenez/pagerank.txt";

		public IMasterProcessImpl() { 

		} 

		public override void main() { 
			((IStringInstance)Input_data.Instance).Value = readInput();
			IIteratorInstance<IKVPair<IString,IDouble>> output_data_instance = (IIteratorInstance<IKVPair<IString,IDouble>>) Output_data.Instance;
			Page_rank.go();
			object o;
			while (output_data_instance.fetch_next (out o)) {
				IKVPairInstance<IString,IDouble> kvp = (IKVPairInstance<IString,IDouble>)o;
				IStringInstance k = (IStringInstance)kvp.Key;
				IDoubleInstance v = (IDoubleInstance)kvp.Value;
				string saida = "Key=" + k.Value + " Value=" + v.Value;
				Trace.WriteLine (saida);
				//using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"/home/cenez/workspace/java/hash-programming-environment-read-only/HPE_BackEnd/logMaster", true)){
				//	file.WriteLine(saida);
				//}
			}
		}
		string readInput(){
			return System.IO.File.ReadAllText(PATH);
		}
	}
}
