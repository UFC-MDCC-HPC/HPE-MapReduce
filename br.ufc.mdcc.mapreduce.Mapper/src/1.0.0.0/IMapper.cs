using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.user.MapFunction;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.farm.Work;

namespace br.ufc.mdcc.mapreduce.Mapper { 

public interface IMapper<M, IMK, IMV, OMK, OMV> : 
	BaseIMapper<M, IMK, IMV,OMK,OMV>, 
	IWork<IIterator<IKVPair<IMK,IMV>>,IIterator<IKVPair<OMK,OMV>>>
		where M:IMapFunction<IMK, IMV, OMK, OMV>
		where IMK:IData
		where IMV:IData
		where OMK:IData
		where OMV:IData
{


} // end main interface 

} // end namespace 
