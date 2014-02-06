/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.farm.Farm;
using br.ufc.mdcc.mapreduce.Splitter;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.mapreduce.Partitioner;
using br.ufc.mdcc.mapreduce.user.PartitionFunction;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.mapreduce.Mapper;
using br.ufc.mdcc.mapreduce.user.MapFunction;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.MapReduce;

namespace br.ufc.mdcc.mapreduce.impl.MapReduceMPIImpl { 

public abstract class BaseIMapWorkerImpl<IMK, IMV, OMK, OMV, Pf, Mf, PLATFORM>: Computation, BaseIMapWorker<IMK, IMV, OMK, OMV, Pf, Mf, PLATFORM>
where IMK:IData
where IMV:IData
where OMK:IData
where OMV:IData
where Pf:IPartitionFunction<OMK>
where Mf:IMapFunction<IMK, IMV, OMK, OMV>
where PLATFORM:IPlatform
{

		private IWorker<ITargetSplitter<IMK, IMV>, IIterator<IKVPair<IMK, IMV>>, ISourcePartition<OMK, OMV, Pf>, IIterator<IKVPair<OMK, OMV>>, IMapper<IMK, IMV, OMK, OMV, Mf>, PLATFORM> farm_map = null;

		protected IWorker<ITargetSplitter<IMK, IMV>, IIterator<IKVPair<IMK, IMV>>, ISourcePartition<OMK, OMV, Pf>, IIterator<IKVPair<OMK, OMV>>, IMapper<IMK, IMV, OMK, OMV, Mf>, PLATFORM> Farm_map {
	get {
		if (this.farm_map == null)
					this.farm_map = (IWorker<ITargetSplitter<IMK, IMV>, IIterator<IKVPair<IMK, IMV>>, ISourcePartition<OMK, OMV, Pf>, IIterator<IKVPair<OMK, OMV>>, IMapper<IMK, IMV, OMK, OMV, Mf>, PLATFORM>) Services.getPort("farm_map");
		return this.farm_map;
	}
}



}

}
