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
		public IBreakInCliqueNodesImpl() { } 

		public override void main() { 
			createCliqueNodes(((IStringInstance) Input_data.Instance).Value);
		}
		private void createCliqueNodes(string fileContent){
			IIteratorInstance<IKVPair<IInteger, ICliqueNode>> output = (IIteratorInstance<IKVPair<IInteger, ICliqueNode>>) Output_data.Instance;
			IDictionary<int, IDictionary<int,ICliqueNodeInstance>> dictionary = new Dictionary<int, IDictionary<int,ICliqueNodeInstance>>();

			IList<IKVPairInstance<IInteger,ICliqueNode>> PAGENODES = new List<IKVPairInstance<IInteger,ICliqueNode>>();

			string[] lines = fileContent.Split(new char[] {System.Environment.NewLine[0]});
			foreach (string line in lines){
				if (!line.Trim().Equals ("")) {
					ICliqueNodeInstance V, W, temp = null;
					IDictionary<int,ICliqueNodeInstance> referenceV, referenceW = null;

					int[] KEY = new int[2];
					string[] vwID = line.Split (' ');
					for (int k = 0; k < 2; k++) {
						KEY [k] = int.Parse (vwID [k]);
					}
					if (!dictionary.TryGetValue (KEY [0], out referenceV)) {
						IKVPairInstance<IInteger,ICliqueNode> kvpair = (IKVPairInstance<IInteger,ICliqueNode>) Output_data.createItem() ;

						V = (ICliqueNodeInstance)kvpair.Value;
						V.IdInstance = KEY [0];
						((IIntegerInstance)kvpair.Key).Value = V.IdInstance;

						referenceV = new Dictionary<int,ICliqueNodeInstance> ();
						dictionary [KEY [0]] = referenceV;
						referenceV [KEY [0]] = V;

						PAGENODES.Add (kvpair);
					}
					if (!dictionary.TryGetValue (KEY [1], out referenceW)) {
						IKVPairInstance<IInteger,ICliqueNode> kvpair = (IKVPairInstance<IInteger,ICliqueNode>) Output_data.createItem() ;

						W = (ICliqueNodeInstance)kvpair.Value;
						W.IdInstance = KEY [1];
						((IIntegerInstance)kvpair.Key).Value = W.IdInstance;

						referenceW = new Dictionary<int,ICliqueNodeInstance> ();
						dictionary [KEY [1]] = referenceW;
						referenceW [KEY [1]] = W;

						PAGENODES.Add (kvpair);
					}
					if (!referenceV.TryGetValue (KEY [1], out temp)) {
						V = referenceV [KEY [0]];
						W = referenceW [KEY [1]];
						referenceV [KEY [1]] = W;
						V.NeighborsInstance.Add (W.IdInstance);
					}
				}
			}
			IEnumerator<IKVPairInstance<IInteger,ICliqueNode>> iterator = PAGENODES.GetEnumerator();
			while (iterator.MoveNext()) {
				IKVPairInstance<IInteger,ICliqueNode> kvpair = iterator.Current;
				output.put (kvpair);
			}
			output.finish();
		}
	}
}
