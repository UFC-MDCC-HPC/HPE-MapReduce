/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;

namespace br.ufc.mdcc.mapreduce.partitioner.FeedPartitioning { 

public interface BaseIFeedPartitioning<OPK, OMK> : IComputationKind 
where OPK:IData
where OMK:IData
{

	OPK Partition_key {get;}
	IIterator<IIterator<IKVPair<OMK,OPK>>> Partition_info {get;}
	IIterator<IIterator<IKVPair<OMK,OPK>>> Data {get;}
	OMK Data_key {get;}


} // end main interface 

} // end namespace 
