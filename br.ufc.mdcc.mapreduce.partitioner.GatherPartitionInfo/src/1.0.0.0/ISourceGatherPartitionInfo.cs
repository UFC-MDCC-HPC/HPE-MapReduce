using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.farm.Gather;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;

namespace br.ufc.mdcc.mapreduce.partitioner.GatherPartitionInfo { 

public interface ISourceGatherPartitionInfo<OPK,OMK> : 
	BaseISourceGatherPartitionInfo<OPK,OMK>, 
	IGatherSource<IIterator<IKVPair<OMK,OPK>>>
where OPK:IData
where OMK:IData
{


} // end main interface 

} // end namespace 
