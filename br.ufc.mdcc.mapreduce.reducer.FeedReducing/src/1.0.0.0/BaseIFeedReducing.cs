/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.KVPair;

namespace br.ufc.mdcc.mapreduce.reducer.FeedReducing { 

public interface BaseIFeedReducing<OMV, OMK> : IComputationKind 
where OMV:IData
where OMK:IData
{

	IIterator<OMV> Output_value {get;}
	IIterator<IKVPair<OMK,OMV>> Input {get;}
	OMK Output_key {get;}


} // end main interface 

} // end namespace 
