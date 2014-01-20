/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.farm.Scatter;
using br.ufc.mdcc.farm.Gather;
using br.ufc.mdcc.farm.Work;
using br.ufc.mdcc.common.Platform;

namespace br.ufc.mdcc.farm.Farm { 

public interface BaseIWorker<S, J, C, R, W, P> : IComputationKind 
where S:IScatterTarget<J>
where J:IData
where C:IGatherSource<R>
where R:IData
where W:IWork<J, R>
where P:IPlatform
{



} // end main interface 

} // end namespace 
