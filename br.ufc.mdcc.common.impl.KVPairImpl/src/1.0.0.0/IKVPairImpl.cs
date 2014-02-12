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

		public IKVPairImpl() { 

		} 

		void IData.readFrom (IData o)
		{
			IKVPair<K,V> okv = (IKVPair<K,V>)o;
			this.Key.readFrom(okv.Key);
			this.Value.readFrom(okv.Value);
		}
}

}
