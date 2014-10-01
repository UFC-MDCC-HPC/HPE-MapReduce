using System;
using System.Collections.Generic;

namespace graph {
    public interface ITableMapReduce<K, V>{
        void emite(K key, V value);
		IList<V> getList(K key);
		IEnumerator<K> getIteratorKeys ();
		IEnumerator<IList<V>> getIteratorValues ();
		void remove(K key);
    }
}