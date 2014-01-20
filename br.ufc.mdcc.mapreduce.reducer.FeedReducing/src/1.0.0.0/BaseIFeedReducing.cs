/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.mapreduce.reducer.FeedReducing { 

public interface BaseIFeedReducing<OMV, OMK> : IComputationKind 
where OMV:IData
where OMK:IData
{

	IInterator<OMV> Output_value {get;}
	IInterator<IData> Input {get;}
	OMK Output_key {get;}


} // end main interface 

} // end namespace 
