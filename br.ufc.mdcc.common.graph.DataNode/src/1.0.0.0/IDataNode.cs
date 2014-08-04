using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.common.graph.DataNode { 

public interface IDataNode<TID, VAL, EDG> : BaseIDataNode<TID, VAL, EDG>, IData
where TID:IData
where VAL:IData
where EDG:IData
{


} // end main interface 

} // end namespace 
