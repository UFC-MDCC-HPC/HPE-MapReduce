using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.mapreduce.example.graph.clique.CliqueNode;
using br.ufc.mdcc.mapreduce.user.ReduceFunction;

namespace br.ufc.mdcc.mapreduce.example.graph.clique.CliqueReduce { 
	public interface ICliqueReduce: BaseICliqueReduce, IReduceFunction<IString, ICliqueNode, IKVPair<IString, ICliqueNode>>{

	} // end main interface 
} // IReduceFunction<OMK, OMV, ORV>