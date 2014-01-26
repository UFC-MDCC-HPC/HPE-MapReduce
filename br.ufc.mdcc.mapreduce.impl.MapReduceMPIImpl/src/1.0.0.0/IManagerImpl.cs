using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.user.SplitFunction;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.MapReduce;

namespace br.ufc.mdcc.mapreduce.impl.MapReduceMPIImpl { 

	public class IManagerImpl<IMAP, IMK, IMV, Sf, OMK, OPK, PLATFORM, ORED> : BaseIManagerImpl<IMAP, IMK, IMV, Sf, OMK, OPK, PLATFORM, ORED>, IManagerMapReduce<IMAP, IMK, IMV, Sf, OMK, OPK, PLATFORM, ORED>
where IMAP:IData
where IMK:IData
where IMV:IData
		where Sf:ISplitFunction<IMAP, IMK, IMV>
where OMK:IData
where OPK:IData
where PLATFORM:IPlatform
where ORED:IData
{

public IManagerImpl() { 

} 

		public override void main() { 

	 
}

}

}
