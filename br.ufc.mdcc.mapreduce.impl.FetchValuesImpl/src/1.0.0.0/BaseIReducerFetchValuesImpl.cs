/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.mapreduce.FetchValues;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.KVPair;

namespace br.ufc.mdcc.mapreduce.impl.FetchValuesImpl { 

public abstract class BaseIReducerFetchValuesImpl<OMK,OMV>: Synchronizer, BaseIFetchValuesReducer<OMK,OMV>
	where OMK:IData
	where OMV:IData
{

	private IIterator<IKVPair<OMK,IIterator<OMV>>> reduce_job = null;

	public IIterator<IKVPair<OMK,IIterator<OMV>>> Reduce_job {
	get {
		if (this.reduce_job == null)
				this.reduce_job = (IIterator<IKVPair<OMK,IIterator<OMV>>>) Services.getPort("reduce_job");
		return this.reduce_job;
	}
}



}

}
