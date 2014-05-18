/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.farm.Work;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.farm.Scatter;
using br.ufc.mdcc.farm.Gather;
using br.ufc.mdcc.farm.Farm;

namespace br.ufc.mdcc.farm.impl.FarmImpl { 

public abstract class BaseIWorkerImpl<S, W, C, J, R, P>: Computation, BaseIWorker<S, W, C, J, R, P>
where S:IScatterTarget<J>
where J:IData
where C:IGatherSource<R>
where R:IData
where W:IWork<J, R>
where P:IPlatform
{

private W work = default(W);

protected W Work {
	get {
		if (this.work == null)
			this.work = (W) Services.getPort("work");
		return this.work;
	}
}

private P platform = default(P);

protected P Platform {
	get {
		if (this.platform == null)
			this.platform = (P) Services.getPort("platform");
		return this.platform;
	}
}

private S scatter = default(S);

protected S Scatter {
	get {
		if (this.scatter == null)
			this.scatter = (S) Services.getPort("scatter");
		return this.scatter;
	}
}

private R result = default(R);

protected R Result {
	get {
		if (this.result == null)
			this.result = (R) Services.getPort("result");
		return this.result;
	}
}


private C gather = default(C);

protected C Gather {
	get {
		if (this.gather == null)
			this.gather = (C) Services.getPort("gather");
		return this.gather;
	}
}

private J job = default(J);

protected J Job {
	get {
		if (this.job == null)
			this.job = (J) Services.getPort("job");
		return this.job;
	}
}

	

}

}
