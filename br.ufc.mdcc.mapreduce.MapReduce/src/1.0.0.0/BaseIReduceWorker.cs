/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.user.ReduceFunction;
using br.ufc.mdcc.common.Platform;

namespace br.ufc.mdcc.mapreduce.MapReduce { 

public interface BaseIReduceWorker<Rf, ORV, OMK, OMV, PLATFORM> : IComputationKind 
where Rf:IReduceFunction<ORV, OMK, OMV>
where ORV:IData
where OMK:IData
where OMV:IData
where PLATFORM:IPlatform
{

	IInterator<IData> Input {get;}


} // end main interface 

} // end namespace 
