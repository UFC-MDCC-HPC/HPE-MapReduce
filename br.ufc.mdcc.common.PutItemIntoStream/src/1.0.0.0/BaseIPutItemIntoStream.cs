/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Iterator;

namespace br.ufc.mdcc.common.PutItemIntoStream { 

public interface BaseIPutItemIntoStream<T> : IComputationKind 
where T:IData
{

	T Item_type {get;}
	IInterator<T> Stream {get;}


} // end main interface 

} // end namespace 
