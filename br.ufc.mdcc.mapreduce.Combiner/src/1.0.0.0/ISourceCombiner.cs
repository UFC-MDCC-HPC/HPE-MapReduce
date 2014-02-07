using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.farm.Gather;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Iterator;

namespace br.ufc.mdcc.mapreduce.Combiner { 

	public interface ISourceCombiner<ORV> : 
	BaseISourceCombiner<ORV>, IGatherSource<IIterator<ORV>>
		where ORV:IData
{


} // end main interface 

} // end namespace 
