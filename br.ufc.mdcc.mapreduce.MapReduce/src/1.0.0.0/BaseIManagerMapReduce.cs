/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Platform;

namespace br.ufc.mdcc.mapreduce.MapReduce { 

public interface BaseIManagerMapReduce<IMAP, PLATFORM, ORED> : IComputationKind 
where IMAP:IData
where PLATFORM:IPlatform
where ORED:IData
{

	IMAP Input_data {get;}
		//IIterator<IKVPair<OMK,OPK>> Partition_data {get;}
	ORED Output_data {get;}


} // end main interface 

} // end namespace 
