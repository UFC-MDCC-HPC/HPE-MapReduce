using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Platform;

namespace br.ufc.mdcc.mapreduce.example.graph.clique.CliqueApp { 

	public interface ICliqueReduceProcess<PLATFORM> : BaseICliqueReduceProcess<PLATFORM> where PLATFORM:IPlatform {

	} // end main interface 
} // end namespace 
