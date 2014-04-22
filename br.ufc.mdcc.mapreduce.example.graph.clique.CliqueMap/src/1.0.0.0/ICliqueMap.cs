using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.mapreduce.user.MapFunction;
using br.ufc.mdcc.mapreduce.example.graph.clique.CliqueNode;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Iterator;

namespace br.ufc.mdcc.mapreduce.example.graph.clique.CliqueMap { 
	public interface ICliqueMap: BaseICliqueMap, IMapFunction<IInteger, ICliqueNode<IInteger>, IInteger, IKVPair<IInteger, IIterator<IInteger>>> {

	} // end main interface 
} // end namespace 

//where IMK:IInteger
//where IMV:ICliqueNode<IInteger>
//where OMK: IInteger
//where OMV: IKVPair<IInteger, IIterator<IInteger>>