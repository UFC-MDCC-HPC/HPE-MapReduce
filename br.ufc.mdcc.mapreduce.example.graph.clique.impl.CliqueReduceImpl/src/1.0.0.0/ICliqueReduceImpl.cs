using System;
using System.IO;
using System.Collections.Generic;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.example.graph.clique.CliqueReduce;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;

namespace br.ufc.mdcc.mapreduce.example.graph.clique.impl.CliqueReduceImpl { 

	public class ICliqueReduceImpl : BaseICliqueReduceImpl, ICliqueReduce{

		public ICliqueReduceImpl() { 

		} 
		private IDictionary<int, IList<IIntegerInstance>> bigCliques = null;
		private int bigger=0;
		private IDictionary<int, IList<IIntegerInstance>> iterators = new Dictionary<int, IList<IIntegerInstance>> ();

		public override void main() { 
			//# Starting vars #
			IKVPairInstance<IInteger, IIterator<IKVPair<IInteger, IIterator<IInteger>>>> input_instance = (IKVPairInstance<IInteger,IIterator<IKVPair<IInteger, IIterator<IInteger>>>>) Input_values.Instance;
			IKVPairInstance<IInteger, IIterator<IKVPair<IInteger, IIterator<IInteger>>>> output_instance = (IKVPairInstance<IInteger, IIterator<IKVPair<IInteger, IIterator<IInteger>>>>)Output_value.newInstance ();//.Instance;

			IIntegerInstance input_instance_key = (IIntegerInstance) input_instance.Key;
			IIteratorInstance<IKVPair<IInteger, IIterator<IInteger>>> input_instance_value = (IIteratorInstance<IKVPair<IInteger, IIterator<IInteger>>>) input_instance.Value;

			IIntegerInstance output_instance_key = (IIntegerInstance) output_instance.Key;
			IIteratorInstance<IKVPair<IInteger, IIterator<IInteger>>> output_instance_value = (IIteratorInstance<IKVPair<IInteger, IIterator<IInteger>>>) output_instance.Value;

			IDictionary<int, IIntegerInstance> P = new Dictionary<int, IIntegerInstance>();
			IDictionary<int, IIntegerInstance> X = new Dictionary<int, IIntegerInstance>();
			IDictionary<int, IIteratorInstance<IInteger>> dicValues = pivotKEY(input_instance_value, input_instance_key, P, X);//pivotKEY(Input_values.Value, Input_values.Key, P, X);

			bigCliques = new Dictionary<int, IList<IIntegerInstance>>();
			bigger = 0;

			IList<IIntegerInstance> R = new List<IIntegerInstance>();
			R.Add(input_instance_key);
			//#

			bronKerboschAlgorithm(1, dicValues, P, R, X);//IIteratorInstance<IKVPair<IInteger, IIterator<IInteger>>> orv_value = (IIteratorInstance<IKVPair<IInteger, IIterator<IInteger>>>)Orv_value_factory.Instance;

			IEnumerator<int> iterator = bigCliques.Keys.GetEnumerator ();
			while (iterator.MoveNext ()) {
				IKVPairInstance<IInteger, IIterator<IInteger>> kv = (IKVPairInstance<IInteger, IIterator<IInteger>>)Orv_value_factory.createItem ();
				IIntegerInstance kv_key = ((IIntegerInstance)kv.Key);
				IIteratorInstance<IInteger> kv_value = ((IIteratorInstance<IInteger>)kv.Value);
				kv_key.Value = iterator.Current;
				IEnumerator<IIntegerInstance> enumerator = bigCliques [kv_key.Value].GetEnumerator();
				while (enumerator.MoveNext())
					kv_value.put (enumerator.Current);
				kv_value.finish ();
				output_instance_value.put (kv);
			}
			output_instance_value.finish(); //if (!output_value_instance_value.HasFinished) {//}
			output_instance_key = input_instance_key;//Output_value.Key = Input_values.Key; //output_value_instance.Value = output_value_instance_value;//Output_value.Value = outputIteratorValues;
		}

		private IDictionary<int, IIteratorInstance<IInteger>> pivotKEY(IIteratorInstance<IKVPair<IInteger, IIterator<IInteger>>> input_instance_value, IIntegerInstance pivot, IDictionary<int, IIntegerInstance> P, IDictionary<int, IIntegerInstance> X) {
			IDictionary<int, IIteratorInstance<IInteger>> res = new Dictionary<int, IIteratorInstance<IInteger>>();
			object object_kv;
			while(input_instance_value.fetch_next(out object_kv)){
				IKVPairInstance<IInteger, IIterator<IInteger>> kv = (IKVPairInstance<IInteger, IIterator<IInteger>>) object_kv;
				if (pivot.Value < ((IIntegerInstance)kv.Key).Value)
					P.Add(((IIntegerInstance)kv.Key).Value, ((IIntegerInstance)kv.Key));
				if (pivot.Value > ((IIntegerInstance)kv.Key).Value)
					X.Add(((IIntegerInstance)kv.Key).Value, ((IIntegerInstance)kv.Key));
				res [((IIntegerInstance)kv.Key).Value] = ((IIteratorInstance<IInteger>) kv.Value);
			}
			return res;
		}
		public void bronKerboschAlgorithm(int SIZE, IDictionary<int, IIteratorInstance<IInteger>> dicValues, IDictionary<int, IIntegerInstance> P, IList<IIntegerInstance> R, IDictionary<int, IIntegerInstance> X) {
			if (P.Count == 0 && X.Count == 0) {
				if (SIZE >= bigger) {
					if (SIZE > bigger)
						bigCliques.Clear ();
					bigCliques [SIZE] = R;
					bigger = SIZE;
				} 
			}
			while (P.Count>0){
				IEnumerator<IIntegerInstance> iteratorPValues = P.Values.GetEnumerator();
				iteratorPValues.MoveNext();
				IIntegerInstance v = iteratorPValues.Current;

				IDictionary<int, IIntegerInstance> p = new Dictionary<int, IIntegerInstance>();
				IDictionary<int, IIntegerInstance> x = new Dictionary<int, IIntegerInstance>();

				IList<IIntegerInstance> r = new List<IIntegerInstance>(R);//CreateClone (R);//R.clone();
				r.Add(v);

				IList<IIntegerInstance> iterator;
				if (!iterators.TryGetValue (v.Value, out iterator)) {
					IIteratorInstance<IInteger> value = dicValues [v.Value];
					iterator = new List<IIntegerInstance> ();
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
		private void intersect(ref IList<IIntegerInstance> neighbors2, IIteratorInstance<IInteger> neighbors, IDictionary<int, IIntegerInstance> P, IDictionary<int, IIntegerInstance> X, ref IDictionary<int, IIntegerInstance> p, ref IDictionary<int, IIntegerInstance> x) {
			IIteratorInstance<IInteger> iterator = neighbors;
			object o;
			while(iterator.fetch_next(out o)){
				IIntegerInstance n = (IIntegerInstance)o;
				if (P.ContainsKey(n.Value)){
					p.Add(n.Value, n);
				}
				if (X.ContainsKey(n.Value)){
					x.Add(n.Value, n);
				}
				neighbors2.Add (n);
			}
		}
		private void intersect2(IList<IIntegerInstance> neighbors, IDictionary<int, IIntegerInstance> P, IDictionary<int, IIntegerInstance> X, ref IDictionary<int, IIntegerInstance> p, ref IDictionary<int, IIntegerInstance> x) {
			IEnumerator<IIntegerInstance> iterator = neighbors.GetEnumerator();
			while (iterator.MoveNext()) {
				IIntegerInstance n = iterator.Current;
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
