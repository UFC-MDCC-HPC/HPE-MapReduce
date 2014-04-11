/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.mapreduce.example.graph.clique.CliqueNode;

namespace br.ufc.mdcc.mapreduce.example.graph.clique.impl.CliqueNodeImpl { 

public abstract class BaseICliqueNodeImpl<T>: DataStructure, BaseICliqueNode<T>
where T:IData
{

private T id = default(T);

public T Id {
	get {
		if (this.id == null)
			this.id = (T) Services.getPort("id");
		return this.id;
	}
}

private IIterator<T> neighbors = null;

public IIterator<T> Neighbors {
	get {
		if (this.neighbors == null)
			this.neighbors = (IIterator<T>) Services.getPort("neighbors");
		return this.neighbors;
	}
}



}

}
