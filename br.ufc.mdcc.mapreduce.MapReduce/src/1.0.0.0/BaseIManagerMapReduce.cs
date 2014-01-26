/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.user.SplitFunction;

namespace br.ufc.mdcc.mapreduce.MapReduce { 

	public interface BaseIManagerMapReduce<IMAP, IMK, IMV, Sf, OMK, OPK, PLATFORM, ORED> : IComputationKind 
		where IMAP:IData
		where IMK:IData
		where IMV:IData
		where OPK:IData
		where OMK:IData
		where Sf:ISplitFunction<IMAP, IMK, IMV>
		where PLATFORM:IPlatform
		where ORED:IData
{

	IMAP Input_data {get;}
		//IIterator<IKVPair<OMK,OPK>> Partition_data {get;}
	ORED Output_data {get;}


} // end main interface 

} // end namespace 
