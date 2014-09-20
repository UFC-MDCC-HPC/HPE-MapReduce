using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.user.ReduceFunction;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.common.KVPair;
//using br.ufc.mdcc.mapreduce.example.graph.sssp.DataPath;

namespace br.ufc.mdcc.mapreduce.example.graph.sssp.PathFlowReduce { 

	public interface IPathFlowReduce : BaseIPathFlowReduce, IReduceFunction<IString, IString, IKVPair<IString, IString>>
{
		void clearNeighbours ();

} // end main interface 

} // end namespace 
