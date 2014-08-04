using System;
using System.IO;
using System.Collections.Generic;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.BreakInPageNodes;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PageNode;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.String;

namespace br.ufc.mdcc.mapreduce.example.graph.pagerank.impl.BreakInPageNodesImpl { 
	public class IBreakInPageNodesImpl : BaseIBreakInPageNodesImpl, IBreakInPageNodes{
	   
		public IBreakInPageNodesImpl() { } 

		public override void main() { 
			System.Console.WriteLine ("################################################ Starting BReaklnPageNodesImpl ###########################################");
			createPageNodes(((IStringInstance) Input_data.Instance).Value);
		}

		private void createPageNodes(string fileContent){

			IIteratorInstance<IKVPair<IInteger, IPageNode>> output_data_instance = (IIteratorInstance<IKVPair<IInteger, IPageNode>>) Output_data.Instance;
			IDictionary<int, IDictionary<int,IPageNodeInstance>> dictionary = new Dictionary<int, IDictionary<int,IPageNodeInstance>>();
			object alternativeID = null;//IIntegerInstance

			IList<IPageNodeInstance> PAGENODES = new List<IPageNodeInstance>();

			string[] lines = fileContent.Split(new char[] {System.Environment.NewLine[0]});
			foreach (string line in lines){
				if (!line.Trim().Equals ("")) {
					IPageNodeInstance V, W, temp = null;
					IDictionary<int,IPageNodeInstance> referenceV, referenceW = null;

					int[] KEY = new int[2];
					string[] vwID = line.Split (' ');
					for (int k = 0; k < 2; k++) {
						KEY [k] = int.Parse (vwID [k]);
					}
					if (!dictionary.TryGetValue (KEY [0], out referenceV)) { //verifica se node V existe
						IKVPairInstance<IInteger,IPageNode> integer_pagenode_pair = (IKVPairInstance<IInteger,IPageNode>) Output_data.createItem() ;

						V = (IPageNodeInstance)integer_pagenode_pair.Value;//Input_data.createItem ();
						((IIntegerInstance)V.IdInstance).Value = KEY [0];
						integer_pagenode_pair.Key = V.IdInstance;

						referenceV = new Dictionary<int,IPageNodeInstance> ();
						dictionary [KEY [0]] = referenceV;
						referenceV [KEY [0]] = V;
						if (alternativeID == null)
							alternativeID = CreateClone ((IIntegerInstance)V.IdInstance);//(IIntegerInstance)V.Id.clone ();
						V.NeighborsInstance.put (alternativeID); //insere ID_Alternativo, para, quando vizinhoSize=0, passar o voto para o ID_Alternativo

						PAGENODES.Add (V);
						output_data_instance.put(integer_pagenode_pair);//input_data_instance.put (V);
					}
					if (!dictionary.TryGetValue (KEY [1], out referenceW)) { //verifica se node W existe
						IKVPairInstance<IInteger,IPageNode> integer_pagenode_pair = (IKVPairInstance<IInteger,IPageNode>) Output_data.createItem() ;

						W = (IPageNodeInstance)integer_pagenode_pair.Value;//Input_data.createItem ();
						((IIntegerInstance)W.IdInstance).Value = KEY [1];
						integer_pagenode_pair.Key = W.IdInstance;

						referenceW = new Dictionary<int,IPageNodeInstance> ();
						dictionary [KEY [1]] = referenceW;
						referenceW [KEY [1]] = W;
						if (alternativeID == null)
							alternativeID = CreateClone ((IIntegerInstance)W.IdInstance);//(IInteger)W.Id.clone ();
						W.NeighborsInstance.put (alternativeID);

						PAGENODES.Add (W);
						output_data_instance.put(integer_pagenode_pair);//input_data_instance.put (W);
					}
					if (!referenceV.TryGetValue (KEY [1], out temp)) {//Verifica se existe o vizinho W
						V = referenceV [KEY [0]];
						W = referenceW [KEY [1]];
						referenceV [KEY [1]] = W;
						V.NeighborsInstance.put (W.IdInstance);
					}
				}
			}
			((IIntegerInstance)alternativeID).Value = -1 * dictionary.Count;
			output_data_instance.finish(); //input_data_instance.finish ();

			//finish iterator NeighborsInstance
			IEnumerator<IPageNodeInstance> it = PAGENODES.GetEnumerator ();
			while (it.MoveNext ()) {
				IPageNodeInstance p = it.Current;
				p.NeighborsInstance.finish ();
			}
		}
		private static object CreateClone(object obj){
			object copy;
			Stream stream = new MemoryStream();
			System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
			formatter.Serialize(stream, obj);
			stream.Seek(0, 0);
			copy = formatter.Deserialize(stream);
			stream.Close();
			return copy;
		}	
	}
}
