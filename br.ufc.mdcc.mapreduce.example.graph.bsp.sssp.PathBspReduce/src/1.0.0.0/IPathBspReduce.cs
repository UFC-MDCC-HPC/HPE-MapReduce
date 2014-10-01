using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.user.ReduceFunction;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.common.KVPair;
using System.Collections.Generic;

namespace br.ufc.mdcc.mapreduce.example.graph.bsp.sssp.PathBspReduce { 

	public interface IPathBspReduce : BaseIPathBspReduce, IReduceFunction<IString, IString, IKVPair<IString, IString>>
{
		void clearNeighbours ();

		IDictionary<int, string> CandidatesBuffer{ get; }
		IList<int> Vertexs{ get;}
		void clearCandidatesBuffer();
		void step(int key, double valor);
		int Active{ get; set;}
		IDictionary<int, double> Di{ get; set; }
		void apply ();

} // end main interface 

} // end namespace 
