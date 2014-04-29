/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.farm.Farm;
using br.ufc.mdcc.mapreduce.Splitter;
using br.ufc.mdcc.mapreduce.user.SplitFunction;
using br.ufc.mdcc.mapreduce.Partitioner;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.Shuffler;
using br.ufc.mdcc.mapreduce.Combiner;
using br.ufc.mdcc.mapreduce.MapReduce;
using br.ufc.mdcc.mapreduce.user.PartitionFunction;
using br.ufc.mdcc.mapreduce.user.CombineFunction;

namespace br.ufc.mdcc.mapreduce.impl.MapReduceMPIImpl { 

	public abstract class BaseIManagerImpl<In, IMK, IMV, OMK, ORV, Out, Sf, Bf, Cf, PLATFORM>: 
	                             Computation, BaseIManagerMapReduce<In, IMK, IMV, OMK, ORV, Out, Sf, Bf, Cf, PLATFORM>
		where In:IData
		where IMK:IData
		where IMV:IData
		where Sf:ISplitFunction<In, IMK, IMV>
		where Bf:IPartitionFunction<IMK>
		where Cf:ICombineFunction<ORV,Out>
		where OMK:IData
		where ORV:IData
		where Out:IData
		where PLATFORM:IPlatform
{

private In input_data = default(In);

public In Input_data {
	get {
		if (this.input_data == null)
					this.input_data = (In) Services.getPort("input_data");
		return this.input_data;
	}
}

private IData partition_mapping = null;

public IData Partition_mapping {
	get {
		if (this.partition_mapping == null)
			this.partition_mapping = (IData) Services.getPort("partition_mapping");
		return this.partition_mapping;
	}
}

private Out output_data = default(Out);

public Out Output_data {
	get {
		if (this.output_data == null)
					this.output_data = (Out) Services.getPort("output_data");
		return this.output_data;
	}
}

		private IManager<ISourceSplitter<In, IMK, IMV, Sf, Bf>, In, ITargetPartition<OMK>, IIterator<IKVPair<OMK, IInteger>>, PLATFORM> farm_map = null;

		protected IManager<ISourceSplitter<In, IMK, IMV, Sf, Bf>, In, ITargetPartition<OMK>, IIterator<IKVPair<OMK, IInteger>>, PLATFORM> Farm_map {
	get {
		if (this.farm_map == null)
					this.farm_map = (IManager<ISourceSplitter<In, IMK, IMV, Sf, Bf>, In, ITargetPartition<OMK>, IIterator<IKVPair<OMK, IInteger>>, PLATFORM>) Services.getPort("farm_map");
		return this.farm_map;
	}
}

		private IManager<ISourceShuffler<OMK>, IIterator<IKVPair<OMK,IInteger>>, ITargetCombiner<ORV, Out, Cf>, Out, PLATFORM> farm_reduce = null;

		protected IManager<ISourceShuffler<OMK>, IIterator<IKVPair<OMK,IInteger>>, ITargetCombiner<ORV, Out, Cf>, Out, PLATFORM> Farm_reduce {
	get {
		if (this.farm_reduce == null)
					this.farm_reduce = (IManager<ISourceShuffler<OMK>, IIterator<IKVPair<OMK,IInteger>>, ITargetCombiner<ORV, Out, Cf>, Out, PLATFORM>) Services.getPort("farm_reduce");
		return this.farm_reduce;
	}
}

	


}

}
