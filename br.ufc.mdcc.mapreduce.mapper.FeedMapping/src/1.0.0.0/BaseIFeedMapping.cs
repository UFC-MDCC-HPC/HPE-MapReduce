/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.KVPair;

namespace br.ufc.mdcc.mapreduce.mapper.FeedMapping { 

public interface BaseIFeedMapping<IMV, IMK> : IComputationKind 
where IMV:IData
where IMK:IData
{

	IIterator<IKVPair<IMK,IMV>> Input {get;}
	IMK Output_key {get;}
	IMV Output_value {get;}


} // end main interface 

} // end namespace 
