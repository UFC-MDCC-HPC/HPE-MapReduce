/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.farm.Scatter;
using br.ufc.mdcc.mapreduce.user.SplitFunction;
using br.ufc.mdcc.mapreduce.user.PartitionFunction;

namespace br.ufc.mdcc.mapreduce.Splitter { 

	public interface BaseISourceSplitter<I, IMK, IMV, Sf, Bf> : 
	BaseIScatterSource<I>, ISynchronizerKind 
		where I:IData
		where IMK:IData
		where IMV:IData
		where Sf:ISplitFunction<I, IMK, IMV>
		where Bf:IPartitionFunction<IMK>
{
		// herdado de Scatter
		//I Source_data {get;}


} // end main interface 

} // end namespace 
