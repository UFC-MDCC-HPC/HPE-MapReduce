/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.farm.Gather;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;

namespace br.ufc.mdcc.mapreduce.Partitioner { 

	public interface BaseITargetPartition<OMK> : 
	BaseIGatherTarget<IIterator<IKVPair<OMK, IInteger>>>, ISynchronizerKind 
	where OMK:IData
{



} // end main interface 

} // end namespace 
