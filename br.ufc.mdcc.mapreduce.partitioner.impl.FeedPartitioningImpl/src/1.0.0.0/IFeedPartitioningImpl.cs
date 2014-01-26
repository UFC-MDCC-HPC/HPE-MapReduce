using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.partitioner.FeedPartitioning;

namespace br.ufc.mdcc.mapreduce.partitioner.impl.FeedPartitioningImpl { 

public class IFeedPartitioningImpl<OMK, OPK, OMV> : BaseIFeedPartitioningImpl<OMK, OPK, OMV>, IFeedPartitioning<OMK, OPK, OMV>
where OMK:IData
where OPK:IData
where OMV:IData
{

public IFeedPartitioningImpl() { 

} 

		public override void main () { }

}

}
