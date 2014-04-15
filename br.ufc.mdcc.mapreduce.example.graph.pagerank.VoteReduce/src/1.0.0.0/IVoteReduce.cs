using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.Double;
using br.ufc.mdcc.mapreduce.user.ReduceFunction;

namespace br.ufc.mdcc.mapreduce.example.graph.pagerank.VoteReduce { 
	public interface IVoteReduce: BaseIVoteReduce, IReduceFunction<IInteger, IDouble, IKVPair<IInteger, IDouble>>{

	} // end main interface 
} // end namespace 
