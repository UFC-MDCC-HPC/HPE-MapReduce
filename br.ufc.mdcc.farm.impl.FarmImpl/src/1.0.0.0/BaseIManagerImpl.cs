/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.farm.Scatter;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.farm.Gather;
using br.ufc.mdcc.farm.Farm;

namespace br.ufc.mdcc.farm.impl.FarmImpl { 

public abstract class BaseIManagerImpl<S, I, C, O, P>: Computation, BaseIManager<S, I, C, O, P>
where S:IScatterSource<I>
where I:IData
where C:IGatherTarget<O>
where O:IData
where P:IPlatform
{

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

private C gather = default(C);

protected C Gather {
	get {
		if (this.gather == null)
			this.gather = (C) Services.getPort("gather");
		return this.gather;
	}
}

private O output = default(O);

public O Output {
	get {
		if (this.output == null)
			this.output = (O) Services.getPort("output");
		return this.output;
	}
}

private I input = default(I);

public I Input {
	get {
		if (this.input == null)
			this.input = (I) Services.getPort("input");
		return this.input;
	}
}

	

}

}
