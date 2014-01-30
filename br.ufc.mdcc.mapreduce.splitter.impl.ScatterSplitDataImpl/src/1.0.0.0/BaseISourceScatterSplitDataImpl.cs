/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.splitter.ScatterSplitData;

namespace br.ufc.mdcc.mapreduce.splitter.impl.ScatterSplitDataImpl { 

public abstract class BaseISourceScatterSplitDataImpl<IMK, IMV>: Synchronizer, BaseISourceScatterSplitData<IMK, IMV>
where IMK:IData
where IMV:IData
{

private IIterator<IKVPair<IMK, IMV>> bins = null;

public IIterator<IKVPair<IMK, IMV>> Bins {
	get {
		if (this.bins == null)
				this.bins = (IIterator<IKVPair<IMK, IMV>>) Services.getPort("bins");
		return this.bins;
	}
}




}

}
