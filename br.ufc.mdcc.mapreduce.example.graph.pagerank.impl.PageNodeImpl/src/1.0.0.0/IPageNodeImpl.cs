using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PageNode;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PGRank;
using br.ufc.mdcc.common.Iterator;

namespace br.ufc.mdcc.mapreduce.example.graph.pagerank.impl.PageNodeImpl { 

	public class IPageNodeImpl<TID> : BaseIPageNodeImpl<TID>, IPageNode<TID>
		where TID:IInteger{
		public IPageNodeImpl() { } 
		override public void initialize(){
			System.Console.WriteLine ("################################################ Initialize PageNodeImpl ###########################################");
			newInstance(); 
		}
		public object newInstance (){
			object idInstance = Id_node.newInstance();
			IPageNodeInstance<TID> pageNodeInstance = new IPageNodeInstanceImpl<TID> (idInstance);
			pageNodeInstance.NeighborsInstance = (IIteratorInstance<TID>) Neighbors.newInstance ();
			pageNodeInstance.PgrankInstance = (IPGRankInstance) Pgrank.newInstance ();
			return this.Instance = pageNodeInstance;
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
		public IPageNodeInstanceImpl(object idInstance){
			this.IdInstance = idInstance;
		}
		#region IPageNodeInstance implementation
		private object idInstance;
		private IPGRankInstance pgrankInstance;
		private IIteratorInstance<TID> neighborsInstance;
		public object IdInstance {
			get { return idInstance; }
			set { this.idInstance = value; }
		}
		public IPGRankInstance PgrankInstance {
			get { return pgrankInstance; }
			set { this.pgrankInstance = value; }
		}
		public IIteratorInstance<TID> NeighborsInstance {
			get { return neighborsInstance; }
			set { this.neighborsInstance = value; }
		}
		#endregion
	}
}

