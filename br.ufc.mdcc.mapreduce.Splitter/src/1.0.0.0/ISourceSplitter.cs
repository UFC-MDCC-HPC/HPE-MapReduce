using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.farm.Scatter;
using br.ufc.mdcc.mapreduce.user.SplitFunction;
using br.ufc.mdcc.mapreduce.user.PartitionFunction;

namespace br.ufc.mdcc.mapreduce.Splitter { 

	public interface ISourceSplitter<I, IMK, IMV, Sf, Bf> : 
	BaseISourceSplitter<I, IMK, IMV, Sf, Bf>, 
	IScatterSource<I>
		where I:IData
		where IMK:IData
		where IMV:IData
		where Sf:ISplitFunction<I, IMK, IMV>
		where Bf:IPartitionFunction<IMK>
{




} // end main interface 

} // end namespace 
