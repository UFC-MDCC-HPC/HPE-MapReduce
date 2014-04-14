/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PageNode;
using br.ufc.mdcc.mapreduce.user.MapFunction;
using br.ufc.mdcc.common.Double;

namespace br.ufc.mdcc.mapreduce.example.graph.pagerank.VoteMap { 

	public interface BaseIVoteMap<IMK, IMV, OMK, OMV> : BaseIMapFunction<IMK, IMV, OMK, OMV>, IComputationKind 
where IMK:IInteger
where IMV:IPageNode<IInteger>
where OMK: IInteger
where OMV: IDouble
{



} // end main interface 

} // end namespace 
