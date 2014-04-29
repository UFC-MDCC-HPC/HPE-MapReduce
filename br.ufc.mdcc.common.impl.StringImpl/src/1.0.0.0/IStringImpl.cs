using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.String;
using System.Collections.Generic;

namespace br.ufc.mdcc.common.impl.StringImpl { 

	public class IStringImpl : BaseIStringImpl, IString
	{

		public IStringImpl() { 		} 

		public IStringInstance newInstance (string s)
		{
			IStringInstance instance = (IStringInstance)newInstance ();
			instance.Value = s;
			return instance;
		}

		public object newInstance ()
		{
			this.instance = new IStringInstanceImpl ();
			return this.Instance;
		}

		private IStringInstance instance;

		public object Instance {
			get { return instance;	}
			set { this.instance = (IStringInstance) value; }
		}
	}

	public class IStringInstanceImpl : IStringInstance
	{
		#region IStringInstance implementation

		private string val;

		public string Value {
			get { return val; }
			set { this.val = value;	}
		}

		#endregion


	}

}
