using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.mapreduce.user.MapFunction { 

public interface IMapFunction<IMK, IMV> : BaseIMapFunction<IMK, IMV>
where IMK:IData
where IMV:IData
{


} // end main interface 

} // end namespace 
