using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.common.Double { 
	public interface IDouble : BaseIDouble, IData{
		IDoubleInstance newInstance(double d);
	} // end main interface 
	public interface IDoubleInstance{
		double Value { set; get; }
	}
} // end namespace 
