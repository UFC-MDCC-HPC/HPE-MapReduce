using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.mapreduce.partitioner.FeedPartitioning { 

	public interface IFeedPartitioning<OMK, OPK, OMV> : BaseIFeedPartitioning<OMK, OPK, OMV>
		where OPK:IData
		where OMK:IData
		where OMV:IData
{


} // end main interface 

} // end namespace 
