using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.KMVPair;

namespace br.ufc.mdcc.common.impl.KMVPairImpl { 

public class IKVMPairImpl<K, V> : BaseIKVMPairImpl<K, V>, IKMVPair<K, V>
where K:IData
where V:IData
{

public IKVMPairImpl() { 

} 


}

}
