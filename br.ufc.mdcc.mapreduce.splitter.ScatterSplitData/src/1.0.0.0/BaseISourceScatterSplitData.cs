/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Set;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.mapreduce.splitter.ScatterSplitData { 

	public interface BaseISourceScatterSplitData<IMK,IMV> : ISynchronizerKind 
		where IMK:IData
		where IMV:IData
{

		ISet<IKVPair<IMK,IMV>> Bins {get;}


} // end main interface 

} // end namespace 
