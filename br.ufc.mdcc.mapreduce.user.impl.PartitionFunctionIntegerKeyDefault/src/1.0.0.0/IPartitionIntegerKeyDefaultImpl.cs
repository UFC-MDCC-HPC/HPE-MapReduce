using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.mapreduce.user.PartitionFunction;


namespace br.ufc.mdcc.mapreduce.user.impl.PartitionFunctionIntegerKeyDefault { 

	public class IPartitionIntegerKeyDefaultImpl<OMK> : BaseIPartitionIntegerKeyDefaultImpl<OMK>, IPartitionFunction<OMK>
	where OMK:IInteger
	{
		public IPartitionIntegerKeyDefaultImpl() { } 

		private int number_of_partitions;
		public int NumberOfPartitions {
			get { return number_of_partitions; }
			set { this.number_of_partitions = value; }
		}

		public override void main() 
		{ 
			IIntegerInstance input_string_instance = (IIntegerInstance) Input_key.Instance;
			IIntegerInstance output_string_instance = (IIntegerInstance) Output_key.Instance;

			int value = (int) input_string_instance.Value;

			output_string_instance.Value = value % NumberOfPartitions;


		}
	}

}
