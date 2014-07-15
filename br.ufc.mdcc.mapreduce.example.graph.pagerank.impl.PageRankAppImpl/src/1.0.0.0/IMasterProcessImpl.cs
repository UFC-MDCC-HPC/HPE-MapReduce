using System;
using System.IO;
using System.Collections.Generic;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.Double;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PageRankApp;

namespace br.ufc.mdcc.mapreduce.example.graph.pagerank.impl.PageRankAppImpl { 
	public class IMasterProcessImpl<PLATFORM> : BaseIMasterProcessImpl<PLATFORM>, IMasterProcess<PLATFORM>
		where PLATFORM:IPlatform{

		private const string PATH = "/home/cenez/pagerank.txt";

		public IMasterProcessImpl() { 

		} 

		public override void main() { 
			System.Console.WriteLine ("################################################ Starting PageRankAppImpl ###########################################");
			((IStringInstance)Input_data.Instance).Value = readInput();
			IIteratorInstance<IKVPair<IInteger,IDouble>> output_data_instance = (IIteratorInstance<IKVPair<IInteger,IDouble>>) Output_data.Instance;

			System.Console.WriteLine ("################################################ Starting Page_rank.go(); ###########################################");
			Page_rank.go();
			System.Console.WriteLine ("################################################ Stopping Page_rank.go(); ###########################################");



			System.Console.WriteLine ("################################################ Iterate Output_data ################################################");
			IDictionary<int,double> results = new Dictionary<int,double> ();
			int count = 0;
			double alternativeRank = 0.0, sum = 0.0, additional = 0.0;
			object kvpair_object;
			while (output_data_instance.fetch_next (out kvpair_object)) {
				IKVPairInstance<IInteger,IDouble> kv = (IKVPairInstance<IInteger,IDouble>) kvpair_object;
				int key = ((IIntegerInstance)kv.Key).Value;
				double value = ((IDoubleInstance)kv.Value).Value;

				if (key >= 0) {
					results [key] = value; //Console.Out.Write (key + ":"); //Console.Out.WriteLine (value);
					count++;
				} else {
					alternativeRank = value;
				}
				sum += value;
			}
			additional = alternativeRank / count;
			System.Console.WriteLine ("#####################################################################################################################");

			System.Console.WriteLine ("################################################### Results #########################################################");
			IEnumerator<int> iterator = results.Keys.GetEnumerator();
			for (;iterator.MoveNext();){
				int K = iterator.Current;
				results [K] += additional;
				double V = results[K];
				Console.Out.Write (K + ":"); 
				Console.Out.WriteLine (V);
			}
			System.Console.WriteLine ("################################################ Warning ############################################################");
			if (((int)sum) == count) {
				System.Console.WriteLine ("Computation verify: OK");
				System.Console.WriteLine ("Additional rank for all nodes: " + additional);
			}
			else
				System.Console.WriteLine ("Computation verify: failed");
			System.Console.WriteLine ("#####################################################################################################################");
		}
		string readInput(){
			return System.IO.File.ReadAllText(PATH);
		}
	}
}
