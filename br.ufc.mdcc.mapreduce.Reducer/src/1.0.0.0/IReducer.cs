using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.user.ReduceFunction;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.farm.Work;
using br.ufc.mdcc.common.KMVPair;
using br.ufc.mdcc.common.Iterator;

namespace br.ufc.mdcc.mapreduce.Reducer { 

public interface IReducer<R, ORV, OMK, OMV> : BaseIReducer<R, ORV, OMK, OMV>, 
	IWork<IIterator<IKMVPair<OMK,OMV>>,IIterator<ORV>>
where R:IReduceFunction<ORV, OMK, OMV>
where ORV:IData
where OMK:IData
where OMV:IData
{


} // end main interface 

} // end namespace 
