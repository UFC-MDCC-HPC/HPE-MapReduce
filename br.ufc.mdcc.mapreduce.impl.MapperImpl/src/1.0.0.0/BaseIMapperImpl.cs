/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.mapper.FeedMapping;
using br.ufc.mdcc.mapreduce.user.MapFunction;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.mapreduce.Mapper;

namespace br.ufc.mdcc.mapreduce.impl.MapperImpl { 

public abstract class BaseIMapperImpl<IMK, IMV, OMK, OMV, M>: 
	Computation, BaseIMapper<IMK, IMV, OMK, OMV, M>
where IMK:IData
where IMV:IData
where OMK:IData
where OMV:IData
where M:IMapFunction<IMK, IMV, OMK, OMV>
{



private IFeedMapping<IMV, IMK> feed_mapping = null;

protected IFeedMapping<IMV, IMK> Feed_mapping {
	get {
		if (this.feed_mapping == null)
			this.feed_mapping = (IFeedMapping<IMV, IMK>) Services.getPort("feed_mapping");
		return this.feed_mapping;
	}
}

private M map_function = default(M);

protected M Map_function {
	get {
		if (this.map_function == null)
			this.map_function = (M) Services.getPort("map_function");
		return this.map_function;
	}
}

private IMK map_key = default(IMK);

protected IMK Map_key {
	get {
		if (this.map_key == null)
			this.map_key = (IMK) Services.getPort("map_key");
		return this.map_key;
	}
}

private IIterator<IKVPair<OMK, OMV>> output = null;

public IIterator<IKVPair<OMK, OMV>> Output {
	get {
		if (this.output == null)
			this.output = (IIterator<IKVPair<OMK, OMV>>) Services.getPort("output");
		return this.output;
	}
}

private IMV map_value = default(IMV);

protected IMV Map_value {
	get {
		if (this.map_value == null)
			this.map_value = (IMV) Services.getPort("map_value");
		return this.map_value;
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
