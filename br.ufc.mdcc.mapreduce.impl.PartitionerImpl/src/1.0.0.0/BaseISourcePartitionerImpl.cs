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
using br.ufc.mdcc.mapreduce.FetchValues;

namespace br.ufc.mdcc.mapreduce.impl.PartitionerImpl { 

public abstract class BaseISourcePartitionerImpl<OMK, OMV, P>: 
	Synchronizer, BaseISourcePartition<OMK, OMV, P>
where OMK:IData
where OMV:IData
where P:IPartitionFunction<OMK>
{


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

		private IFetchValuesMapper<P,OMK,OMV> fetch_values = null;

		public IFetchValuesMapper<P,OMK,OMV> Fetch_values {
			get {
				if (this.fetch_values == null)
					this.fetch_values = (IFetchValuesMapper<P,OMK,OMV>) Services.getPort("fetch_values");
				return this.fetch_values;
			}

		}

}

}
