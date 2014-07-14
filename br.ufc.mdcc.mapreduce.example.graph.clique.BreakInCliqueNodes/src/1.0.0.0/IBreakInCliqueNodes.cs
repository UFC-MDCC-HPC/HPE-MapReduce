using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.mapreduce.example.graph.clique.CliqueNode;
using br.ufc.mdcc.mapreduce.user.SplitFunction;

namespace br.ufc.mdcc.mapreduce.example.graph.clique.BreakInCliqueNodes { 

	public interface IBreakInCliqueNodes: BaseIBreakInCliqueNodes, ISplitFunction<IString, IInteger, ICliqueNode<IInteger>> {

	} // end main interface 
} // end namespace 
