/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.mapreduce.user.PartitionFunction;
using br.ufc.mdcc.farm.Gather;

namespace br.ufc.mdcc.mapreduce.Partitioner { 

public interface BaseISourcePartition<OPK, OMK, P> : BaseISource<OPK, OMK, P>, ISynchronizerKind 
where OPK:IData
where OMK:IData
where P:IPartitionFunction<OMK, OPK>
{

	IInterator<IData> Source_data {get;}


} // end main interface 

} // end namespace 
