/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Integer;

namespace br.ufc.mdcc.mapreduce.user.PartitionFunction { 

public interface BaseIPartitionFunction<OMK> : IComputationKind 
where OMK:IData
{

	IInteger Output_key {get;}
	OMK Input_key {get;}


} // end main interface 

} // end namespace 
