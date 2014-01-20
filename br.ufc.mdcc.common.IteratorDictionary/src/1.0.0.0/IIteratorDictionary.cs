using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.common.IteratorDictionary { 

public interface IIteratorDictionary<K, V> : BaseIIteratorDictionary<K, V>
where K:IData
where V:IData
{


} // end main interface 

} // end namespace 
