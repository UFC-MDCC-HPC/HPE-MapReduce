/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.IteratorDictionary;

namespace br.ufc.mdcc.mapreduce.partitioner.FeedPartitioning { 

public interface BaseIFeedPartitioning<OMK, OPK, OMV> : IComputationKind 
where OMK:IData
where OPK:IData
where OMV:IData
{

	OPK Data_partition {get;}
	IIteratorDictionary<OMK, OPK> Partition_info {get;}
	OMK ? {get;}
	IIteratorDictionary<OMK, OMV> Data {get;}


} // end main interface 

} // end namespace 
