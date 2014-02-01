using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.farm.Scatter;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.farm.Gather;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.farm.Farm;

namespace br.ufc.mdcc.farm.impl.FarmImpl { 

public class IManagerImpl<S, I, C, O, P> : BaseIManagerImpl<S, I, C, O, P>, IManager<S, I, C, O, P>
where S:IScatterSource<I>
where I:IData
where C:IGatherTarget<O>
where O:IData
where P:IPlatform
{

public IManagerImpl() { 

} 

public override void main() 
{ 

}


}

}
