using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.mapreduce.user.MapFunction { 

	public interface IMapFunction<IMK, IMV, OMK, OMV> : BaseIMapFunction<IMK, IMV, OMK, OMV>
		where IMK:IData
		where IMV:IData
		where OMK:IData
		where OMV:IData
{


} // end main interface 

} // end namespace 
