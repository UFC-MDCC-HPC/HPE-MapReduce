/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.mapreduce.user.PartitionFunction;
using br.ufc.mdcc.mapreduce.user.MapFunction;
using br.ufc.mdcc.common.Platform;

namespace br.ufc.mdcc.mapreduce.MapReduce { 

	public interface BaseIMapWorker<IMK, IMV, OMK, OMV, OPK, Pf, Mf, PLATFORM> : IComputationKind 
		where IMK:IData
		where IMV:IData
		where OPK:IData
		where OMK:IData
		where OMV:IData
		where Pf:IPartitionFunction<OMK, OPK>
		where Mf:IMapFunction<IMK, IMV,OMK,OMV>
		where PLATFORM:IPlatform
		{


		} // end main interface 

} // end namespace 
