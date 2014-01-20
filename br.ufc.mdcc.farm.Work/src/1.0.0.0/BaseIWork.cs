/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.farm.Work { 

public interface BaseIWork<I, O> : IComputationKind 
where I:IData
where O:IData
{

	O Output {get;}
	I Input {get;}


} // end main interface 

} // end namespace 
