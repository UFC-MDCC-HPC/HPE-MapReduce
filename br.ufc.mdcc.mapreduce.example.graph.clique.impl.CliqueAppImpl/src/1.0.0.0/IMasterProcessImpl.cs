using System;
using System.IO;
using System.Collections.Generic;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.mapreduce.example.graph.clique.CliqueApp;
using br.ufc.mdcc.mapreduce.example.graph.clique.CliqueNode;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Integer;

namespace br.ufc.mdcc.mapreduce.example.graph.clique.impl.CliqueAppImpl { 
	public class IMasterProcessImpl<PLATFORM> : BaseIMasterProcessImpl<PLATFORM>, IMasterProcess<PLATFORM>
		where PLATFORM:IPlatform{

		private const string PATH = "pathFile";

		public IMasterProcessImpl() { } 

		public override void main() {

			string fileContent = readInput();
			createCliqueNodes(fileContent);

			Clique.go();
			int maxclique = 0;

			while (!Output_data.HasFinished){
				IKVPair<IInteger, IIterator<IKVPair<IInteger, IIterator<IInteger>>>> KMV = Output_data.fetch_next();
				IInteger I = KMV.Key;
				IIterator<IKVPair<IInteger, IIterator<IInteger>>> iteratorMV = KMV.Value;
				System.Console.Write ("Pivo:" + I.Value + " ");
				while (!iteratorMV.HasFinished) {
					IKVPair<IInteger, IIterator<IInteger>> KV = iteratorMV.fetch_next ();
					IIterator<IInteger> values = KV.Value;
					System.Console.Write ("<"+KV.Key.Value + ",[");
					if (KV.Key.Value > maxclique)
						maxclique = KV.Key.Value;
					string space = "";
					for (; !values.HasFinished;) {
						IInteger itemCLIQUE = values.fetch_next ();
						System.Console.Write (space+itemCLIQUE.Value); space = " ";
					}
					System.Console.Write("]> ");
				}
				System.Console.WriteLine ();
			}
			System.Console.WriteLine ("Max clique include "+maxclique+" nodes.");
		}

		public void createCliqueNodes(string fileContent){
			IDictionary<int, IDictionary<int,ICliqueNode<IInteger>>> dictionary = new Dictionary<int, IDictionary<int,ICliqueNode<IInteger>>>();

			string[] lines = fileContent.Split(new char[] {'\n'});
			foreach (string line in lines){
				ICliqueNode<IInteger> V, W, temp = null;
				IDictionary<int,ICliqueNode<IInteger>> referenceV, referenceW = null;

				int[] KEY = new int[2];
				string[] vwID = line.Split(' ');
				for(int k=0;k<2;k++){
					KEY[k] = int.Parse(vwID[k]);
				}
				if (!dictionary.TryGetValue (KEY [0], out referenceV)) { /*verifica se node V existe*/
					V = Input_data.createItem();
					V.Id.Value = KEY [0];
					referenceV = new Dictionary<int,ICliqueNode<IInteger>> ();
					dictionary [KEY [0]] = referenceV;
					referenceV [KEY [0]] = V;
				}
				if (!dictionary.TryGetValue (KEY [1], out referenceW)) { /*verifica se node W existe*/
					W = Input_data.createItem();
					W.Id.Value = KEY [1];
					referenceW = new Dictionary<int,ICliqueNode<IInteger>> ();
					dictionary [KEY [1]] = referenceW;
					referenceW [KEY [1]] = W;
				}
				if (!referenceV.TryGetValue (KEY [1], out temp)) {/*Verifica se existe o vizinho W*/
					V = referenceV[KEY[0]];
					W = referenceW[KEY[1]];
					referenceV [KEY [1]] = W;
					V.Neighbors.put (W.Id);
					referenceW [KEY [0]] = V;
					W.Neighbors.put (V.Id);
				}
			}
		}

		string readInput(){
			string str = "";
			byte[] dataByte = readFile ();
			foreach (byte b in dataByte) {
				str = str+Convert.ToChar(b);
			}
			return str;
		}

		byte[] readFile() {
			byte[] res = null;
			try{
				using (FileStream fileread = new FileStream(PATH, FileMode.Open, FileAccess.Read)){					
					byte[] bytes = new byte[fileread.Length];
					int bytesToRead = (int)fileread.Length-1;
					int bytesRead = 0;
					while (bytesToRead > 0){
						int n = fileread.Read(bytes, bytesRead, bytesToRead);
						if (n == 0)
							break;
						bytesRead += n;
						bytesToRead -= n;
					}
					bytesToRead = bytes.Length;
					res = bytes;
				}
			}
			catch (FileNotFoundException e){
				Console.WriteLine("Exception IMasterProcessImpl readFile method: "+e.Message);
			}
			return res;
		}
	}
}
