using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.farm.Scatter;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;

namespace br.ufc.mdcc.mapreduce.Splitter { 

	public interface ITargetSplitter<IMK,IMV> : 
	BaseITargetSplitter<IMK,IMV>, IScatterTarget<IIterator<IKVPair<IMK,IMV>>>
		where IMK:IData
		where IMV:IData
{


} // end main interface 

} // end namespace 
