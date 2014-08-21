/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.mapreduce.example.graph.clique.CliqueNode;
using br.ufc.mdcc.mapreduce.user.SplitFunction;

namespace br.ufc.mdcc.mapreduce.example.graph.clique.BreakInCliqueNodes { 
	public interface BaseIBreakInCliqueNodes: BaseISplitFunction<IString, IInteger, ICliqueNode>, IComputationKind{

	} // end main interface 
} // end namespace 
//BaseISplitFunction<IMAP, IMK, IMV>
// IMAP Input_data {get;}
// IIterator<IKVPair<IMK,IMV>> Output_data {get;}