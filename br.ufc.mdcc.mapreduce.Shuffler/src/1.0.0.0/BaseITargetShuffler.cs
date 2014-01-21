/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.farm.Scatter;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KMVPair;

namespace br.ufc.mdcc.mapreduce.Shuffler { 

public interface BaseITargetShuffler<OMV,OMK> : 
	BaseIScatterTarget<IIterator<IKMVPair<OMK,OMV>>>, ISynchronizerKind 
where OMV:IData
where OMK:IData
{



} // end main interface 

} // end namespace 
