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
using System.Threading.Tasks;

namespace br.ufc.mdcc.farm.impl.FarmImpl { 

public class IWorkerImpl<S, W, C, J, R, P> : BaseIWorkerImpl<S, W, C, J, R, P>, IWorker<S, W, C, J, R, P>
where S:IScatterTarget<J>
where J:IData
where C:IGatherSource<R>
where R:IData
where W:IWork<J, R>
where P:IPlatform
{

	public IWorkerImpl() { } 

	public override void main() 
	{ 
			Task scatter_task = new Task(delegate {this.Scatter.go();});
			Task work_task  = new Task(delegate {this.Work.go();});
			Task gather_task = new Task(delegate {this.Gather.go();});

			scatter_task.Start();
			work_task.Start();
			gather_task.Start();

			gather_task.Wait();
			work_task.Wait();
			scatter_task.Wait();
	}

}

}
