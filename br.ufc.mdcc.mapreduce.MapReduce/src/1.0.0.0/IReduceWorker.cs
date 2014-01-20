using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.user.ReduceFunction;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Platform;

namespace br.ufc.mdcc.mapreduce.MapReduce { 

public interface IReduceWorker<Rf, ORV, OMK, OMV, PLATFORM> : BaseIReduceWorker<Rf, ORV, OMK, OMV, PLATFORM>
where Rf:IReduceFunction<ORV, OMK, OMV>
where ORV:IData
where OMK:IData
where OMV:IData
where PLATFORM:IPlatform
{


} // end main interface 

} // end namespace 
