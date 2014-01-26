using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.farm.Scatter;
using br.ufc.mdcc.mapreduce.user.SplitFunction;

namespace br.ufc.mdcc.mapreduce.Splitter { 

	public interface ISourceSplitter<I, IMK, IMV, Sf> : 
	BaseISourceSplitter<I, IMK, IMV, Sf>, 
	IScatterSource<I>
		where I:IData
		where IMK:IData
		where IMV:IData
		where Sf:ISplitFunction<I, IMK, IMV>
{


} // end main interface 

} // end namespace 
