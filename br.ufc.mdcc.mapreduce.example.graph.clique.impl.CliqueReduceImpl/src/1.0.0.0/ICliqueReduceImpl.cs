using System;
using System.Collections.Generic;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.example.graph.clique.CliqueReduce;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.impl.IteratorImpl;
using br.ufc.mdcc.common.impl.IntegerImpl;

namespace br.ufc.mdcc.mapreduce.example.graph.clique.impl.CliqueReduceImpl { 

	public class ICliqueReduceImpl: BaseICliqueReduceImpl, ICliqueReduce{
		public ICliqueReduceImpl() { 

		} 

		private IIterator<IKVPair<IInteger, IIterator<IInteger>>> outputIteratorValues = null;
		private IDictionary<IInteger, IIterator<IInteger>> bigCliques = null;
		private int bigger=0;

		private static IDictionary<int, List<IInteger>> iterators = new Dictionary<int, List<IInteger>> ();

		public override void main() { 
			IDictionary<int, IInteger> P = new Dictionary<int, IInteger>();
			IDictionary<int, IInteger> X = new Dictionary<int, IInteger>();
			IDictionary<int, IIterator<IInteger>> dicValues = pivotKEY(Input_values.Value, Input_values.Key, P, X);

			outputIteratorValues = new IIteratorImpl<IKVPair<IInteger, IIterator<IInteger>>>();
			bigCliques = new Dictionary<IInteger, IIterator<IInteger>>();
			bigger = 0;

			IIterator<IInteger> R = new IIteratorImpl<IInteger>();
			R.put(Input_values.Key);

			bronKerboschAlgorithm(1, dicValues, P, R, X);

			IEnumerator<IInteger> iterator = bigCliques.Keys.GetEnumerator ();
			while (iterator.MoveNext ()) {
				IKVPair<IInteger, IIterator<IInteger>> kv = (IKVPair<IInteger, IIterator<IInteger>>)outputIteratorValues.createItem();
				kv.Key = iterator.Current;
				kv.Value = bigCliques [kv.Key];
			}

			//outputIteratorValues.finish();
			Output_value.Key = Input_values.Key;
			Output_value.Value = outputIteratorValues;
		}
		private IDictionary<int, IIterator<IInteger>> pivotKEY(IIterator<IKVPair<IInteger, IIterator<IInteger>>> iterator, IInteger pivot, IDictionary<int, IInteger> P, IDictionary<int, IInteger> X) {
			IDictionary<int, IIterator<IInteger>> res = new Dictionary<int, IIterator<IInteger>>();
			for (; !iterator.HasFinished; ) {
				IKVPair<IInteger, IIterator<IInteger>> kv = iterator.fetch_next();
				if (pivot.Value < kv.Key.Value)
					P.Add(kv.Key.Value, kv.Key);
				if (pivot.Value > kv.Key.Value)
					X.Add(kv.Key.Value, kv.Key);
				res [kv.Key.Value] = kv.Value;
			}
			return res;
		}
		public void bronKerboschAlgorithm(int SIZE, IDictionary<int, IIterator<IInteger>> dicValues, IDictionary<int, IInteger> P, IIterator<IInteger> R, IDictionary<int, IInteger> X) {
			if (P.Count == 0 && X.Count == 0) {
				IInteger SIZEID = new IIntegerImpl();
				SIZEID.Value = SIZE;
				if (SIZE >= bigger) {
					if (SIZE > bigger) {
						bigCliques.Clear ();
					}
					bigCliques [SIZEID] = R;
					bigger = SIZE;
				} 
				//R.finish();
			}
			while (P.Count>0){
				IEnumerator<IInteger> iteratorPValues = P.Values.GetEnumerator();
				iteratorPValues.MoveNext();
				IInteger v = iteratorPValues.Current;

				IDictionary<int, IInteger> p = new Dictionary<int, IInteger>();
				IDictionary<int, IInteger> x = new Dictionary<int, IInteger>();

				IIterator<IInteger> r = (IIterator<IInteger>)R.clone();
				r.put(v);

				List<IInteger> iterator;
				if (!iterators.TryGetValue (v.Value, out iterator)) {
					IIterator<IInteger> value = dicValues [v.Value];
					iterator = new List<IInteger> ();
					intersect (ref iterator, value, P, X, ref p, ref x);
					iterators [v.Value] = iterator;
				} else {
					intersect2 (iterator, P, X, ref p, ref x);
				}

				bronKerboschAlgorithm(SIZE + 1, dicValues, p, r, x);

				P.Remove(v.Value);
				X.Add(v.Value, v);
			}
		}
		private void intersect(ref List<IInteger> neighbors2, IIterator<IInteger> neighbors, IDictionary<int, IInteger> P, IDictionary<int, IInteger> X, ref IDictionary<int, IInteger> p, ref IDictionary<int, IInteger> x) {
			IIterator<IInteger> iterator = neighbors;
			for (; !iterator.HasFinished; ) {
				IInteger n = iterator.fetch_next();
				if (P.ContainsKey(n.Value)){
					p.Add(n.Value, n);
				}
				if (X.ContainsKey(n.Value)){
					x.Add(n.Value, n);
				}
				neighbors2.Add (n);
			}
		}
		private void intersect2(List<IInteger> neighbors, IDictionary<int, IInteger> P, IDictionary<int, IInteger> X, ref IDictionary<int, IInteger> p, ref IDictionary<int, IInteger> x) {
			IEnumerator<IInteger> iterator = neighbors.GetEnumerator();
			while (iterator.MoveNext()) {
				IInteger n = iterator.Current;
				if (P.ContainsKey(n.Value)){
					p.Add(n.Value, n);
				}
				if (X.ContainsKey(n.Value)){
					x.Add(n.Value, n);
				}
			}
		}
	}
}
