using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.mapreduce.user.ReduceFunction { 

public interface IReduceFunction<OMK, OMV, ORV> : BaseIReduceFunction<OMK, OMV, ORV>
where OMK:IData
where OMV:IData
where ORV:IData
{


} // end main interface 

} // end namespace 
