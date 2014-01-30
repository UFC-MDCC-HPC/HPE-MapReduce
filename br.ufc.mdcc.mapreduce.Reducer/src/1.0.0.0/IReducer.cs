using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.user.ReduceFunction;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.farm.Work;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Iterator;

namespace br.ufc.mdcc.mapreduce.Reducer { 

	public interface IReducer<OMK, OMV, ORV, R> : BaseIReducer<OMK, OMV, ORV, R>, 
	IWork<IIterator<IKVPair<OMK,IIterator<OMV>>>,IIterator<ORV>>
where R:IReduceFunction<ORV, OMK, OMV>
where ORV:IData
where OMK:IData
where OMV:IData
{


} // end main interface 

} // end namespace 
