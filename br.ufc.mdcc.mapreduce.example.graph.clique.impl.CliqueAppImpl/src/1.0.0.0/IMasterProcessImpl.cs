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

namespace br.ufc.mdcc.mapreduce.example.graph.clique.impl.CliqueAppImpl { 

	public class IMasterProcessImpl<PLATFORM> : BaseIMasterProcessImpl<PLATFORM>, IMasterProcess<PLATFORM>
		where PLATFORM:IPlatform{

		private const string PATH = "/home/cenez/clique.txt";

		public IMasterProcessImpl() { 

		} 

		public override void main() { 
			IStringInstance input_data_instance = (IStringInstance) Input_data.Instance;
			input_data_instance.Value = readInput();

			Clique.go();

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
				System.Console.WriteLine ("]");
				if (maxclique < size)
					maxclique = size;
			}
			System.Console.WriteLine ("Max clique include "+maxclique+" nodes.");
		}
		string readInput(){
			return System.IO.File.ReadAllText(PATH);
		}
	}
}
