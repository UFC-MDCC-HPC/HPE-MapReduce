/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.mapreduce.user.PartitionFunction;
using br.ufc.mdcc.mapreduce.user.MapFunction;
using br.ufc.mdcc.common.Platform;

namespace br.ufc.mdcc.mapreduce.MapReduce { 

public interface BaseIMapWorker<OPK, OMK, Pf, Mf, IMK, IMV, PLATFORM> : IComputationKind 
where OPK:IData
where OMK:IData
where Pf:IPartitionFunction<OMK, OPK>
where Mf:IMapFunction<IMK, IMV>
where IMK:IData
where IMV:IData
where PLATFORM:IPlatform
{


} // end main interface 

} // end namespace 
