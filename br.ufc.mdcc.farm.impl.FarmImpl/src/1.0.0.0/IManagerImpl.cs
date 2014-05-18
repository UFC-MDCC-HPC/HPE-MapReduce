using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.farm.Scatter;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.farm.Gather;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.farm.Farm;
using System.Threading.Tasks;

namespace br.ufc.mdcc.farm.impl.FarmImpl { 

public class IManagerImpl<S, C, I, O, P> : BaseIManagerImpl<S, C, I, O, P>, IManager<S, C, I, O, P>
where S:IScatterSource<I>
where I:IData
where C:IGatherTarget<O>
where O:IData
where P:IPlatform
{

public IManagerImpl() {} 

public override void main() 
{ 
	Task scatter_task = new Task(delegate {this.Scatter.go();});
	Task gather_task = new Task(delegate {this.Gather.go();});

	scatter_task.Start();
	gather_task.Start();

	gather_task.Wait();
	scatter_task.Wait();
}


}

}
