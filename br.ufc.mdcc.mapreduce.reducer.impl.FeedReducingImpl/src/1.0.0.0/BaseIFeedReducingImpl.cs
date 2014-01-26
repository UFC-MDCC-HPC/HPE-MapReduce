/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.KMVPair;
using br.ufc.mdcc.mapreduce.reducer.FeedReducing;

namespace br.ufc.mdcc.mapreduce.reducer.impl.FeedReducingImpl { 

public abstract class BaseIFeedReducingImpl<OMV, OMK>: Computation, BaseIFeedReducing<OMV, OMK>
where OMV:IData
where OMK:IData
{

private IIterator<OMV> output_value = null;

public IIterator<OMV> Output_value {
	get {
		if (this.output_value == null)
			this.output_value = (IIterator<OMV>) Services.getPort("output_value");
		return this.output_value;
	}
}

private OMK output_key = default(OMK);

public OMK Output_key {
	get {
		if (this.output_key == null)
			this.output_key = (OMK) Services.getPort("output_key");
		return this.output_key;
	}
}

	private IIterator<IKMVPair<OMK, OMV>> input = null;

	public IIterator<IKMVPair<OMK, OMV>> Input {
	get {
		if (this.input == null)
					this.input = (IIterator<IKMVPair<OMK, OMV>>) Services.getPort("input");
		return this.input;
	}
}



}

}
