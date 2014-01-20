using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.mapreduce.user.PartitionFunction { 

public interface IPartitionFunction<OMK, OPK> : BaseIPartitionFunction<OMK, OPK>
where OMK:IData
where OPK:IData
{


} // end main interface 

} // end namespace 
