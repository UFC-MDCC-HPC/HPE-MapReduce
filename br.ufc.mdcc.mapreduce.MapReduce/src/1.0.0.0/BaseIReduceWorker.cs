/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.mapreduce.user.ReduceFunction;
using br.ufc.mdcc.common.Platform;

namespace br.ufc.mdcc.mapreduce.MapReduce { 

	public interface BaseIReduceWorker<OMK, OMV, ORV, Rf, PLATFORM> : IComputationKind 
where Rf:IReduceFunction<OMK, OMV, ORV>
where ORV:IData
where OMK:IData
where OMV:IData
where PLATFORM:IPlatform
{



} // end main interface 

} // end namespace 
