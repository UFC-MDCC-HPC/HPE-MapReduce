/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.PutItemIntoStream;

namespace br.ufc.mdcc.common.impl.PutItemIntoStreamImpl { 

public abstract class BaseIPutItemImpl<T>: Computation, BaseIPutItemIntoStream<T>
where T:IData
{

private T item_type = default(T);

public T Item_type {
	get {
		if (this.item_type == null)
			this.item_type = (T) Services.getPort("item_type");
		return this.item_type;
	}
}

private IIterator<T> stream = null;

public IIterator<T> Stream {
	get {
		if (this.stream == null)
			this.stream = (IIterator<T>) Services.getPort("stream");
		return this.stream;
	}
}



}

}
