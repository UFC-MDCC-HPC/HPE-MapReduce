using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.partitioner.GatherPartitionInfo;

namespace br.ufc.mdcc.mapreduce.partitioner.impl.GatherPartitionInfoImpl { 

public class ISourceGatherPartitionInfoImpl<OMK, OPK> : BaseISourceGatherPartitionInfoImpl<OMK, OPK>, ISourceGatherPartitionInfo<OMK, OPK>
where OMK:IData
where OPK:IData
{

public ISourceGatherPartitionInfoImpl() { 

} 

public override int go() { 

	 return 0
}

}

}
