/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.mapreduce.mapper.FeedMapping;

namespace br.ufc.mdcc.mapreduce.mapper.impl.FeedMappingImpl { 

public abstract class BaseIFeedMappingImpl<IMV, IMK>: Computation, BaseIFeedMapping<IMV, IMK>
where IMV:IData
where IMK:IData
{

private IMK output_key = default(IMK);

public IMK Output_key {
	get {
		if (this.output_key == null)
			this.output_key = (IMK) Services.getPort("output_key");
		return this.output_key;
	}
}

private IMV output_value = default(IMV);

public IMV Output_value {
	get {
		if (this.output_value == null)
			this.output_value = (IMV) Services.getPort("output_value");
		return this.output_value;
	}
}

private IIterator<IKVPair<IMK, IMV>> input = null;

public IIterator<IKVPair<IMK, IMV>> Input {
	get {
		if (this.input == null)
			this.input = (IIterator<IKVPair<IMK, IMV>>) Services.getPort("input");
		return this.input;
	}
}



}

}
