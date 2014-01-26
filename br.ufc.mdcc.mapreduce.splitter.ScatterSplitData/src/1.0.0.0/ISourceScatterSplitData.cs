using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.KVPair;

namespace br.ufc.mdcc.mapreduce.splitter.ScatterSplitData { 

	public interface ISourceScatterSplitData<IMK,IMV> : BaseISourceScatterSplitData<IMK,IMV>
		where IMK:IData
		where IMV:IData
	{


	} // end main interface 

} // end namespace 
