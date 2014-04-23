using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.mapreduce.user.ReduceFunction;

namespace br.ufc.mdcc.mapreduce.example.graph.clique.CliqueReduce { 
	public interface ICliqueReduce: BaseICliqueReduce, IReduceFunction<IInteger, IKVPair<IInteger, IIterator<IInteger>>, IKVPair<IInteger, IKVPair<IInteger, IIterator<IInteger>>>>{

	} // end main interface 
} // end namespace 

//where OMK: IInteger
//where OMV: IKVPair<IInteger, IIterator<IInteger>>
//where ORV: IKVPair<IInteger, IKVPair<IInteger, IIterator<IInteger>>>