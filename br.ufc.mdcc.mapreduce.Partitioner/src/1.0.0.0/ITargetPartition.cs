using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.farm.Gather;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;

namespace br.ufc.mdcc.mapreduce.Partitioner { 

	public interface ITargetPartition<OMK, OPK> : 
	BaseITargetPartition<OMK,OPK>, IGatherTarget<IIterator<IKVPair<OMK,OPK>>>
		where OPK:IData
		where OMK:IData
{


} // end main interface 

} // end namespace 
