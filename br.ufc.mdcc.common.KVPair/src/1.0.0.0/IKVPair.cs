using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.common.KVPair { 

public interface IKVPair<K, V> : IData, BaseIKVPair<K, V>
where K:IData
where V:IData
{
	
		K Key { get; set;}
		V Value { get; set;}

} // end main interface 

} // end namespace 
