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

public abstract class BaseIMapperFetchValuesImpl<OMK,OMV>: Synchronizer, BaseIFetchValuesMapper<OMK,OMV>
		where OMK:IData
		where OMV:IData
{

	private IIterator<IKVPair<OMK,OMV>> map_result = null;

	public IIterator<IKVPair<OMK,OMV>> Map_result {
	get {
		if (this.map_result == null)
				this.map_result = (IIterator<IKVPair<OMK,OMV>>) Services.getPort("map_result");
		return this.map_result;
	}
}



}

}
