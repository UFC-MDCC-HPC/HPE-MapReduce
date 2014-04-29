using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.mapreduce.user.CombineFunction;

namespace br.ufc.mdcc.mapreduce.user.impl.CombineFunctionDefaultIdentity { 

	public class ICombineIdentityImpl<ORV, Out> : BaseICombineIdentityImpl<ORV, Out>, ICombineFunction<ORV, Out>
	where ORV:IData
	where Out:IIterator<ORV>
	{
		public ICombineIdentityImpl() { } 

		public override void main() 
		{ 
			IIteratorInstance<ORV> input_data_instance = (IIteratorInstance<ORV>) Input_data.Instance;
			IIteratorInstance<ORV> output_data_instance = (IIteratorInstance<ORV>) Output_data.Instance;

			while (!input_data_instance.HasFinished)
			{
				ORV item = (ORV) input_data_instance.fetch_next();
				output_data_instance.put(item);
			}
		}
	}

}
