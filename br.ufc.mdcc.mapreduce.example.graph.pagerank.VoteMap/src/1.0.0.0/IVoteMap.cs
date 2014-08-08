using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.user.MapFunction;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.Double;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PageNode;

namespace br.ufc.mdcc.mapreduce.example.graph.pagerank.VoteMap { 

	public interface IVoteMap: BaseIVoteMap, IMapFunction<IInteger, IPageNode, IString, IDouble>
{


} // end main interface 

} // end namespace 
