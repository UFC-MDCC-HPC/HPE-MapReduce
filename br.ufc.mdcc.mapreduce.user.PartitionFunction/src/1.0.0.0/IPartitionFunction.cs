using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.mapreduce.user.PartitionFunction { 

	public interface IPartitionFunction<OMK> : BaseIPartitionFunction<OMK>
	where OMK:IData
	{
		int NumberOfPartitions {set; get;}

	} // end main interface 

} // end namespace 
