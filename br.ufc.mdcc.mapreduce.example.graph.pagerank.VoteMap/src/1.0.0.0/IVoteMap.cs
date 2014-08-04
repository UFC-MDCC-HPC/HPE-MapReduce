using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PageNode;
using br.ufc.mdcc.mapreduce.user.MapFunction;
using br.ufc.mdcc.common.Double;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PageNode;

namespace br.ufc.mdcc.mapreduce.example.graph.pagerank.VoteMap { 

	public interface IVoteMap: BaseIVoteMap, IMapFunction<IInteger, IPageNode, IInteger, IDouble>
	//where IMK: IInteger
	//where IMV: IPageNode
	//where OMK: IInteger
	//where OMV: IDouble
{


} // end main interface 

} // end namespace 
