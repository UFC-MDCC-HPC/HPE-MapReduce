/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.KMVPair;

namespace br.ufc.mdcc.common.impl.KMVPairImpl { 

public abstract class BaseIKVMPairImpl<K, V>: DataStructure, BaseIKMVPair<K, V>
where K:IData
where V:IData
{

private IIterator<V> values = null;

protected IIterator<V> Values {
	get {
		if (this.values == null)
			this.values = (IIterator<V>) Services.getPort("values");
		return this.values;
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
