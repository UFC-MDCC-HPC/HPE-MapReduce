/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.mapreduce.Shuffler;

namespace br.ufc.mdcc.mapreduce.impl.ShufflerImpl { 

	public abstract class BaseITargetShufflerImpl<OMK, OMV>: Synchronizer, BaseITargetShuffler<OMK, OMV>
where OMK:IData
where OMV:IData
{

	private IIterator<IKVPair<OMK,IIterator<OMV>>> target_data = null;

	public IIterator<IKVPair<OMK,IIterator<OMV>>> Target_data {
	get {
		if (this.target_data == null)
				this.target_data = (IIterator<IKVPair<OMK,IIterator<OMV>>>) Services.getPort("target_data");
		return this.target_data;
	}
}


}

}
