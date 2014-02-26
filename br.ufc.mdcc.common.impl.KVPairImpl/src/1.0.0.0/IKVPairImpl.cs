using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.KVPair;

namespace br.ufc.mdcc.common.impl.KVPairImpl { 

public class IKVPairImpl<K, V> : BaseIKVPairImpl<K, V>, IKVPair<K, V>
where K:IData
where V:IData
{

		public IKVPairImpl() 
		{ 

		} 

		private V value = default(V);
		public V Value { get {return this.value; } set { this.value = value; }}

		private K key = default(K);
		public K Key { get { return this.key; } set { this.key = value; } }

		public void loadFrom (IData o)
		{
			IKVPair<K,V> okv = (IKVPair<K,V>)o;
			this.Key.loadFrom(okv.Key);
			this.Value.loadFrom(okv.Value);
		}

		public IData newInstance()
		{
			return new IKVPairImpl<K,V>();
		}

		public IData clone ()
		{
			IData instance = newInstance();
			instance.loadFrom(this);
			return instance;
		}
}

}
