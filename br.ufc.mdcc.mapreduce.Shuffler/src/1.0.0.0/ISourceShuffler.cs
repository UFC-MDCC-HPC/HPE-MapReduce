using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.farm.Scatter;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;

namespace br.ufc.mdcc.mapreduce.Shuffler { 

public interface ISourceShuffler<OPK,OMK> : 
	BaseISourceShuffler<OPK,OMK>, 
	IScatterSource<IIterator<IKVPair<OMK,OPK>>>
where OPK:IData
where OMK:IData
{


} // end main interface 

} // end namespace 
