/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.partitioner.GatherPartitionInfo;

namespace br.ufc.mdcc.mapreduce.partitioner.impl.GatherPartitionInfoImpl { 

public abstract class BaseISourceGatherPartitionInfoImpl<OMK, OPK>: Synchronizer, BaseISourceGatherPartitionInfo<OMK, OPK>
where OMK:IData
where OPK:IData
{

private IData source_data = null;

public IData Source_data {
	get {
		if (this.source_data == null)
			this.source_data = (IData) Services.getPort("source_data");
		return this.source_data;
	}
}


abstract public int go(); 


}

}
