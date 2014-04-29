using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.mapreduce.user.PartitionFunction;

namespace br.ufc.mdcc.mapreduce.splitter.ScatterSplitData { 

	public interface ISourceScatterSplitData<IMK,IMV,Bf> : BaseISourceScatterSplitData<IMK,IMV,Bf>
		where IMK:IData
		where IMV:IData
		where Bf:IPartitionFunction<IMK>
	{


	} // end main interface 

} // end namespace 
