using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PageNode;

namespace br.ufc.mdcc.mapreduce.example.graph.pagerank.impl.PageNodeImpl { 

	public class IPageNodeImpl<TID> : BaseIPageNodeImpl<TID>, IPageNode<TID>
		where TID:IInteger{
		public IPageNodeImpl() { } 
		override public void initialize(){
			newInstance(); 
		}
		public object newInstance (){
			object id = Id.newInstance();
			IPageNodeInstance<TID> cni = new IPageNodeInstanceImpl<TID> (id);
			cni.Neighbors = Neighbors.newInstance ();
			cni.Pgrank = Pgrank.newInstance ();
			return this.Instance = cni;
		}
		public IPageNodeInstance<TID> newInstance (object id){
			IPageNodeInstance<TID> instance = new IPageNodeInstanceImpl<TID> (id);
			instance.Neighbors = Neighbors.newInstance ();
			instance.Pgrank = Pgrank.newInstance ();
			return ( IPageNodeInstance<TID>) (this.Instance = instance);
		}
		private IPageNodeInstance<TID> instance;
		public object Instance {
			get { return instance;	}
			set { this.instance = (IPageNodeInstance<TID>) value;	}
		}
	}

	[Serializable]
	public class IPageNodeInstanceImpl<TID> : IPageNodeInstance<TID>
		where TID:IData{
		public IPageNodeInstanceImpl(object id){
			this.Id = id;
		}
		#region IPageNodeInstance implementation
		private object id;
		private object pgrank;
		private object neighbors;
		public object Id {
			get { return id; }
			set { this.id = value; }
		}
		public object Pgrank {
			get { return pgrank; }
			set { this.pgrank = value; }
		}
		public object Neighbors {
			get { return neighbors; }
			set { this.neighbors = value; }
		}
		#endregion
	}
}

