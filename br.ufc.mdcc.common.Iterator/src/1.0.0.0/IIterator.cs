using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.common.Iterator { 
	
public interface IIterator<T> : IData, BaseIIterator<T>
where T:IData
{
		// consumer:

		T createItem ();

		// - raises exception if has finished
		void put(T item);

		// - raises exception if has finished and not restarted
		void finish();

	    // producer:

		// - raises exception if has finished
		T fetch_next();

		bool HasFinished { get; }

} // end main interface 

} // end namespace 
