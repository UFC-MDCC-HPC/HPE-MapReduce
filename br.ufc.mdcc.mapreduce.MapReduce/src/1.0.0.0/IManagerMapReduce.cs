using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Platform;

namespace br.ufc.mdcc.mapreduce.MapReduce { 

public interface IManagerMapReduce<IMAP, PLATFORM, ORED> : BaseIManagerMapReduce<IMAP, PLATFORM, ORED>
where IMAP:IData
where PLATFORM:IPlatform
where ORED:IData
{


} // end main interface 

} // end namespace 
