using System;
using System.IO;
using System.Collections.Generic;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.impl.IteratorImpl;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PageRankApp;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PageNode;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PGRank;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Double;
using br.ufc.mdcc.common.Integer;

namespace br.ufc.mdcc.mapreduce.example.graph.pagerank.impl.PageRankAppImpl { 
	public class IMasterProcessImpl<PLATFORM> : BaseIMasterProcessImpl<PLATFORM>, IMasterProcess<PLATFORM>
		where PLATFORM:IPlatform{

		private const string PATH = "pathFile";
		private IDictionary<IInteger,IPageNode<IInteger>> PAGENODES = new Dictionary<IInteger,IPageNode<IInteger>> ();
		private double outDegreeEmpty, sum = 0.0;

		public IMasterProcessImpl() { } 

		public override void main() {

			string fileContent = readInput();
			createPageNodes(fileContent);

			Page_rank.go();

			while (!Output_data.HasFinished) {
				IKVPair<IInteger,IDouble> kv = Output_data.fetch_next();
				if (kv.Key.Value >= 0) {
					Console.Out.Write (kv.Key.Value + ":");
					Console.Out.WriteLine (kv.Value.Value);
					PAGENODES [kv.Key].Pgrank.Value = kv.Value.Value;
				} else {
					outDegreeEmpty = kv.Value.Value;
				}
				sum += kv.Value.Value;
			}
			if (((int)sum) == PAGENODES.Count) {
				System.Console.WriteLine ("Computation verify: OK");
				System.Console.WriteLine ("Additional Pgrank.Value for all nodes: " + outDegreeEmpty / PAGENODES.Count);
			}
			else
				System.Console.WriteLine ("Computation verify: failed");
		}

		public void createPageNodes(string fileContent){
			IDictionary<int, IDictionary<int,IPageNode<IInteger>>> dictionary = new Dictionary<int, IDictionary<int,IPageNode<IInteger>>>();
			IInteger alternativeID = null;

			string[] lines = fileContent.Split(new char[] {'\n'});
			foreach (string line in lines){
				IPageNode<IInteger> V, W, temp = null;
				IDictionary<int,IPageNode<IInteger>> referenceV, referenceW = null;

				int[] KEY = new int[2];
				string[] vwID = line.Split(' ');
				for(int k=0;k<2;k++){
					KEY[k] = int.Parse(vwID[k]);
				}
				if (!dictionary.TryGetValue (KEY [0], out referenceV)) { /*verifica se node V existe*/
					V = Input_data.createItem();
					V.Id.Value = KEY [0];

					referenceV = new Dictionary<int,IPageNode<IInteger>> ();
					dictionary [KEY [0]] = referenceV;
					referenceV [KEY [0]] = V;
					if (alternativeID == null)
						alternativeID = (IInteger)V.Id.clone ();
					V.Neighbors.put (alternativeID); /*insere ID_Alternativo, para, quando vizinhoSize=0, passar o voto para o ID_Alternativo*/
					PAGENODES [V.Id] = V;
				}
				if (!dictionary.TryGetValue (KEY [1], out referenceW)) { /*verifica se node W existe*/
					W = Input_data.createItem();
					W.Id.Value = KEY [1];

					referenceW = new Dictionary<int,IPageNode<IInteger>> ();
					dictionary [KEY [1]] = referenceW;
					referenceW [KEY [1]] = W;
					if (alternativeID == null)
						alternativeID = (IInteger)W.Id.clone ();
					W.Neighbors.put (alternativeID);
					PAGENODES [W.Id] = W;
				}
				V = referenceV[KEY[0]];
				W = referenceW[KEY[1]];
				if (!referenceV.TryGetValue (KEY [1], out temp)) {/*Verifica se existe o vizinho W*/
					referenceV [KEY [1]] = W;
					V.Neighbors.put (W.Id);
				}
			}
			alternativeID.Value = -1 * dictionary.Count;
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
