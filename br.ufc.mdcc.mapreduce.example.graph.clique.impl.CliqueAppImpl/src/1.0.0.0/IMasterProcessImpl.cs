using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.mapreduce.example.graph.clique.CliqueApp;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.Integer;

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

			IIteratorInstance<IKVPair<IInteger,IIterator<IKVPair<IInteger, IIterator<IInteger>>>>> output_data_instance = (IIteratorInstance<IKVPair<IInteger,IIterator<IKVPair<IInteger, IIterator<IInteger>>>>>) Output_data.Instance;


			int maxclique = 0;
			object o;
			while (output_data_instance.fetch_next(out o)){
				IKVPairInstance<IInteger, IIterator<IKVPair<IInteger, IIterator<IInteger>>>> KMV = (IKVPairInstance<IInteger, IIterator<IKVPair<IInteger, IIterator<IInteger>>>>) o;
				IIntegerInstance I = (IIntegerInstance)KMV.Key;
				IIteratorInstance<IKVPair<IInteger, IIterator<IInteger>>> iteratorMV = (IIteratorInstance<IKVPair<IInteger, IIterator<IInteger>>>)KMV.Value;
				System.Console.Write ("Pivo:" + I.Value + " ");
				while (iteratorMV.fetch_next(out o)) {
					IKVPairInstance<IInteger, IIterator<IInteger>> KV = (IKVPairInstance<IInteger, IIterator<IInteger>>)o;
					IIteratorInstance<IInteger> values = (IIteratorInstance<IInteger>)KV.Value;
					System.Console.Write ("<"+((IIntegerInstance)KV.Key).Value + ",[");
					if (((IIntegerInstance)KV.Key).Value > maxclique)
						maxclique = ((IIntegerInstance)KV.Key).Value;
					string space = "";
					while (values.fetch_next(out o)) {
						IIntegerInstance itemCLIQUE = (IIntegerInstance)o;
						System.Console.Write (space+itemCLIQUE.Value); space = " ";
					}
					System.Console.Write("]> ");
				}
				System.Console.WriteLine ();
			}
			System.Console.WriteLine ("Max clique include "+maxclique+" nodes.");
		}
		string readInput(){
			return System.IO.File.ReadAllText(PATH);
		}
	}
}
