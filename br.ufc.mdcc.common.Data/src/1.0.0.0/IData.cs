using br.ufc.pargo.hpe.kinds;

namespace br.ufc.mdcc.common.Data { 

public interface IData : BaseIData
{
	 	void loadFrom (IData o);
		IData newInstance ();
		IData clone();

} // end main interface 

} // end namespace 
