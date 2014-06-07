using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PGRank;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.mapreduce.example.graph.pagerank.impl.PGRankImpl { 
	public class IPGRankImpl : BaseIPGRankImpl, IPGRank{

		override public void initialize(){
			newInstance(); 
		}

		public IPGRankInstance newInstance (double r){
			IPGRankInstance instance = (IPGRankInstance)newInstance ();
			instance.Value = r;
			return instance;
		}

		public object newInstance (){
			this.instance = new IPGRankInstanceImpl ();
			return this.Instance;
		}

		private IPGRankInstance instance;
		public object Instance {
			get { return instance;	}
			set { this.instance = (IPGRankInstance) value; }
		}

	}

	[Serializable]
	public class IPGRankInstanceImpl : IPGRankInstance{
		public IPGRankInstanceImpl() { 
			pgrank = 1.0;
			error = 0.0;
		}

		#region IPGRankInstance implementation
		private double pgrank;
		public double Value {
			get { return pgrank; }
			set {
				error = (value - pgrank);
				pgrank = value;
			}
		}

		private double error;
		public double Error { get { return error; } }
		#endregion
	}
}
