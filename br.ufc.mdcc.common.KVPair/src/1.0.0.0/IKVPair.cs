using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.common.KVPair { 

public interface IKVPair<K, V> : BaseIKVPair<K, V>
where K:IData
where V:IData
{


} // end main interface 

} // end namespace 
