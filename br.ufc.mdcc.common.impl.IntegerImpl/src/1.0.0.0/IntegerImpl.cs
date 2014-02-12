using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.common.impl.IntegerImpl { 

	public class IIntegerImpl : BaseIntegerImpl, IInteger
{

	public IIntegerImpl() { 

	} 

		private int value_;

		public int Value {
			get {
				return value_;
			}
			set {
				value = value;
			}
		}

		void readFrom (IData o)
		{
			IInteger i = (IInteger)o;
			this.Value = i.Value;
		}
}

}
