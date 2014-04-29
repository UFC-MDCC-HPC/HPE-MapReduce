using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.mapreduce.user.PartitionFunction;
using br.ufc.mdcc.common.Integer;

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
			IStringInstance input_string_instance = (IStringInstance) Input_key.Instance;
			IIntegerInstance output_string_instance = (IIntegerInstance) Output_key.Instance;

			int value = input_string_instance.Value.GetHashCode();

			output_string_instance.Value = value % NumberOfPartitions;
		}
	}

}
