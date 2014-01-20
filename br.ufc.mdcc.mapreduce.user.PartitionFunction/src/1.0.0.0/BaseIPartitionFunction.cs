/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.mapreduce.user.PartitionFunction { 

public interface BaseIPartitionFunction<OMK, OPK> : IComputationKind 
where OMK:IData
where OPK:IData
{

	OPK Output_key {get;}
	OMK Input_key {get;}


} // end main interface 

} // end namespace 
