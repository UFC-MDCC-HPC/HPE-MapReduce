using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.mapreduce.partitioner.FeedPartitioning { 

public interface IFeedPartitioning<OPK, OMK> : BaseIFeedPartitioning<OPK, OMK>
where OPK:IData
where OMK:IData
{


} // end main interface 

} // end namespace 
