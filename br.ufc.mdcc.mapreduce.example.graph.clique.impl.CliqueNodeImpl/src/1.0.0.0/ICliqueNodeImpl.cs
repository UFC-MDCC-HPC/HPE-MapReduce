using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.mapreduce.example.graph.clique.CliqueNode;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.mapreduce.example.graph.clique.impl.CliqueNodeImpl { 

public class ICliqueNodeImpl<TID> : BaseICliqueNodeImpl<TID>, ICliqueNode<TID>
where TID:IInteger
{

public ICliqueNodeImpl() { 

} 
		public IData newInstance() {
			return new ICliqueNodeImpl<TID>();
		}
		public IData clone() {
			IData instance = newInstance();
			instance.loadFrom(this);
			return instance;
		}
		public void loadFrom(IData o) {
			ICliqueNodeImpl<TID> i = (ICliqueNodeImpl<TID>)o;
			this.Id.loadFrom (i.Id);// = i.Id;
			this.Neighbors.loadFrom (i.Neighbors);
		}

}

}
