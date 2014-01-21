using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.common.Iterator { 
	
public interface IIterator<T> : IData, BaseIIterator<T>
where T:IData
{


} // end main interface 

} // end namespace 
