/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.user.MapFunction;
using br.ufc.mdcc.farm.Work;

namespace br.ufc.mdcc.mapreduce.Mapper { 

public interface BaseIMapper<M, IMK, IMV> : BaseIWork<M, IMK, IMV>, IComputationKind 
where M:IMapFunction<IMK, IMV>
where IMK:IData
where IMV:IData
{

	IInterator<IData> Output {get;}
	IInterator<IData> Input {get;}


} // end main interface 

} // end namespace 
