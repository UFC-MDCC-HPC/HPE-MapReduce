/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KMVPair;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.PutItemIntoStream;
using br.ufc.mdcc.mapreduce.reducer.FeedReducing;
using br.ufc.mdcc.mapreduce.user.ReduceFunction;
using br.ufc.mdcc.mapreduce.Reducer;

namespace br.ufc.mdcc.mapreduce.impl.ReducerImpl { 

	public abstract class BaseIWorkReducerImpl<OMK, OMV, ORV, R>: Computation, BaseIReducer<OMK, OMV, ORV, R>
where OMK:IData
where OMV:IData
where ORV:IData
where R:IReduceFunction<ORV, OMK, OMV>
{

	private IIterator<IKMVPair<OMK,OMV>> input = null;

	public IIterator<IKMVPair<OMK,OMV>> Input {
	get {
		if (this.input == null)
					this.input = (IIterator<IKMVPair<OMK,OMV>>) Services.getPort("input");
		return this.input;
	}
}

private IIterator<OMV> values = null;

protected IIterator<OMV> Values {
	get {
		if (this.values == null)
			this.values = (IIterator<OMV>) Services.getPort("values");
		return this.values;
	}
}


private IIterator<ORV> output = null;

public IIterator<ORV> Output {
	get {
		if (this.output == null)
				this.output = (IIterator<ORV>) Services.getPort("output");
		return this.output;
	}
}

private IPutItemIntoStream<IData> put_item = null;

protected IPutItemIntoStream<IData> Put_item {
	get {
		if (this.put_item == null)
			this.put_item = (IPutItemIntoStream<IData>) Services.getPort("put_item");
		return this.put_item;
	}
}

private IFeedReducing<OMV, OMK> feed_reducing = null;

protected IFeedReducing<OMV, OMK> Feed_reducing {
	get {
		if (this.feed_reducing == null)
			this.feed_reducing = (IFeedReducing<OMV, OMK>) Services.getPort("feed_reducing");
		return this.feed_reducing;
	}
}

private R reduce_function = default(R);

protected R Reduce_function {
	get {
		if (this.reduce_function == null)
			this.reduce_function = (R) Services.getPort("reduce_function");
		return this.reduce_function;
	}
}



private ORV output_item = default(ORV);

protected ORV Output_item {
	get {
		if (this.output_item == null)
			this.output_item = (ORV) Services.getPort("output_item");
		return this.output_item;
	}
}

private OMK key = default(OMK);

protected OMK Key {
	get {
		if (this.key == null)
			this.key = (OMK) Services.getPort("key");
		return this.key;
	}
}



}

}
