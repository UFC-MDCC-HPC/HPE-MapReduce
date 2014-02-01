using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.farm.Scatter;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.farm.Gather;
using br.ufc.mdcc.farm.Work;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.farm.Farm;

namespace br.ufc.mdcc.farm.impl.FarmImpl { 

public class IWorkerImpl<S, J, C, R, W, P> : BaseIWorkerImpl<S, J, C, R, W, P>, IWorker<S, J, C, R, W, P>
where S:IScatterTarget<J>
where J:IData
where C:IGatherSource<R>
where R:IData
where W:IWork<J, R>
where P:IPlatform
{

public IWorkerImpl() { 

} 

public override void main() { 

}

}

}
