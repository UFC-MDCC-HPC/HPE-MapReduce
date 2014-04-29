using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.user.ReduceFunction;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.MapReduce;

namespace br.ufc.mdcc.mapreduce.impl.MapReduceMPIImpl { 

	public class IReduceWorkerImpl<OMK, OMV, ORV, Rf, PLATFORM> : BaseIReduceWorkerImpl<OMK, OMV, ORV, Rf, PLATFORM>, IReduceWorker<OMK, OMV, ORV, Rf, PLATFORM>
		where OMK:IData
		where ORV:IData
		where Rf:IReduceFunction<OMK, OMV, ORV>
		where OMV:IData
		where PLATFORM:IPlatform
		{

			public IReduceWorkerImpl() { } 

			public override void main() 
			{ 
				Farm_reduce.go();
			}

		}

}
