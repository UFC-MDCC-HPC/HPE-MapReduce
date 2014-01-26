/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.splitter.ScatterSplitData;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.mapreduce.Splitter;

namespace br.ufc.mdcc.mapreduce.impl.SplitterImpl { 

public abstract class BaseITargetSplitterImpl<IMK, IMV>: Synchronizer, BaseITargetSplitter<IMK, IMV>
where IMK:IData
where IMV:IData
{

private ITargetScatterSplitData<IMK, IMV> send_bins = null;

protected ITargetScatterSplitData<IMK, IMV> Send_bins {
	get {
		if (this.send_bins == null)
			this.send_bins = (ITargetScatterSplitData<IMK, IMV>) Services.getPort("send_bins");
		return this.send_bins;
	}
}


private IIterator<IKVPair<IMK, IMV>> target_data = null;

public IIterator<IKVPair<IMK, IMV>> Target_data {
	get {
		if (this.target_data == null)
			this.target_data = (IIterator<IKVPair<IMK, IMV>>) Services.getPort("target_data");
		return this.target_data;
	}
}




}

}
