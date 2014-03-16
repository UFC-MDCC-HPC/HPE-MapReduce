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
			while (!Input_data.HasFinished)
			{
				ORV item = Input_data.fetch_next();
				Output_data.put(item);
			}
		}
	}

}
