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

private T item_type = default(T);

protected T Item_type {
	get {
		if (this.item_type == null)
			this.item_type = (T) Services.getPort("item_type");
		return this.item_type;
	}
}



}

}
