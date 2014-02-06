using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.farm.Scatter;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;

namespace br.ufc.mdcc.mapreduce.Shuffler { 

	public interface ISourceShuffler<OMK> : 
	BaseISourceShuffler<OMK>, 
	IScatterSource<IIterator<IKVPair<OMK,IInteger>>>
where OMK:IData
{


} // end main interface 

} // end namespace 
