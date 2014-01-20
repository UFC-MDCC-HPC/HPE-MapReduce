using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.user.PartitionFunction;
using br.ufc.mdcc.mapreduce.user.MapFunction;
using br.ufc.mdcc.common.Platform;

namespace br.ufc.mdcc.mapreduce.MapReduce { 

public interface IMapWorker<OPK, OMK, Pf, Mf, IMK, IMV, PLATFORM> : BaseIMapWorker<OPK, OMK, Pf, Mf, IMK, IMV, PLATFORM>
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
