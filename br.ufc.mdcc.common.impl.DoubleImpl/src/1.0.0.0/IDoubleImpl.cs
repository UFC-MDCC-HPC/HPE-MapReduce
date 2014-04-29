using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Double;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.common.impl.DoubleImpl { 

public class IDoubleImpl : BaseIDoubleImpl, IData
{

public IDoubleImpl() { 

} 

		private double value_;

		public double Value { 
			get { return value_;  }
			set { value_ = value; }
		}

		public void loadFrom (IData o)
		{
			IDouble i = (IDouble)o;
			this.Value = i.Value;
		}

		public IData newInstance()
		{
			return new IDoubleImpl ();
		}

		public IData clone ()
		{
			IData instance = newInstance();
			instance.loadFrom(this);
			return instance;
		}

}

}
