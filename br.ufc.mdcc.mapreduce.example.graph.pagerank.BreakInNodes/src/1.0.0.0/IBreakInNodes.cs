using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PageNode;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.mapreduce.user.SplitFunction;

namespace br.ufc.mdcc.mapreduce.example.graph.pagerank.BreakInNodes { 

	public interface IBreakInNodes: BaseIBreakInNodes, ISplitFunction<IString, IInteger, IPageNode<IInteger>>
{


} // end main interface 

} // end namespace 
