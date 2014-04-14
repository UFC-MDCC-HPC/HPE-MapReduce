using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.graph.DataNode;

namespace br.ufc.mdcc.mapreduce.example.graph.pagerank.PageNode { 

public interface IPageNode<TID> : BaseIPageNode<TID>, IDataNode<TID>
where TID:IData
{


} // end main interface 

} // end namespace 
