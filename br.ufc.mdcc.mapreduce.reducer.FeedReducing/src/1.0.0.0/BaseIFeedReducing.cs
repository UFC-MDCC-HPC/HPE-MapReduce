/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.KMVPair;

namespace br.ufc.mdcc.mapreduce.reducer.FeedReducing { 

public interface BaseIFeedReducing<OMV, OMK> : IComputationKind 
where OMV:IData
where OMK:IData
{

		IIterator<IKMVPair<OMK,OMV>> Input {get;}
		IKMVPair<OMK,OMV> Output_values {get;}


} // end main interface 

} // end namespace 
