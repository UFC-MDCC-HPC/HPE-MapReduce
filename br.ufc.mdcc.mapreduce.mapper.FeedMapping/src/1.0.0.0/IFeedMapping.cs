using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.mapreduce.mapper.FeedMapping { 

public interface IFeedMapping<IMV, IMK> : BaseIFeedMapping<IMV, IMK>
where IMV:IData
where IMK:IData
{


} // end main interface 

} // end namespace 
