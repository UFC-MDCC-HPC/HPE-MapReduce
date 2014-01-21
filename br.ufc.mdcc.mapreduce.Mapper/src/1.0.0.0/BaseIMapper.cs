/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.mapreduce.user.MapFunction;
using br.ufc.mdcc.farm.Work;

namespace br.ufc.mdcc.mapreduce.Mapper { 

public interface BaseIMapper<M, IMK, IMV, OMK, OMV> : 
	BaseIWork<IIterator<IKVPair<IMK,IMV>>,IIterator<IKVPair<OMK,OMV>>>, 
	IComputationKind 
	where M:IMapFunction<IMK, IMV, OMK, OMV>
where IMK:IData
where IMV:IData
where OMK:IData
where OMV:IData
{
	IIterator<IKVPair<IMK,IMV>> Output {get;}
	IIterator<IKVPair<OMK,OMV>> Input  {get;}
} // end main interface 

} // end namespace 
