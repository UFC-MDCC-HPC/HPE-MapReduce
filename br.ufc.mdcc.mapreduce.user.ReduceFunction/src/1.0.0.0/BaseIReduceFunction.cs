/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.KMVPair;


namespace br.ufc.mdcc.mapreduce.user.ReduceFunction { 

public interface BaseIReduceFunction<OMK, OMV, ORV> : IComputationKind 
where OMK:IData
where OMV:IData
where ORV:IData
{

	IKMVPair<OMK,OMV> Input_values {get;}
	ORV Output_value {get;}


} // end main interface 

} // end namespace 
