using System;
using System.Collections.Generic;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.mapreduce.example.graph.clique.CliqueApp;
using br.ufc.mdcc.mapreduce.example.graph.clique.CliqueNode;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Iterator;
using System.Threading;
using System.Diagnostics;

namespace br.ufc.mdcc.mapreduce.example.graph.clique.impl.CliqueAppImpl { 

	public class IMasterProcessImpl<PLATFORM> : BaseIMasterProcessImpl<PLATFORM>, IMasterProcess<PLATFORM>
		where PLATFORM:IPlatform{

		private const string PATH = "/home/hpe/clique.txt";

		public IMasterProcessImpl() { 

		} 

		public void Go ()
		{
			Clique.go ();
		}

		public override void main() { 
			IStringInstance input_data_instance = (IStringInstance) Input_data.Instance;
			input_data_instance.Value = readInput();

			long t0 = (long)(DateTime.UtcNow - (new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc))).TotalMilliseconds; 
			Clique.go ();
			long t1 = (long)(DateTime.UtcNow - (new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc))).TotalMilliseconds; 

			IIteratorInstance<IKVPair<IString,ICliqueNode>> output_data_instance = (IIteratorInstance<IKVPair<IString,ICliqueNode>>) Output_data.Instance;
			int sum = 0;
			object o;
			while (output_data_instance.fetch_next(out o)){
				IKVPairInstance<IString,ICliqueNode> KMV = (IKVPairInstance<IString,ICliqueNode>) o;
				IStringInstance pivo = (IStringInstance)KMV.Key;
				ICliqueNodeInstance cliqueNode = (ICliqueNodeInstance)KMV.Value;
				sum += cliqueNode.IdInstance;
			}
			clearWriteFile ("./outCliqueApp", "Soma:" + sum+ "Tempo:" +(t1-t0));
		}
		string readInput(){
			return System.IO.File.ReadAllText(PATH);
		}
		public static void clearWriteFile(string PATH, string saida)
		{
			using (System.IO.StreamWriter file = new System.IO.StreamWriter(@PATH, false)){
				file.WriteLine(saida);
			}
		}
	}
}
