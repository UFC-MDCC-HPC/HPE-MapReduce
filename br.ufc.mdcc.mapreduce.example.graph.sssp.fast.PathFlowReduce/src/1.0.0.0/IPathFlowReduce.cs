using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.user.ReduceFunction;
using br.ufc.mdcc.common.KVPair;
//using br.ufc.mdcc.mapreduce.example.graph.sssp.fast.DataPath;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.mapreduce.example.graph.sssp.fast.PathInfo;
using br.ufc.mdcc.common.Iterator;

namespace br.ufc.mdcc.mapreduce.example.graph.sssp.fast.PathFlowReduce { 

	public interface IPathFlowReduce : BaseIPathFlowReduce, IReduceFunction<IInteger, IPathInfo, IKVPair<IInteger, IIterator<IPathInfo>>>
{
		void clearNeighbours ();

} // end main interface 

} // end namespace 
