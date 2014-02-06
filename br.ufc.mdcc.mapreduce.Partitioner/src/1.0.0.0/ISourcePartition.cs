using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.mapreduce.user.PartitionFunction;
using br.ufc.mdcc.farm.Gather;

namespace br.ufc.mdcc.mapreduce.Partitioner { 

	public interface ISourcePartition<OMK, OMV, P> : 
	BaseISourcePartition<OMK, OMV, P>, IGatherSource<IIterator<IKVPair<OMK,OMV>>>
where OMK:IData
where OMV:IData
where P:IPartitionFunction<OMK>
{


} // end main interface 

} // end namespace 
