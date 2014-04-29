using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.common.graph.DataNode { 

public interface IDataNode<TID> : BaseIDataNode<TID>, IData
where TID:IData
{


} // end main interface 

} // end namespace 
