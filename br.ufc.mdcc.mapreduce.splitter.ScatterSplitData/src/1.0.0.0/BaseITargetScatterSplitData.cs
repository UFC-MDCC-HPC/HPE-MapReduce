/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.mapreduce.splitter.ScatterSplitData { 

	public interface BaseITargetScatterSplitData<IMK,IMV> : ISynchronizerKind 
		where IMK:IData
		where IMV:IData
{

		IIterator<IKVPair<IMK,IMV>> Target_data {get;}


} // end main interface 

} // end namespace 
