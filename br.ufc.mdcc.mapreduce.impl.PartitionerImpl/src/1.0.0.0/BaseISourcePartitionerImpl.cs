/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.mapreduce.user.PartitionFunction;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.mapreduce.Partitioner;
using environment.MPIDirect;

namespace br.ufc.mdcc.mapreduce.impl.PartitionerImpl { 

public abstract class BaseISourcePartitionerImpl<OMK, OMV, P>: 
	Synchronizer, BaseISourcePartition<OMK, OMV, P>
where OMK:IData
where OMV:IData
where P:IPartitionFunction<OMK>
{



private IInteger partition_key = default(IInteger);

protected IInteger Partition_key {
	get {
		if (this.partition_key == null)
				this.partition_key = (IInteger) Services.getPort("partition_key");
		return this.partition_key;
	}
}

private P partition_function = default(P);

protected P Partition_function {
	get {
		if (this.partition_function == null)
			this.partition_function = (P) Services.getPort("partition_function");
		return this.partition_function;
	}
}



private OMK data_key = default(OMK);

protected OMK Data_key {
	get {
		if (this.data_key == null)
			this.data_key = (OMK) Services.getPort("data_key");
		return this.data_key;
	}
}

private IIterator<IKVPair<OMK, OMV>> source_data = null;

public IIterator<IKVPair<OMK, OMV>> Source_data {
	get {
		if (this.source_data == null)
			this.source_data = (IIterator<IKVPair<OMK, OMV>>) Services.getPort("source_data");
		return this.source_data;
	}
}

private IIterator<IKVPair<OMK, IInteger>> output_partition_info_source = null;

protected IIterator<IKVPair<OMK, IInteger>> Output_partition_info_source {
	get {
		if (this.output_partition_info_source == null)
			this.output_partition_info_source = (IIterator<IKVPair<OMK, IInteger>>) Services.getPort("output_partition_info_source");
		return this.output_partition_info_source;
	}
}

private  IMPIDirect mpi_comm = null;

protected IMPIDirect Mpi_comm {
	get {
		if (this.mpi_comm == null) 
		{
			this.mpi_comm = (IMPIDirect) Services.getPort("mpi_comm");
		}
		return this.mpi_comm;
	}
}


}

}
