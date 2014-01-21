/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.user.ReduceFunction;
using br.ufc.mdcc.farm.Work;
using br.ufc.mdcc.common.KMVPair;

namespace br.ufc.mdcc.mapreduce.Reducer { 

public interface BaseIReducer<R, ORV, OMK, OMV> : 
	BaseIWork<IIterator<IKMVPair<OMK,OMV>>,IIterator<ORV>>, IComputationKind 
		where R:IReduceFunction<ORV, OMK, OMV>	
where ORV:IData
where OMK:IData
where OMV:IData
{

		// BUG: Já são herdados de BaseIWork (esse código não deveria ter sido gerado)
		//IIterator<IKMVPair<OMK,OMV>> Input {get;}
		//IIterator<IIterator<ORV>> Output {get;}


} // end main interface 

} // end namespace 
