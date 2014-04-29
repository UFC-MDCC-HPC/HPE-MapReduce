using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.Data;
using System.Collections.Generic;

namespace br.ufc.mdcc.common.impl.IntegerImpl 
{ 

	public class IIntegerImpl : BaseIntegerImpl, IInteger
	{

		public IIntegerImpl() { } 

		public IIntegerInstance newInstance (int i)
		{
			IIntegerInstance instance = (IIntegerInstance)newInstance ();
			instance.Value = i;
			return instance;
		}

		public object newInstance ()
		{
			this.instance = new IIntegerInstanceImpl ();
			return this.Instance;
		}

		private IIntegerInstance instance;

		public object Instance {
			get { return instance;	}
			set { this.instance = (IIntegerInstance) value; }
		}
	}

	public class IIntegerInstanceImpl : IIntegerInstance
	{
		#region IIntegerInstance implementation

		private int val;

		public int Value {
			get { return val; }
			set { this.val = value;	}
		}

		#endregion


	}


}
