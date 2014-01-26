/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.IteratorDictionary;

namespace br.ufc.mdcc.common.impl.IteractorDictionaryImpl { 

public abstract class BaseIIteratorDictionaryImpl<K, V>: DataStructure, BaseIIteratorDictionary<K, V>
where K:IData
where V:IData
{

private V value = default(V);

protected V Value {
	get {
		if (this.value == null)
			this.value = (V) Services.getPort("value");
		return this.value;
	}
}

private K key = default(K);

protected K Key {
	get {
		if (this.key == null)
			this.key = (K) Services.getPort("key");
		return this.key;
	}
}



}

}
