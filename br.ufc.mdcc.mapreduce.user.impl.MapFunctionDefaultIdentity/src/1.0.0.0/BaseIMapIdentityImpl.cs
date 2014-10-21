/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.user.MapFunction;

namespace br.ufc.mdcc.mapreduce.user.impl.MapFunctionDefaultIdentity { 

public abstract class BaseIMapIdentityImpl<IMK, IMV, OMK, OMV>: Computation, BaseIMapFunction<IMK, IMV, OMK, OMV>
where IMK:IData
where IMV:IData
where OMV:IData
where OMK:IData
{

private IIterator<IKVPair<OMK, OMV>> output_data = null;

public IIterator<IKVPair<OMK, OMV>> Output_data {
	get {
		if (this.output_data == null)
			this.output_data = (IIterator<IKVPair<OMK, OMV>>) Services.getPort("output_data");
		return this.output_data;
	}
}

private IMK input_key = default(IMK);

public IMK Input_key {
	get {
		if (this.input_key == null)
			this.input_key = (IMK) Services.getPort("input_key");
		return this.input_key;
	}
}

private IMV input_value = default(IMV);

public IMV Input_value {
	get {
		if (this.input_value == null)
			this.input_value = (IMV) Services.getPort("input_value");
		return this.input_value;
	}
}



}

}
