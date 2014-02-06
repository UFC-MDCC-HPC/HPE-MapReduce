/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.user.SplitFunction;

namespace br.ufc.mdcc.mapreduce.MapReduce { 

	public interface BaseIManagerMapReduce<IMAP, IMK, IMV, Sf, OMK, ORV, PLATFORM> : IComputationKind 
		where IMAP:IData
		where IMK:IData
		where IMV:IData
		where OMK:IData
		where ORV:IData
		where Sf:ISplitFunction<IMAP, IMK, IMV>
		where PLATFORM:IPlatform
{

	IMAP Input_data {get;}
		//IIterator<IKVPair<OMK,OPK>> Partition_data {get;}
	IIterator<ORV> Output_data {get;}


} // end main interface 

} // end namespace 
