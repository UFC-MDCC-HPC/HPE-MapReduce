/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.KVPair;

namespace br.ufc.mdcc.mapreduce.FetchValues { 

	public interface BaseIFetchValuesMapper<OMK,OMV> : ISynchronizerKind 
		where OMK:IData
		where OMV:IData
{

		IIterator<IKVPair<OMK,OMV>> Map_result {get;}


} // end main interface 

} // end namespace 
