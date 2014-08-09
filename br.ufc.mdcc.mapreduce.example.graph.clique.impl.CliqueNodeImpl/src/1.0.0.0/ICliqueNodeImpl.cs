using System;
using System.Collections.Generic;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.example.graph.clique.CliqueNode;

namespace br.ufc.mdcc.mapreduce.example.graph.clique.impl.CliqueNodeImpl { 

	public class ICliqueNodeImpl : BaseICliqueNodeImpl, ICliqueNode{
		public ICliqueNodeImpl() { } 
		override public void initialize(){
			newInstance(); 
		}
		public object newInstance (){
			ICliqueNodeInstance page = new ICliqueNodeInstanceImpl();
			return this.Instance = page;
		}
		public object newInstance (int _id){
			object o = newInstance ();
			ICliqueNodeInstance page = (ICliqueNodeInstance)o;
			page.IdInstance = _id;
			return this.Instance = page;
		}
		private ICliqueNodeInstance instance;
		public object Instance {
			get { return instance;	}
			set { this.instance = (ICliqueNodeInstance) value;	}
		}
	}

	[Serializable]
	public class ICliqueNodeInstanceImpl : ICliqueNodeInstance{
		#region ICliqueNodeInstance implementation
		public ICliqueNodeInstanceImpl(){
			NeighborsInstance = new List<int> ();
			IdInstance = -1;
		}
		private int idInstance;
		public int IdInstance {
			get { return idInstance; }
			set { this.idInstance = value; }
		}
		private IList<int> neighborsInstance;
		public IList<int> NeighborsInstance {
			get { return neighborsInstance; }
			set { this.neighborsInstance = value; }
		}
		#endregion
	}
}