using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PageNode;

namespace br.ufc.mdcc.mapreduce.example.graph.pagerank.impl.PageNodeImpl { 

public class IPageNodeImpl<TID> : BaseIPageNodeImpl<TID>, IPageNode<TID>
where TID:IInteger
{

public IPageNodeImpl() { 

} 
		public IData newInstance() {
			return new IPageNodeImpl<TID>();
		}
		public IData clone() {
			IData instance = newInstance();
			instance.loadFrom(this);
			return instance;
		}
		public void loadFrom(IData o) {
			IPageNodeImpl<TID> i = (IPageNodeImpl<TID>)o;
			this.Id.loadFrom (i.Id);
			this.Neighbors.loadFrom (i.Neighbors);
			this.Pgrank.loadFrom (i.Pgrank);
		}

}

}
