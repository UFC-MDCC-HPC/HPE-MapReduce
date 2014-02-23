using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.KVPair;

namespace br.ufc.mdcc.mapreduce.FetchValues { 

	public interface IFetchValuesReducer<OMK,OMV> : BaseIFetchValuesReducer<OMK,OMV>
		where OMK:IData
		where OMV:IData
{


} // end main interface 

} // end namespace 
