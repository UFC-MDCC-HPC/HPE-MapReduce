using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.user.PartitionFunction;
using br.ufc.mdcc.farm.Gather;

namespace br.ufc.mdcc.mapreduce.Partitioner { 

public interface ISourcePartition<OPK, OMK, P> : BaseISourcePartition<OPK, OMK, P>, ISource<OPK, OMK, P>
where OPK:IData
where OMK:IData
where P:IPartitionFunction<OMK, OPK>
{


} // end main interface 

} // end namespace 
