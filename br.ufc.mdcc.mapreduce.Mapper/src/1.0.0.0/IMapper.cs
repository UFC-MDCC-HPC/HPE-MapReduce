using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.user.MapFunction;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.farm.Work;

namespace br.ufc.mdcc.mapreduce.Mapper { 

public interface IMapper<M, IMK, IMV> : BaseIMapper<M, IMK, IMV>, IWork<M, IMK, IMV>
where M:IMapFunction<IMK, IMV>
where IMK:IData
where IMV:IData
{


} // end main interface 

} // end namespace 
