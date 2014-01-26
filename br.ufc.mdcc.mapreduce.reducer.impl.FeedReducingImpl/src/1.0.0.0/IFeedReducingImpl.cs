using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.reducer.FeedReducing;

namespace br.ufc.mdcc.mapreduce.reducer.impl.FeedReducingImpl { 

public class IFeedReducingImpl<OMV, OMK> : BaseIFeedReducingImpl<OMV, OMK>, IFeedReducing<OMV, OMK>
where OMV:IData
where OMK:IData
{

public IFeedReducingImpl() { 

} 

public override void main () { }

}

}
