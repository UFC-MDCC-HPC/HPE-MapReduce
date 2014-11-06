using System;
using System.Collections.Generic;
using System.IO;
using System.Collections.Generic;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.mapreduce.example.graph.clique.CliqueNode;
using br.ufc.mdcc.mapreduce.example.graph.clique.CliqueReduce;

namespace br.ufc.mdcc.mapreduce.example.graph.clique.impl.CliqueReduceImpl { 

	public class ICliqueReduceImpl : BaseICliqueReduceImpl, ICliqueReduce{

		private IList<IList<int>> bigCliques = null;
		private int bigger=0;
		private int count = 0;

		public override void main() {
			count = 0;
			IKVPairInstance<IString, IIterator<ICliqueNode>> input = (IKVPairInstance<IString, IIterator<ICliqueNode>>) Input_values.Instance;
			IStringInstance pivot = (IStringInstance)input.Key;
			IIteratorInstance<ICliqueNode> input_value = (IIteratorInstance<ICliqueNode>)input.Value;

			bigCliques = new List<IList<int>> ();
			bigger=0;

			HashSet<int> upper = new HashSet<int>();
			HashSet<int> lower = new HashSet<int>();

			IDictionary<int, IList<int>> dicValues = splitting_In_Left_Pivot_Right(input_value, pivot.Value, upper, lower);

			IList<int> R = new List<int>();
			R.Add(int.Parse(pivot.Value));

			bronKerboschAlgorithm(1, dicValues, upper, R, lower);

			//if (count > 0) {
				IKVPairInstance<IString,ICliqueNode> kvpair = (IKVPairInstance<IString,ICliqueNode>)Output_value.newInstance ();
				((IStringInstance)kvpair.Key).Value = pivot.Value;
				((ICliqueNodeInstance)kvpair.Value).IdInstance = count; //bigCliques [0].Count;
				//((ICliqueNodeInstance)kvpair.Value).NeighborsInstance = bigCliques [0];
			//} else {
			//	IKVPairInstance<IString,ICliqueNode> kvpair = (IKVPairInstance<IString,ICliqueNode>)Output_value.newInstance ();
			//	((IStringInstance)kvpair.Key).Value = pivot.Value;
			//	((ICliqueNodeInstance)kvpair.Value).IdInstance = 0;
			//}
		}

		private IDictionary<int, IList<int>> splitting_In_Left_Pivot_Right(IIteratorInstance<ICliqueNode> input_instance_value, string pivot, HashSet<int> P, HashSet<int> X) {
			IDictionary<int, IList<int>> res = new Dictionary<int, IList<int>>();
			int pivot_number = int.Parse (pivot);
			object o;

			//Debug Block start
//			string saida = "TaskRank="+this.Rank+" Chave="+pivot+" {"+System.Environment.NewLine;
			//Debug Block end

			while(input_instance_value.fetch_next(out o)){
				ICliqueNodeInstance node_instance = (ICliqueNodeInstance)o;
				if (pivot_number < node_instance.IdInstance)
					P.Add (node_instance.IdInstance);
				if (pivot_number > node_instance.IdInstance)
					X.Add (node_instance.IdInstance);
				res [node_instance.IdInstance] = node_instance.NeighborsInstance;

				//Debug Block start
//					saida = saida+"<"+node_instance.IdInstance+", [";
//					IEnumerator<int> neighbor = node_instance.NeighborsInstance.GetEnumerator ();
//					while (neighbor.MoveNext ()) {
//						saida = saida + neighbor.Current + " ";
//					}
//					saida = saida + "]>"+System.Environment.NewLine;
				//Debug Block end
			}
//			saida = saida + "}"+System.Environment.NewLine;
//			using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"./logCliqueReduce"+Rank, true)){
//				file.WriteLine(saida);
//			}
			return res;
		}

		public void bronKerboschAlgorithm(int SIZE, IDictionary<int, IList<int>> dicValues, HashSet<int> P, IList<int> R, HashSet<int> X) {
			if (P.Count == 0 && X.Count == 0) {
				string saida = "";
				foreach (int i in R)
					saida = saida + i + " ";
				writeFile ("./logCliques"+Rank, saida);
				count++;
				//bigCliques.Add (R);
			}
			while (P.Count>0){
				IEnumerator<int> iteratorPValues = P.GetEnumerator();
				iteratorPValues.MoveNext();
				int v = iteratorPValues.Current;

				HashSet<int> p = new HashSet<int>();
				HashSet<int> x = new HashSet<int>();

				IList<int> r = new List<int>(R);
				r.Add(v);

				intersect (dicValues [v], P, X, ref p, ref x);

				bronKerboschAlgorithm(SIZE + 1, dicValues, p, r, x);

				P.Remove(v);
				X.Add(v);
			}
		}

		private void intersect(IList<int> neighbors, HashSet<int> P, HashSet<int> X, ref HashSet<int> p, ref HashSet<int> x) {
			IEnumerator<int> iterator = neighbors.GetEnumerator();
			while (iterator.MoveNext()) {
				int n = iterator.Current;
				if (P.Contains(n)){
					p.Add(n);
				}
				if (X.Contains(n)){
					x.Add(n);
				}
			}
		}
		public static void writeFile(string PATH, string saida){
			using (System.IO.StreamWriter file = new System.IO.StreamWriter(@PATH, true)){
				file.WriteLine(saida);
			}
		}
	}
}
