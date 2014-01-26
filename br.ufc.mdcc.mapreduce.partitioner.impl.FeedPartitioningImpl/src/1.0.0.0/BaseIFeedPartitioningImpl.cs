/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.mapreduce.partitioner.FeedPartitioning;

namespace br.ufc.mdcc.mapreduce.partitioner.impl.FeedPartitioningImpl { 

public abstract class BaseIFeedPartitioningImpl<OMK, OPK, OMV>: 
	Computation, BaseIFeedPartitioning<OMK, OPK, OMV>
where OMK:IData
where OPK:IData
where OMV:IData
{

private OPK partition_key = default(OPK);

public OPK Partition_key {
	get {
		if (this.partition_key == null)
			this.partition_key = (OPK) Services.getPort("partition_key");
		return this.partition_key;
	}
}

private OMK data_key = default(OMK);

public OMK Data_key {
	get {
		if (this.data_key == null)
			this.data_key = (OMK) Services.getPort("data_key");
		return this.data_key;
	}
}

private IIterator<IKVPair<OMK, OMV>> data = null;

public IIterator<IKVPair<OMK, OMV>> Data {
	get {
		if (this.data == null)
			this.data = (IIterator<IKVPair<OMK, OMV>>) Services.getPort("data");
		return this.data;
	}
}

private IIterator<IKVPair<OMK, OPK>> partition_info = null;

public IIterator<IKVPair<OMK, OPK>> Partition_info {
	get {
		if (this.partition_info == null)
			this.partition_info = (IIterator<IKVPair<OMK, OPK>>) Services.getPort("partition_info");
		return this.partition_info;
	}
}





}

}
