using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.common.communication.Broadcast { 

public interface IBroadcast<T> : BaseIBroadcast<T>
where T:IData
{
	int Root { set; }

} // end main interface 

} // end namespace 
