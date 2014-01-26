using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.mapper.FeedMapping;

namespace br.ufc.mdcc.mapreduce.mapper.impl.FeedMappingImpl { 

public class IFeedMappingImpl<IMV, IMK> : BaseIFeedMappingImpl<IMV, IMK>, IFeedMapping<IMV, IMK>
where IMV:IData
where IMK:IData
{

public IFeedMappingImpl() { 

} 

		public override void main () { }

	}
}
