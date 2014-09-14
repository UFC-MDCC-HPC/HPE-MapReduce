using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.common.Iterator { 
	
	public interface IIterator<T> : IData, BaseIIterator<T>
		where T:IData
	{
		IIteratorInstance<T> newIteratorInstance();
		object createItem ();

	} // end main interface 

	public interface IIteratorInstance<T>
		where T:IData
	{
		// consumer:


		// - raises exception if has finished
		void put(object item);

		void putAll(IIteratorInstance<T> items);

		// - raises exception if has finished and not restarted
		void finish();

		// producer:

		// - raises exception if has finished
		bool fetch_next (out object result);
	}



} // end namespace 
