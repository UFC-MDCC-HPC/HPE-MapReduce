using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.common.graph.DataNode { 

public interface IDataNode<T> : BaseIDataNode<T>, IData
where T:IData
{


} // end main interface 

} // end namespace 
