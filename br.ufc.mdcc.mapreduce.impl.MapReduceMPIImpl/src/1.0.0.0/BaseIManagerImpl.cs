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
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.Shuffler;
using br.ufc.mdcc.mapreduce.Combiner;
using br.ufc.mdcc.mapreduce.MapReduce;

namespace br.ufc.mdcc.mapreduce.impl.MapReduceMPIImpl { 

	public abstract class BaseIManagerImpl<IMAP, IMK, IMV, Sf, OMK, OPK, PLATFORM, ORED>: Computation, BaseIManagerMapReduce<IMAP, IMK, IMV, Sf, OMK, OPK, PLATFORM, ORED>
where IMAP:IData
where IMK:IData
where IMV:IData
		where Sf:ISplitFunction<IMAP, IMK, IMV>
where OMK:IData
where OPK:IData
where PLATFORM:IPlatform
where ORED:IData
{

	private IMAP input_data = default(IMAP);

	public IMAP Input_data {
	get {
		if (this.input_data == null)
					this.input_data = (IMAP) Services.getPort("input_data");
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

		private ORED output_data = default(ORED);

	public ORED Output_data {
	get {
		if (this.output_data == null)
				this.output_data = (ORED) Services.getPort("output_data");
		return this.output_data;
	}
}

		private IManager<ISourceSplitter<IMAP, IMK, IMV, Sf>, IMAP, ITargetPartition<OMK, OPK>, IIterator<IKVPair<OMK, OPK>>, PLATFORM> farm_map = null;

		protected IManager<ISourceSplitter<IMAP, IMK, IMV, Sf>, IMAP, ITargetPartition<OMK, OPK>, IIterator<IKVPair<OMK, OPK>>, PLATFORM> Farm_map {
	get {
		if (this.farm_map == null)
					this.farm_map = (IManager<ISourceSplitter<IMAP, IMK, IMV, Sf>, IMAP, ITargetPartition<OMK, OPK>, IIterator<IKVPair<OMK, OPK>>, PLATFORM>) Services.getPort("farm_map");
		return this.farm_map;
	}
}

		private IManager<ISourceShuffler<OMK, OPK>, IIterator<IKVPair<OMK,OPK>>, ITargetCombiner<ORED>, ORED, PLATFORM> farm_reduce = null;

		protected IManager<ISourceShuffler<OMK, OPK>, IIterator<IKVPair<OMK,OPK>>, ITargetCombiner<ORED>, ORED, PLATFORM> Farm_reduce {
	get {
		if (this.farm_reduce == null)
					this.farm_reduce = (IManager<ISourceShuffler<OMK, OPK>, IIterator<IKVPair<OMK,OPK>>, ITargetCombiner<ORED>, ORED, PLATFORM>) Services.getPort("farm_reduce");
		return this.farm_reduce;
	}
}

	


}

}
