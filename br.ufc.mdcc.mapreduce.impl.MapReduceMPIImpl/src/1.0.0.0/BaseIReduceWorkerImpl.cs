/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.farm.Farm;
using br.ufc.mdcc.mapreduce.Shuffler;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.Combiner;
using br.ufc.mdcc.mapreduce.Reducer;
using br.ufc.mdcc.mapreduce.user.ReduceFunction;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.MapReduce;

namespace br.ufc.mdcc.mapreduce.impl.MapReduceMPIImpl { 

	public abstract class BaseIReduceWorkerImpl<OMK, OMV, ORV, Rf, PLATFORM>: Computation, BaseIReduceWorker<OMK, OMV, ORV, Rf, PLATFORM>
	where OMK:IData
	where ORV:IData
	where Rf:IReduceFunction<OMK,OMV,ORV>
	where OMV:IData
	where PLATFORM:IPlatform
	{

			private IWorker<ITargetShuffler<OMK, OMV>, IReducer<OMK, OMV, ORV, Rf>, ISourceCombiner<ORV>, IIterator<IKVPair<OMK,IIterator<OMV>>>, IIterator<ORV>, PLATFORM> farm_reduce = null; 

			protected IWorker<ITargetShuffler<OMK, OMV>, IReducer<OMK, OMV, ORV, Rf>, ISourceCombiner<ORV>, IIterator<IKVPair<OMK,IIterator<OMV>>>, IIterator<ORV>, PLATFORM> Farm_reduce {
			get {
				if (this.farm_reduce == null)
							this.farm_reduce = (IWorker<ITargetShuffler<OMK, OMV>, IReducer<OMK, OMV, ORV, Rf>, ISourceCombiner<ORV>, IIterator<IKVPair<OMK,IIterator<OMV>>>, IIterator<ORV>, PLATFORM>) Services.getPort("farm_reduce");
				return this.farm_reduce;
			}
	}




}

}
