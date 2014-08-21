/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.mapreduce.example.graph.clique.CliqueNode;
using br.ufc.mdcc.mapreduce.user.ReduceFunction;

namespace br.ufc.mdcc.mapreduce.example.graph.clique.CliqueReduce { 
	public interface BaseICliqueReduce : BaseIReduceFunction<IString, ICliqueNode, IKVPair<IString, ICliqueNode>>, IComputationKind {

	} // end main interface 
} 
// BaseIReduceFunction<OMK, OMV, ORV>:
//	  IKVPair<OMK,IIterator<OMV>> Input_values {get;}
//    ORV Output_value {get;}
