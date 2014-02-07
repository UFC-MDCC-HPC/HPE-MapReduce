using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.user.SplitFunction;
using br.ufc.mdcc.mapreduce.user.PartitionFunction;
using br.ufc.mdcc.mapreduce.user.CombineFunction;

namespace br.ufc.mdcc.mapreduce.MapReduce { 

	public interface IManagerMapReduce<In, IMK, IMV, Sf, Bf, OMK, ORV, Cf, Out, PLATFORM> : 
	BaseIManagerMapReduce<In, IMK, IMV, Sf, Bf, OMK, ORV, Cf, Out, PLATFORM>
		where In:IData
		where IMK:IData
		where IMV:IData
		where OMK:IData
		where ORV:IData
		where Out:IData
		where Sf:ISplitFunction<In, IMK, IMV>
		where Bf:IPartitionFunction<IMK>
		where Cf:ICombineFunction<ORV,Out>
		where PLATFORM:IPlatform
{


} // end main interface 

} // end namespace 
