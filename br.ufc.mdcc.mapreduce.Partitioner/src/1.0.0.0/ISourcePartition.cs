using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.mapreduce.user.PartitionFunction;
using br.ufc.mdcc.farm.Gather;

namespace br.ufc.mdcc.mapreduce.Partitioner { 

	public interface ISourcePartition<OPK, OMK, OMV, P> : 
	BaseISourcePartition<OPK, OMK, OMV, P>, IGatherSource<IIterator<IKVPair<OMK,OMV>>>
where OPK:IData
where OMK:IData
where OMV:IData
where P:IPartitionFunction<OMK, OPK>
{


} // end main interface 

} // end namespace 
