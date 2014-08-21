using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.mapreduce.user.MapFunction;
using br.ufc.mdcc.mapreduce.example.graph.clique.CliqueNode;
//using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.String;

namespace br.ufc.mdcc.mapreduce.example.graph.clique.CliqueMap { 
	public interface ICliqueMap: BaseICliqueMap, IMapFunction<IInteger, ICliqueNode, IString, ICliqueNode>{

	} // end main interface 
} // end namespace 
//IMapFunction<IMK, IMV, OMK, OMV>