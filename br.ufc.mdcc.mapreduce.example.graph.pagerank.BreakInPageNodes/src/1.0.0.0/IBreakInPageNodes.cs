using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
//using br.ufc.mdcc.common.String;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PageNode;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.mapreduce.user.SplitFunction;

namespace br.ufc.mdcc.mapreduce.example.graph.pagerank.BreakInPageNodes { 

	public interface IBreakInPageNodes: BaseIBreakInPageNodes, ISplitFunction<IIterator<IPageNode<IInteger>>, IInteger, IPageNode<IInteger>>
{


} // end main interface 

} // end namespace 
