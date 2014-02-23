/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.KVPair;

namespace br.ufc.mdcc.mapreduce.FetchValues { 

	public interface BaseIFetchValuesReducer<OMK,OMV> : ISynchronizerKind 
		where OMK:IData
		where OMV:IData
{

		IIterator<IKVPair<OMK,IIterator<OMV>>> Reduce_job {get;}


} // end main interface 

} // end namespace 
