using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.user.SplitFunction;

namespace br.ufc.mdcc.mapreduce.MapReduce { 

	public interface IManagerMapReduce<IMAP, IMK, IMV, Sf, OMK, OPK, ORV, PLATFORM> : 
	BaseIManagerMapReduce<IMAP, IMK, IMV, Sf, OMK, OPK, ORV, PLATFORM>
		where IMAP:IData
		where IMK:IData
		where IMV:IData
		where OPK:IData
		where OMK:IData
		where ORV:IData
		where Sf:ISplitFunction<IMAP, IMK, IMV>
		where PLATFORM:IPlatform
{


} // end main interface 

} // end namespace 
