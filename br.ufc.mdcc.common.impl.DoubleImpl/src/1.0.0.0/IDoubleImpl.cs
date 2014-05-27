using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Double;
using br.ufc.mdcc.common.Data;
using System.Collections.Generic;

namespace br.ufc.mdcc.common.impl.DoubleImpl { 
	public class IDoubleImpl : BaseIDoubleImpl, IDouble{

		public IDoubleImpl() { } 

		override public void initialize(){
			newInstance(); 
		}

		public IDoubleInstance newInstance (double d){
			IDoubleInstance instance = (IDoubleInstance)newInstance ();
			instance.Value = d;
			return instance;
		}

		public object newInstance (){
			this.instance = new IDoubleInstanceImpl ();
			return this.Instance;
		}

		private IDoubleInstance instance;
		public object Instance {
			get { return instance;	}
			set { this.instance = (IDoubleInstance) value; }
		}
	}

	[Serializable]
	public class IDoubleInstanceImpl : IDoubleInstance{
		#region IDoubleInstance implementation
		private double val;
		public double Value {
			get { return val; }
			set { this.val = value;	}
		}
		#endregion
	}
}
