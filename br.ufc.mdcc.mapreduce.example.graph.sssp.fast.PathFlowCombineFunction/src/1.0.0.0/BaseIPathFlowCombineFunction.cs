/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.user.CombineFunction;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.mapreduce.example.graph.sssp.fast.PathInfo;


namespace br.ufc.mdcc.mapreduce.example.graph.sssp.fast.PathFlowCombineFunction { 

	public interface BaseIPathFlowCombineFunction<ORV, Out> : BaseICombineFunction<ORV, Out>, IComputationKind 
		where ORV: IKVPair<IInteger, IIterator<IPathInfo>>
		where Out: IKVPair<IInteger, IIterator<IPathInfo>>
	{



	} // end main interface 

} // end namespace 
