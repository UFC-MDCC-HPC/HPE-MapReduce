/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.farm.Scatter;
using br.ufc.mdcc.farm.Gather;
using br.ufc.mdcc.common.Platform;

namespace br.ufc.mdcc.farm.Farm { 

public interface BaseIManager<S, C, I, O, P> : IComputationKind 
where S:IScatterSource<I>
where I:IData
where C:IGatherTarget<O>
where O:IData
where P:IPlatform
{

	O Output {get;}
	I Input {get;}


} // end main interface 

} // end namespace 
