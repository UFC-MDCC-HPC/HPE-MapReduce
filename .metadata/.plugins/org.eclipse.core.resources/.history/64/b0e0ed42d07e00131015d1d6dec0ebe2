using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.user.ReduceFunction;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.farm.Work;

namespace br.ufc.mdcc.mapreduce.Reducer { 

public interface IReducer<R, ORV, OMK, OMV> : BaseIReducer<R, ORV, OMK, OMV>, IWork<R, ORV, OMK, OMV>
where R:IReduceFunction<ORV, OMK, OMV>
where ORV:IData
where OMK:IData
where OMV:IData
{


} // end main interface 

} // end namespace 
