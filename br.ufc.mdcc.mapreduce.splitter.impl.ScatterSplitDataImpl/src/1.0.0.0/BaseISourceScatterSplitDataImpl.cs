/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.mapreduce.splitter.ScatterSplitData;
using br.ufc.mdcc.mapreduce.user.PartitionFunction;
using environment.MPIDirect;


namespace br.ufc.mdcc.mapreduce.splitter.impl.ScatterSplitDataImpl { 

public abstract class BaseISourceScatterSplitDataImpl<IMK, IMV>: Synchronizer, BaseISourceScatterSplitData<IMK, IMV>
where IMK:IData
where IMV:IData
{

private IIterator<IKVPair<IMK, IMV>> bins = null;

public IIterator<IKVPair<IMK, IMV>> Bins {
	get {
		if (this.bins == null)
				this.bins = (IIterator<IKVPair<IMK, IMV>>) Services.getPort("bins");
		return this.bins;
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

private  IPartitionFunction<IMK> bin_function = null;

protected IPartitionFunction<IMK> Bin_function {
	get {
		if (this.bin_function == null) 
		{
			this.bin_function = (IPartitionFunction<IMK>) Services.getPort("bin_function");
		}
		return this.bin_function;
	}
}

private  IMK input_key = default(IMK);

protected IMK Input_key {
	get {
		if (this.input_key == null) 
		{
			this.input_key = (IMK) Services.getPort("input_key");
		}
		return this.input_key;
	}
}

private  IInteger output_key = null;

protected IInteger Output_key {
	get {
		if (this.output_key == null) 
		{
			this.output_key = (IInteger) Services.getPort("output_key");
		}
		return this.output_key;
	}
}

}

}
