using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.user.SplitFunction;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.MapReduce;

namespace br.ufc.mdcc.mapreduce.impl.MapReduceMPIImpl { 

	public class IManagerImpl<IMAP, IMK, IMV, Sf, OMK, ORV, PLATFORM> : BaseIManagerImpl<IMAP, IMK, IMV, Sf, OMK, ORV, PLATFORM>, IManagerMapReduce<IMAP, IMK, IMV, Sf, OMK, ORV, PLATFORM>
		where IMAP:IData
		where IMK:IData
		where IMV:IData
		where Sf:ISplitFunction<IMAP, IMK, IMV>
		where OMK:IData
		where PLATFORM:IPlatform
		where ORV:IData
{

public IManagerImpl() { 

} 

	public override void main() 
	{ 

	 
	}

}

}
