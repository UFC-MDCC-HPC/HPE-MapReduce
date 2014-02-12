/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.common.KVPair { 

public interface BaseIKVPair<K, V> : BaseIData, IDataStructureKind 
where K:IData
where V:IData
{
		K Key {get;}
		V Value {get;}

} // end main interface 

} // end namespace 
