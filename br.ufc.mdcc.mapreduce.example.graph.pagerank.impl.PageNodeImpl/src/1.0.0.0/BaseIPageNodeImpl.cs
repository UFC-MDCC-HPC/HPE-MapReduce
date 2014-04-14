/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PGRank;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PageNode;

namespace br.ufc.mdcc.mapreduce.example.graph.pagerank.impl.PageNodeImpl { 

public abstract class BaseIPageNodeImpl<TID>: DataStructure, BaseIPageNode<TID>
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

private IPGRank pgrank = null;

public IPGRank Pgrank {
	get {
		if (this.pgrank == null)
			this.pgrank = (IPGRank) Services.getPort("pgrank");
		return this.pgrank;
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
