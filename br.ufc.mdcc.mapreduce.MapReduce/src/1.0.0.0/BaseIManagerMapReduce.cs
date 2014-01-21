/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Platform;

namespace br.ufc.mdcc.mapreduce.MapReduce { 

public interface BaseIManagerMapReduce<IMAP, PLATFORM, ORED> : IComputationKind 
where IMAP:IData
where PLATFORM:IPlatform
where ORED:IData
{

	ORED Target_data {get;}
	IMAP Source_data {get;}


} // end main interface 

} // end namespace 
