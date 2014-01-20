/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.user.ReduceFunction;
using br.ufc.mdcc.farm.Work;

namespace br.ufc.mdcc.mapreduce.Reducer { 

public interface BaseIReducer<R, ORV, OMK, OMV> : BaseIWork<R, ORV, OMK, OMV>, IComputationKind 
where R:IReduceFunction<ORV, OMK, OMV>
where ORV:IData
where OMK:IData
where OMV:IData
{

	IInterator<IData> Input {get;}
	IInterator<ORV> Output {get;}


} // end main interface 

} // end namespace 
