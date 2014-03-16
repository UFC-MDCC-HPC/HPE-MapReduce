using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.mapreduce.user.PartitionFunction;

namespace br.ufc.mdcc.mapreduce.user.impl.PartitionFunctionStringKeyDefault { 

	public class IPartitionStringKeyDefaultImpl<OMK> : BaseIPartitionStringKeyDefaultImpl<OMK>, IPartitionFunction<OMK>
	where OMK:IString
	{
		public IPartitionStringKeyDefaultImpl() { } 

		private int number_of_partitions;
		public int NumberOfPartitions {
			get { return number_of_partitions; }
			set { this.number_of_partitions = value; }
		}

		public override void main() 
		{ 
			int value = Input_key.Value.GetHashCode();
			Output_key.Value = value % NumberOfPartitions;
		}
	}

}
