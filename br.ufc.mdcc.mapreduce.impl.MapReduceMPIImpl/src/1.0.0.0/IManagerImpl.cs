using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.user.SplitFunction;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.MapReduce;
using br.ufc.mdcc.mapreduce.user.PartitionFunction;
using br.ufc.mdcc.mapreduce.user.CombineFunction;

namespace br.ufc.mdcc.mapreduce.impl.MapReduceMPIImpl { 

	public class IManagerImpl<In, IMK, IMV, Sf, Bf, OMK, ORV, Cf, Out, PLATFORM> : BaseIManagerImpl<In, IMK, IMV, Sf, Bf, OMK, ORV, Cf, Out, PLATFORM>, IManagerMapReduce<In, IMK, IMV, Sf, Bf, OMK, ORV, Cf, Out, PLATFORM>
		where In:IData
		where IMK:IData
		where IMV:IData
		where Sf:ISplitFunction<In, IMK, IMV>
		where Bf:IPartitionFunction<IMK>
		where Cf:ICombineFunction<ORV,Out>
		where OMK:IData
		where PLATFORM:IPlatform
		where ORV:IData
		where Out:IData
{

public IManagerImpl() { 

} 

	public override void main() 
	{ 

	 
	}

}

}
