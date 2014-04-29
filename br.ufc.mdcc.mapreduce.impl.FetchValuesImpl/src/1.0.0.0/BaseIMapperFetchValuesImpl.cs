/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.mapreduce.FetchValues;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.mapreduce.user.PartitionFunction;
using environment.MPIDirect;

namespace br.ufc.mdcc.mapreduce.impl.FetchValuesImpl { 

	public abstract class BaseIMapperFetchValuesImpl<OMK,OMV,P>: Synchronizer, BaseIFetchValuesMapper<OMK,OMV,P>
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



	private IIterator<IKVPair<OMK,OMV>> map_result = null;

	public IIterator<IKVPair<OMK,OMV>> Map_result {
		get {
			if (this.map_result == null)
					this.map_result = (IIterator<IKVPair<OMK,OMV>>) Services.getPort("map_result");
			return this.map_result;
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
