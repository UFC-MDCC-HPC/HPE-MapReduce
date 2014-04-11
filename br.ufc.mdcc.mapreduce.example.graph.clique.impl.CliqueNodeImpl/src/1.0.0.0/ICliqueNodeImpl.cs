using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.example.graph.clique.CliqueNode;

namespace br.ufc.mdcc.mapreduce.example.graph.clique.impl.CliqueNodeImpl { 

public class ICliqueNodeImpl<T> : BaseICliqueNodeImpl<T>, ICliqueNode<T>
where T:IData
{

public ICliqueNodeImpl() { 

} 
		public IData newInstance() {
			return new ICliqueNodeImpl<T>();
		}
		public IData clone() {
			IData instance = newInstance();
			instance.loadFrom(this);
			return instance;
		}
		public void loadFrom(IData o) {
			ICliqueNodeImpl<T> i = (ICliqueNodeImpl<T>)o;
			this.Id.loadFrom (i.Id);// = i.Id;
			this.Neighbors.loadFrom (i.Neighbors);
		}

}

}
