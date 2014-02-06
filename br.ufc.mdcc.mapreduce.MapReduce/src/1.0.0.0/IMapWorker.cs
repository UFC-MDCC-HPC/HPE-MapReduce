using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.user.PartitionFunction;
using br.ufc.mdcc.mapreduce.user.MapFunction;
using br.ufc.mdcc.common.Platform;

namespace br.ufc.mdcc.mapreduce.MapReduce { 

	public interface IMapWorker<IMK, IMV, OMK, OMV, Pf, Mf, PLATFORM> : 
	BaseIMapWorker<IMK, IMV, OMK, OMV, Pf, Mf, PLATFORM>
		where IMK:IData
		where IMV:IData
		where OMK:IData
		where OMV:IData
		where Pf:IPartitionFunction<OMK>
		where Mf:IMapFunction<IMK, IMV, OMK, OMV>
		where PLATFORM:IPlatform
		{


		} // end main interface 

} // end namespace 
