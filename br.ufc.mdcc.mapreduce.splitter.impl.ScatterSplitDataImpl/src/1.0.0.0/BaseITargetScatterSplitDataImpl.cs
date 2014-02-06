/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.splitter.ScatterSplitData;
using environment.MPIDirect;

namespace br.ufc.mdcc.mapreduce.splitter.impl.ScatterSplitDataImpl { 

public abstract class BaseITargetScatterSplitDataImpl<IMK, IMV>: Synchronizer, BaseITargetScatterSplitData<IMK, IMV>
where IMK:IData
where IMV:IData
{

private IIterator<IKVPair<IMK, IMV>> target_data = null;

public IIterator<IKVPair<IMK, IMV>> Target_data {
	get {
		if (this.target_data == null)
			this.target_data = (IIterator<IKVPair<IMK, IMV>>) Services.getPort("target_data");
		return this.target_data;
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
