using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.String;

namespace br.ufc.mdcc.common.impl.StringImpl { 

	public class IStringImpl : BaseIStringImpl, IString
{

public IStringImpl() { 

} 

		private string value_ = null;

		public string Value { 
			get { return value_;  }
			set { value_ = value; }
		}

		public void loadFrom (br.ufc.mdcc.common.Data.IData o)
		{
			IString s = (IString) o;
			this.Value = s.Value;
		}
		public br.ufc.mdcc.common.Data.IData newInstance ()
		{
			IString s = new IStringImpl();
			return s;
		}
		public br.ufc.mdcc.common.Data.IData clone ()
		{
			IString s = new IStringImpl();
			s.Value = this.Value;
			return s;
		}
}

}
