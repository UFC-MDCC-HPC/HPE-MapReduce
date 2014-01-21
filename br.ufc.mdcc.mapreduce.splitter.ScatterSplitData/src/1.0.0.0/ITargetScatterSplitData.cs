using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.mapreduce.splitter.ScatterSplitData { 

	public interface ITargetScatterSplitData<IMK,IMV> : BaseITargetScatterSplitData<IMK,IMV>
		where IMK:IData
		where IMV:IData
{


} // end main interface 

} // end namespace 
