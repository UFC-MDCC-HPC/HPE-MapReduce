/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.user.PartitionFunction;

namespace br.ufc.mdcc.mapreduce.splitter.ScatterSplitData { 

	public interface BaseISourceScatterSplitData<IMK,IMV,Bf> : ISynchronizerKind 
		where IMK:IData
		where IMV:IData
		where Bf:IPartitionFunction<IMK>
{

		IIterator<IKVPair<IMK,IMV>> Bins {get;}


} // end main interface 

} // end namespace 
