using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.farm.Scatter;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KMVPair;

namespace br.ufc.mdcc.mapreduce.Shuffler { 

public interface ITargetShuffler<OMV,OMK> : 
	BaseITargetShuffler<OMV,OMK>, 
	IScatterTarget<IIterator<IKMVPair<OMK,OMV>>>
where OMV:IData
where OMK:IData
{


} // end main interface 

} // end namespace 
