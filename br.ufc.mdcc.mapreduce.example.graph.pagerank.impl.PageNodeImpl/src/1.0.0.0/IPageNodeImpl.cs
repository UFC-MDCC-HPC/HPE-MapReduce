using System;
using System.Collections.Generic;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PageNode;

namespace br.ufc.mdcc.mapreduce.example.graph.pagerank.impl.PageNodeImpl { 

	public class IPageNodeImpl : BaseIPageNodeImpl, IPageNode{
		public IPageNodeImpl() { } 
		override public void initialize(){
			newInstance(); 
		}
		public object newInstance (){
			IPageNodeInstance page = new IPageNodeInstanceImpl();
			return this.Instance = page;
		}
		public object newInstance (int _id){
			object o = newInstance ();
			IPageNodeInstance page = (IPageNodeInstance)o;
			page.IdInstance = _id;
			return this.Instance = page;
		}
		private IPageNodeInstance instance;
		public object Instance {
			get { return instance;	}
			set { this.instance = (IPageNodeInstance) value;	}
		}
	}

	[Serializable]
	public class IPageNodeInstanceImpl : IPageNodeInstance{
		#region IPageNodeInstance implementation
		public IPageNodeInstanceImpl(){
			PgrankInstance = 1.0;
			NeighborsInstance = new List<int> ();
			IdInstance = -1;
		}
		private int idInstance;
		public int IdInstance {
			get { return idInstance; }
			set { this.idInstance = value; }
		}
		private double pgrankInstance;
		public double PgrankInstance {
			get { return pgrankInstance; }
			set { this.pgrankInstance = value; }
		}
		private IList<int> neighborsInstance;
		public IList<int> NeighborsInstance {
			get { return neighborsInstance; }
			set { this.neighborsInstance = value; }
		}
		#endregion
		#region ICloneable implementation

		public object Clone (){
			IPageNodeInstance clone = new IPageNodeInstanceImpl();
			clone.IdInstance = this.IdInstance;
			clone.PgrankInstance = this.PgrankInstance;
			clone.NeighborsInstance = new List<int>(this.NeighborsInstance);
			return clone;
		}
		#endregion
	}
}


//		override public void initialize(){
//			newInstance(); 
//		}
//		public object newInstance (){
//			object idInstance = Id_node.newInstance ();//.Instance;
//			IIteratorInstance<IInteger> edge_node_instance = (IIteratorInstance<IInteger>)Edge_node.newInstance ();//.Instance;
//			IPGRankInstance value_node_instance = (IPGRankInstance)Value_node.newInstance ();//.Instance;
//
//			IPageNodeInstance page_node_instance = new IPageNodeInstanceImpl(idInstance);
//
//			page_node_instance.PgrankInstance = value_node_instance;
//			page_node_instance.NeighborsInstance = edge_node_instance;
//			return this.Instance = page_node_instance;
//		}
//		private IPageNodeInstance instance;
//		public object Instance {
//			get { return instance;	}
//			set { this.instance = (IPageNodeInstance) value;	}
//		}
//	}
//
//	[Serializable]
//	public class IPageNodeInstanceImpl : IPageNodeInstance{
//		public IPageNodeInstanceImpl(object idInstance){
//			this.IdInstance = idInstance;
//		}
//		#region IPageNodeInstance implementation
//		private object idInstance;
//		private IPGRankInstance pgrankInstance;
//		private IIteratorInstance<IInteger> neighborsInstance;
//		public object IdInstance {
//			get { return idInstance; }
//			set { this.idInstance = value; }
//		}
//		public IPGRankInstance PgrankInstance {
//			get { return pgrankInstance; }
//			set { this.pgrankInstance = value; }
//		}
//		public IIteratorInstance<IInteger> NeighborsInstance {
//			get { return neighborsInstance; }
//			set { this.neighborsInstance = value; }
//		}
//		#endregion
//	}
//}

