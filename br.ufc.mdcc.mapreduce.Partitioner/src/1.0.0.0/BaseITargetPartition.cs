/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.farm.Gather;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.mapreduce.user.PartitionFunction;

namespace br.ufc.mdcc.mapreduce.Partitioner { 

public interface BaseITargetPartition<OPK, OMK> : 
	BaseIGatherTarget<IIterator<IKVPair<OMK,OPK>>>, ISynchronizerKind 
	where OPK:IData
	where OMK:IData
{



} // end main interface 

} // end namespace 
