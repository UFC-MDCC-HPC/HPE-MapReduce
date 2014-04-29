/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.mapreduce.user.PartitionFunction;

namespace br.ufc.mdcc.mapreduce.FetchValues { 

	public interface BaseIFetchValuesMapper<OMK,OMV,P> : ISynchronizerKind 
		where OMK:IData
		where OMV:IData
		where P:IPartitionFunction<OMK>
{

		IIterator<IKVPair<OMK,OMV>> Map_result {get;}


} // end main interface 

} // end namespace 
