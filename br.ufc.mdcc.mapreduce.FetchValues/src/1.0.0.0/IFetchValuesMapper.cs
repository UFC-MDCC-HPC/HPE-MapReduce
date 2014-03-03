using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.mapreduce.user.PartitionFunction;

namespace br.ufc.mdcc.mapreduce.FetchValues { 

	public interface IFetchValuesMapper<P,OMK,OMV> : BaseIFetchValuesMapper<P,OMK,OMV>
		where OMK:IData
		where OMV:IData
		where P:IPartitionFunction<OMK>
{


} // end main interface 

} // end namespace 
