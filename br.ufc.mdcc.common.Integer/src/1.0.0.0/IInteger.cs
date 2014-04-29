using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.common.Integer { 

	public interface IInteger : BaseIInteger, IData
	{
		IIntegerInstance newInstance(int i);
	} // end main interface 

	public interface IIntegerInstance
	{
		int Value { set; get; }
	}

} // end namespace 
