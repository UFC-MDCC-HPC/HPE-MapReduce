/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.partitioner.GatherPartitionInfo;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.mapreduce.Partitioner;

namespace br.ufc.mdcc.mapreduce.impl.PartitionerImpl { 

public abstract class BaseITargetPartitionerImpl<OMK, OPK>: 
	Synchronizer, BaseITargetPartition<OMK, OPK>
where OMK:IData
where OPK:IData
{

private ITargetGatherPartitionInfo<OMK, OPK> gather_partition_info = null;

protected ITargetGatherPartitionInfo<OMK, OPK> Gather_partition_info {
	get {
		if (this.gather_partition_info == null)
			this.gather_partition_info = (ITargetGatherPartitionInfo<OMK, OPK>) Services.getPort("gather_partition_info");
		return this.gather_partition_info;
	}
}

private IIterator<IKVPair<OMK, OPK>> target_data = null;

public IIterator<IKVPair<OMK, OPK>> Target_data {
	get {
		if (this.target_data == null)
			this.target_data = (IIterator<IKVPair<OMK, OPK>>) Services.getPort("target_data");
		return this.target_data;
	}
}


}

}
