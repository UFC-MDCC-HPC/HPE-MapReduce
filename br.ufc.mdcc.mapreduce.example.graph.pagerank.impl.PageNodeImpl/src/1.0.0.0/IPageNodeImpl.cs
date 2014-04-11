using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PageNode;

namespace br.ufc.mdcc.mapreduce.example.graph.pagerank.impl.PageNodeImpl { 

public class IPageNodeImpl<T> : BaseIPageNodeImpl<T>, IPageNode<T>
where T:IData
{

public IPageNodeImpl() { 

} 
		public IData newInstance() {
			return new IPageNodeImpl<T>();
		}
		public IData clone() {
			IData instance = newInstance();
			instance.loadFrom(this);
			return instance;
		}
		public void loadFrom(IData o) {
			IPageNodeImpl<T> i = (IPageNodeImpl<T>)o;
			this.Id.loadFrom (i.Id);//._Id = i.Id;
			this.Neighbors.loadFrom (i.Neighbors);//.neighbors = (IIterator<T>)i.Neighbors;
			this.Pgrank.loadFrom (i.Pgrank);//.rank = i.Pgrank;
		}


}

}
