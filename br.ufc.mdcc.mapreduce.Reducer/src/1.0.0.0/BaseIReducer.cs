/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.user.ReduceFunction;
using br.ufc.mdcc.farm.Work;
using br.ufc.mdcc.common.KVPair;

namespace br.ufc.mdcc.mapreduce.Reducer { 

	public interface BaseIReducer<OMK, OMV, ORV, R> : 
	BaseIWork<IIterator<IKVPair<OMK,IIterator<OMV>>>,IIterator<ORV>>, IComputationKind 
		where R:IReduceFunction<OMK, OMV, ORV>	
		where ORV:IData
		where OMK:IData
		where OMV:IData
{

		// BUG: Já são herdados de BaseIWork (esse código não deveria ter sido gerado)
		//IIterator<IKMVPair<OMK,OMV>> Input {get;}
		//IIterator<IIterator<ORV>> Output {get;}


} // end main interface 

} // end namespace 
