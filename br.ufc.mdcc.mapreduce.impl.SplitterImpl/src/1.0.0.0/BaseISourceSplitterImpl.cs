/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.user.SplitFunction;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.mapreduce.splitter.ScatterSplitData;
using br.ufc.mdcc.mapreduce.Splitter;
using environment.MPIDirect;
using br.ufc.mdcc.mapreduce.user.PartitionFunction;

namespace br.ufc.mdcc.mapreduce.impl.SplitterImpl { 

	public abstract class BaseISourceSplitterImpl<I, IMK, IMV, Sf, Bf>: 
	Synchronizer, BaseISourceSplitter<I, IMK, IMV, Sf, Bf>
	where I:IData
	where IMK:IData
	where IMV:IData
	where Sf:ISplitFunction<I, IMK, IMV>
	where Bf:IPartitionFunction<IMK>
{

private Sf split_function = default(Sf);

protected Sf Split_function {
	get {
		if (this.split_function == null)
			this.split_function = (Sf) Services.getPort("split_function");
		return this.split_function;
	}
}

		private I source_data = default(I);

public I Source_data {
	get {
		if (this.source_data == null)
			this.source_data = (I) Services.getPort("source_data");
		return this.source_data;
	}
}

private IIterator<IKVPair<IMK, IMV>> bins = null;

protected IIterator<IKVPair<IMK, IMV>> Bins {
	get {
		if (this.bins == null)
				this.bins = (IIterator<IKVPair<IMK, IMV>>) Services.getPort("bins");
		return this.bins;
	}
}

		private ISourceScatterSplitData<IMK, IMV, Bf> send_bins = null;

		protected ISourceScatterSplitData<IMK, IMV, Bf> Send_bins {
	get {
		if (this.send_bins == null)
					this.send_bins = (ISourceScatterSplitData<IMK, IMV, Bf>) Services.getPort("send_bins");
		return this.send_bins;
	}
}

private  IMPIDirect mpi_comm = null;

protected IMPIDirect Mpi_comm {
	get {
		if (this.mpi_comm == null) 
		{
			this.mpi_comm = (IMPIDirect) Services.getPort("mpi_comm");
		}
		return this.mpi_comm;
	}
}



}

}
