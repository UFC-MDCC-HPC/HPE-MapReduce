using System;
using System.Collections.Generic;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.example.graph.clique.BreakInCliqueNodes;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.mapreduce.example.graph.clique.CliqueNode;

namespace br.ufc.mdcc.mapreduce.example.graph.clique.impl.BreakInCliqueNodesImpl { 

	public class IBreakInCliqueNodesImpl : BaseIBreakInCliqueNodesImpl, IBreakInCliqueNodes{
		public IBreakInCliqueNodesImpl() { 

		} 

		public override void main() { 
			string fileContent = ((IStringInstance)this.Input_data.Instance).Value;
			createCliqueNodes(fileContent);

		}
		public void createCliqueNodes(string fileContent){
			IIteratorInstance<IKVPair<IInteger, ICliqueNode<IInteger>>> output_data_instance = (IIteratorInstance<IKVPair<IInteger, ICliqueNode<IInteger>>>) Output_data.Instance;

			IDictionary<int, IDictionary<int,ICliqueNodeInstance<IInteger>>> dictionary = new Dictionary<int, IDictionary<int,ICliqueNodeInstance<IInteger>>>();

			string[] lines = fileContent.Split(new char[] {System.Environment.NewLine[0]});
			foreach (string line in lines){
				if (!line.Trim ().Equals ("")) {
					ICliqueNodeInstance<IInteger> V, W, temp = null;
					IDictionary<int,ICliqueNodeInstance<IInteger>> referenceV, referenceW = null;

					int[] KEY = new int[2];
					string[] vwID = line.Split (' ');
					for (int k = 0; k < 2; k++) {
						KEY [k] = int.Parse (vwID [k]);
					}
					if (!dictionary.TryGetValue (KEY [0], out referenceV)) { /*verifica se node V existe*/
						IKVPairInstance<IInteger, ICliqueNode<IInteger>> kv = (IKVPairInstance<IInteger, ICliqueNode<IInteger>>)Output_data.createItem (); 
						V = (ICliqueNodeInstance<IInteger>)kv.Value;
						V.IdInstance = kv.Key;
						((IIntegerInstance)V.IdInstance).Value = KEY [0];
						referenceV = new Dictionary<int,ICliqueNodeInstance<IInteger>> ();
						dictionary [KEY [0]] = referenceV;
						referenceV [KEY [0]] = V;

						output_data_instance.put (kv);
					}
					if (!dictionary.TryGetValue (KEY [1], out referenceW)) { /*verifica se node W existe*/
						IKVPairInstance<IInteger, ICliqueNode<IInteger>> kv = (IKVPairInstance<IInteger, ICliqueNode<IInteger>>)Output_data.createItem (); 
						W = (ICliqueNodeInstance<IInteger>)kv.Value;
						W.IdInstance = kv.Key;
						((IIntegerInstance)W.IdInstance).Value = KEY [1];
						referenceW = new Dictionary<int,ICliqueNodeInstance<IInteger>> ();
						dictionary [KEY [1]] = referenceW;
						referenceW [KEY [1]] = W;

						output_data_instance.put (kv);
					}
					if (!referenceV.TryGetValue (KEY [1], out temp)) {/*Verifica se existe o vizinho W*/
						V = referenceV [KEY [0]];
						W = referenceW [KEY [1]];
						referenceV [KEY [1]] = W;
						V.NeighborsInstance.put (W.IdInstance);
						referenceW [KEY [0]] = V;
						W.NeighborsInstance.put (V.IdInstance);
					}
				}
			}
		}
	}
}
