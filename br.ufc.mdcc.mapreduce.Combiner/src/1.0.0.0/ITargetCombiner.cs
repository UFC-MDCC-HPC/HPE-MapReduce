using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.farm.Gather;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.mapreduce.user.CombineFunction;

namespace br.ufc.mdcc.mapreduce.Combiner { 

	public interface ITargetCombiner<ORV,O,Cf> : 
	BaseITargetCombiner<ORV,O,Cf>, 
	IGatherTarget<O>
		where ORV:IData
		where O:IData
		where Cf: ICombineFunction<ORV, O> 
{


} // end main interface 

} // end namespace 
