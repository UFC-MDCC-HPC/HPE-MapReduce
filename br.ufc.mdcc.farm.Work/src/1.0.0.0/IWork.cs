using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.farm.Work { 

public interface IWork<I, O> : BaseIWork<I, O>
where I:IData
where O:IData
{


} // end main interface 

} // end namespace 
