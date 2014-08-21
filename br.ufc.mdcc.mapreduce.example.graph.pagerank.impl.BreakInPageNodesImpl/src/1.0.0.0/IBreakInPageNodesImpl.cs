using System;
using System.Collections.Generic;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PageNode;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.BreakInPageNodes;

namespace br.ufc.mdcc.mapreduce.example.graph.pagerank.impl.BreakInPageNodesImpl { 
	public class IBreakInPageNodesImpl : BaseIBreakInPageNodesImpl, IBreakInPageNodes{
	   
		public IBreakInPageNodesImpl() { } 

		public override void main() { 
			createPageNodes(((IStringInstance) Input_data.Instance).Value);
		}
		private void createPageNodes(string fileContent){
			IIteratorInstance<IKVPair<IInteger, IPageNode>> output = (IIteratorInstance<IKVPair<IInteger, IPageNode>>) Output_data.Instance;
			IDictionary<int, IDictionary<int,IPageNodeInstance>> dictionary = new Dictionary<int, IDictionary<int,IPageNodeInstance>>();

			IList<IKVPairInstance<IInteger,IPageNode>> PAGENODES = new List<IKVPairInstance<IInteger,IPageNode>>();

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
					if (!dictionary.TryGetValue (KEY [0], out referenceV)) {
						IKVPairInstance<IInteger,IPageNode> kvpair = (IKVPairInstance<IInteger,IPageNode>) Output_data.createItem() ;

						V = (IPageNodeInstance)kvpair.Value;
						V.IdInstance = KEY [0];
						((IIntegerInstance)kvpair.Key).Value = V.IdInstance;

						referenceV = new Dictionary<int,IPageNodeInstance> ();
						dictionary [KEY [0]] = referenceV;
						referenceV [KEY [0]] = V;

						PAGENODES.Add (kvpair);
					}
					if (!dictionary.TryGetValue (KEY [1], out referenceW)) {
						IKVPairInstance<IInteger,IPageNode> kvpair = (IKVPairInstance<IInteger,IPageNode>) Output_data.createItem() ;

						W = (IPageNodeInstance)kvpair.Value;
						W.IdInstance = KEY [1];
						((IIntegerInstance)kvpair.Key).Value = W.IdInstance;

						referenceW = new Dictionary<int,IPageNodeInstance> ();
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
			IEnumerator<IKVPairInstance<IInteger,IPageNode>> iterator = PAGENODES.GetEnumerator();
			while (iterator.MoveNext()) {
				IKVPairInstance<IInteger,IPageNode> kvpair = iterator.Current;
				output.put (kvpair);
			}
			output.finish();
		}
	}
}
