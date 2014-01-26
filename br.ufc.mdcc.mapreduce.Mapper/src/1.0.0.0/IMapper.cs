using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.user.MapFunction;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.farm.Work;

namespace br.ufc.mdcc.mapreduce.Mapper { 

	public interface IMapper<IMK, IMV, OMK, OMV, M> : 
	BaseIMapper<IMK, IMV, OMK, OMV, M>, 
	IWork<IIterator<IKVPair<IMK,IMV>>,IIterator<IKVPair<OMK,OMV>>>
		where IMK:IData
		where IMV:IData
		where OMK:IData
		where OMV:IData
		where M:IMapFunction<IMK, IMV, OMK, OMV>
{


} // end main interface 

} // end namespace 
