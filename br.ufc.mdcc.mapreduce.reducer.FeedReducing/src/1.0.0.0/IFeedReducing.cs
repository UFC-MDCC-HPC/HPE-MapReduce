using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.mapreduce.reducer.FeedReducing { 

public interface IFeedReducing<OMV, OMK> : BaseIFeedReducing<OMV, OMK>
where OMV:IData
where OMK:IData
{


} // end main interface 

} // end namespace 
