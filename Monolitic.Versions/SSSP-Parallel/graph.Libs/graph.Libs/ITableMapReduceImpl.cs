using System;
using System.Collections.Generic;

namespace graph {
	public class ITableMapReduceImpl<K, V>: ITableMapReduce<K,V>{

		private IDictionary<K, IList<V>> data = new Dictionary<K, IList<V>>();
        
		public void emite(K key, V value) {
			IList<V> list = getList (key);
			list.Add (value);
        }
		public IList<V> getList(K key){
			IList<V> list;
			if (!data.TryGetValue (key, out list)) {
				list = new List<V> ();
				data [key] = list;
			}
			return list;
        }
//        private V instanceOfValue() {
//            try {
//                V v = (V)Activator.CreateInstance(typeof(V));
//                return v;
//            }
//            catch (Exception e) {
//				Console.WriteLine("{0} Can't create instance Exception.", e);
//				return default(V);
//            }
//        }
		public IEnumerator<K> getIteratorKeys() {
			IEnumerator<K> iterator = data.Keys.GetEnumerator();
			return iterator;
		}
		public IEnumerator<IList<V>> getIteratorValues() {
			return data.Values.GetEnumerator();
		}
		public void remove(K key) {
			data.Remove(key);
		}
    }
}