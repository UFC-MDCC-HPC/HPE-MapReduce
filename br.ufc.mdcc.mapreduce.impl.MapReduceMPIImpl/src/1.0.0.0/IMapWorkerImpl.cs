using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.user.PartitionFunction;
using br.ufc.mdcc.mapreduce.user.MapFunction;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.MapReduce;

namespace br.ufc.mdcc.mapreduce.impl.MapReduceMPIImpl { 

public class IMapWorkerImpl<IMK, IMV, OMK, OMV, Pf, Mf, PLATFORM> : BaseIMapWorkerImpl<IMK, IMV, OMK, OMV, Pf, Mf, PLATFORM>, IMapWorker<IMK, IMV, OMK, OMV, Pf, Mf, PLATFORM>
where IMK:IData
where IMV:IData
where OMK:IData
where OMV:IData
where Pf:IPartitionFunction<OMK>
where Mf:IMapFunction<IMK, IMV, OMK, OMV>
where PLATFORM:IPlatform
{

public IMapWorkerImpl() { 

} 

		public override void main() { 
}

}

}
