/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.farm.Scatter;

namespace br.ufc.mdcc.mapreduce.Splitter { 

public interface BaseITargetSplitter<IMK,IMV> : 
	BaseIScatterTarget<IIterator<IKVPair<IMK,IMV>>>, ISynchronizerKind 
where IMK:IData
where IMV:IData
{
		// herdado de Scatter
		//		IIterator<IKVPair<IMK,IMV>> Target_data {get;}


} // end main interface 

} // end namespace 
