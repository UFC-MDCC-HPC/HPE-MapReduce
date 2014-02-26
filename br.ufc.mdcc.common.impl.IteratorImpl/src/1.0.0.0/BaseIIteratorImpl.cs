/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Iterator;

namespace br.ufc.mdcc.common.impl.IteratorImpl { 

public abstract class BaseIIteratorImpl<T>: DataStructure, BaseIIterator<T>
where T:IData
{

		private T item_factory = default(T);

		protected T Item_factory {
			get {
				if (this.item_factory == null)
					this.item_factory = (T) Services.getPort("item_factory");
				return this.item_factory;
			}
		}

}

}
