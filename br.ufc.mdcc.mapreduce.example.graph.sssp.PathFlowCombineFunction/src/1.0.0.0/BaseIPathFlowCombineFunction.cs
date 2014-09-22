/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.user.CombineFunction;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.String;


namespace br.ufc.mdcc.mapreduce.example.graph.sssp.PathFlowCombineFunction { 

	public interface BaseIPathFlowCombineFunction<ORV, Out> : BaseICombineFunction<ORV, Out>, IComputationKind 
		where ORV: IKVPair<IString, IString>
		where Out: IString
	{



	} // end main interface 

} // end namespace 
