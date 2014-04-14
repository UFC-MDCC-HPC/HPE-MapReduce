/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.mapreduce.example.graph.clique.CliqueNode;

namespace br.ufc.mdcc.mapreduce.example.graph.clique.impl.CliqueNodeImpl { 

public abstract class BaseICliqueNodeImpl<TID>: DataStructure, BaseICliqueNode<TID>
where TID:IInteger
{

private TID id = default(TID);

public TID Id {
	get {
		if (this.id == null)
			this.id = (TID) Services.getPort("id");
		return this.id;
	}
}

private IIterator<TID> neighbors = null;

public IIterator<TID> Neighbors {
	get {
		if (this.neighbors == null)
			this.neighbors = (IIterator<TID>) Services.getPort("neighbors");
		return this.neighbors;
	}
}



}

}
