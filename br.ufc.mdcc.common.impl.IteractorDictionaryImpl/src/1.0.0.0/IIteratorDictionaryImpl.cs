using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.IteratorDictionary;

namespace br.ufc.mdcc.common.impl.IteractorDictionaryImpl { 

public class IIteratorDictionaryImpl<K, V> : BaseIIteratorDictionaryImpl<K, V>, IIteratorDictionary<K, V>
where K:IData
where V:IData
{

public IIteratorDictionaryImpl() { 

} 


}

}
