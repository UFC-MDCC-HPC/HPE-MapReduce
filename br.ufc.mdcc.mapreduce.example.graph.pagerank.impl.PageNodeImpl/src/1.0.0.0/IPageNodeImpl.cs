using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PGRank;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PageNode;

namespace br.ufc.mdcc.mapreduce.example.graph.pagerank.impl.PageNodeImpl { 

	public class IPageNodeImpl : BaseIPageNodeImpl, IPageNode{
		public IPageNodeImpl() { } 
		override public void initialize(){
			newInstance(); 
		}
		public object newInstance (){
			object idInstance = Id_node.newInstance ();//.Instance;
			IIteratorInstance<IInteger> edge_node_instance = (IIteratorInstance<IInteger>)Edge_node.newInstance ();//.Instance;
			IPGRankInstance value_node_instance = (IPGRankInstance)Value_node.newInstance ();//.Instance;

			IPageNodeInstance page_node_instance = new IPageNodeInstanceImpl(idInstance);

			page_node_instance.PgrankInstance = value_node_instance;
			page_node_instance.NeighborsInstance = edge_node_instance;
			return this.Instance = page_node_instance;
		}
		private IPageNodeInstance instance;
		public object Instance {
			get { return instance;	}
			set { this.instance = (IPageNodeInstance) value;	}
		}
	}

	[Serializable]
	public class IPageNodeInstanceImpl : IPageNodeInstance{
		public IPageNodeInstanceImpl(object idInstance){
			this.IdInstance = idInstance;
		}
		#region IPageNodeInstance implementation
		private object idInstance;
		private IPGRankInstance pgrankInstance;
		private IIteratorInstance<IInteger> neighborsInstance;
		public object IdInstance {
			get { return idInstance; }
			set { this.idInstance = value; }
		}
		public IPGRankInstance PgrankInstance {
			get { return pgrankInstance; }
			set { this.pgrankInstance = value; }
		}
		public IIteratorInstance<IInteger> NeighborsInstance {
			get { return neighborsInstance; }
			set { this.neighborsInstance = value; }
		}
		#endregion
	}
}

