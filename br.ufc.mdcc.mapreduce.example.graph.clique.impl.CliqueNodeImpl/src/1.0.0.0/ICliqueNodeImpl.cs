using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.mapreduce.example.graph.clique.CliqueNode;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.mapreduce.example.graph.clique.impl.CliqueNodeImpl { 

	public class ICliqueNodeImpl<TID> : BaseICliqueNodeImpl<TID>, ICliqueNode<TID>
		where TID:IInteger {
		public ICliqueNodeImpl() { 

		} 
		override public void initialize(){
			newInstance(); 
		}
		public object newInstance (){
			object idInstance = Id.newInstance();
			ICliqueNodeInstance<TID> cliqueNodeInstance = new ICliqueNodeInstanceImpl<TID> (idInstance);
			cliqueNodeInstance.NeighborsInstance = (IIteratorInstance<TID>) Neighbors.newInstance ();
			return this.Instance = cliqueNodeInstance;
		}
		private ICliqueNodeInstance<TID> instance;
		public object Instance {
			get { return instance;	}
			set { this.instance = (ICliqueNodeInstance<TID>) value;	}
		}
	}

	[Serializable]
	public class ICliqueNodeInstanceImpl<TID> : ICliqueNodeInstance<TID>
		where TID:IData{
		public ICliqueNodeInstanceImpl(object idInstance){
			this.IdInstance = idInstance;
		}
		#region ICliqueNodeInstance implementation
		private object idInstance;
		private IIteratorInstance<TID> neighborsInstance;
		public object IdInstance {
			get { return idInstance; }
			set { this.idInstance = value; }
		}
		public IIteratorInstance<TID> NeighborsInstance {
			get { return neighborsInstance; }
			set { this.neighborsInstance = value; }
		}
		#endregion
	}
}
