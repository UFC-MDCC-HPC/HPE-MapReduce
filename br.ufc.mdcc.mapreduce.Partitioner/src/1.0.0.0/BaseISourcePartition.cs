/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.mapreduce.user.PartitionFunction;
using br.ufc.mdcc.farm.Gather;
using br.ufc.mdcc.common.KVPair;

namespace br.ufc.mdcc.mapreduce.Partitioner { 

	public interface BaseISourcePartition<OMK, OMV, P> : 
	BaseIGatherSource<IIterator<IKVPair<OMK,OMV>>>, ISynchronizerKind 
where OMK:IData
where OMV:IData
where P:IPartitionFunction<OMK>
{

		//IIterator<IKVPair<OMK,OMV>> Source_data {get;}


} // end main interface 

} // end namespace 
