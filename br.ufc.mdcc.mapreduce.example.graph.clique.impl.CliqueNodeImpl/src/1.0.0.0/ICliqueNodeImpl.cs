using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Integer;
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
			object id = Id.newInstance();
			ICliqueNodeInstance<TID> cni = new ICliqueNodeInstanceImpl<TID> (id);
			cni.Neighbors = Neighbors.newInstance ();
			return this.Instance = cni;
		}
		public ICliqueNodeInstance<TID> newInstance (object id){
			ICliqueNodeInstance<TID> instance = new ICliqueNodeInstanceImpl<TID> (id);
			instance.Neighbors = Neighbors.newInstance ();
			return ( ICliqueNodeInstance<TID>) (this.Instance = instance);
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
		public ICliqueNodeInstanceImpl(object id){
			this.Id = id;
		}
		#region ICliqueNodeInstance implementation
		private object id;
		private object neighbors;
		public object Id {
			get { return id; }
			set { this.id = value; }
		}
		public object Neighbors {
			get { return neighbors; }
			set { this.neighbors = value; }
		}
		#endregion
	}
}
