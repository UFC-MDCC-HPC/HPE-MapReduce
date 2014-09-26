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

		private const string PATH = "/home/cenez/clique.txt";

		public IMasterProcessImpl() { 

		} 

		public void Go ()
		{
			Clique.go ();
		}

		public override void main() { 

			//Debug
			string data_tempo = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Local).ToLocalTime().ToString(@"M-d-yyyy_hh.mm.ss.tt");
			string[] data_file_common = { data_tempo };
			System.IO.File.WriteAllLines(@"/home/cenez/data.txt", data_file_common);
			//Debug

			IStringInstance input_data_instance = (IStringInstance) Input_data.Instance;
			input_data_instance.Value = readInput();

			Thread tGo = new Thread(new ThreadStart(Go));
			tGo.Start();

			IIteratorInstance<IKVPair<IString,ICliqueNode>> output_data_instance = (IIteratorInstance<IKVPair<IString,ICliqueNode>>) Output_data.Instance;

			int maxclique = -1;
			object o;
			while (output_data_instance.fetch_next(out o)){
				IKVPairInstance<IString,ICliqueNode> KMV = (IKVPairInstance<IString,ICliqueNode>) o;
				IStringInstance pivo = (IStringInstance)KMV.Key;
				ICliqueNodeInstance cliqueNode = (ICliqueNodeInstance)KMV.Value;
				int size = cliqueNode.NeighborsInstance.Count;
				System.Console.Write ("Pivo:" + pivo.Value + " size:"+ size +"[");
				IEnumerator<int> iterator = cliqueNode.NeighborsInstance.GetEnumerator ();
				while (iterator.MoveNext ()) {
					System.Console.Write (iterator.Current+" ");
				}
				Trace.WriteLine ("]");
				if (maxclique < size)
					maxclique = size;
			}
			
			tGo.Join();

			Trace.WriteLine ("Max clique include "+maxclique+" nodes.");
		}
		string readInput(){
			return System.IO.File.ReadAllText(PATH);
		}
	}
}
