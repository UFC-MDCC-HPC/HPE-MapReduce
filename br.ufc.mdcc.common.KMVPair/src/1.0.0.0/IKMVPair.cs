using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.common.KMVPair { 

public interface IKMVPair<K, V> : BaseIKMVPair<K, V>
where K:IData
where V:IData
{


} // end main interface 

} // end namespace 
