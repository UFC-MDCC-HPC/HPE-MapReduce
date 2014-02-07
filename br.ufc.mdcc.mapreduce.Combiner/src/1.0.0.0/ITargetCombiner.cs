using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.farm.Gather;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Iterator;

namespace br.ufc.mdcc.mapreduce.Combiner { 

	public interface ITargetCombiner<ORV,O> : 
	BaseITargetCombiner<ORV,O>, 
	IGatherTarget<O>
		where ORV:IData
		where O:IData

{


} // end main interface 

} // end namespace 
