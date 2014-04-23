/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.mapreduce.user.ReduceFunction;

namespace br.ufc.mdcc.mapreduce.example.graph.clique.CliqueReduce { 
	public interface BaseICliqueReduce : BaseIReduceFunction<IInteger, IKVPair<IInteger, IIterator<IInteger>>, IKVPair<IInteger, IIterator<IKVPair<IInteger, IIterator<IInteger>>>>>, IComputationKind {

	} // end main interface 
} // end namespace 
//<IInteger, IKVPair<IInteger, IIterator<IInteger>>, IKVPair<IInteger, IIterator<IKVPair<IInteger, IIterator<IInteger>>>>>
//where OMK: IInteger
//where OMV: IKVPair<IInteger, IIterator<IInteger>>
//where ORV: IKVPair<IInteger, IIterator<IKVPair<IInteger, IIterator<IInteger>>>>

