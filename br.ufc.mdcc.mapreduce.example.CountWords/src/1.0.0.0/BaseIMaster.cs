/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.String;

namespace br.ufc.mdcc.mapreduce.example.CountWords { 

public interface BaseIMaster<PLATFORM> : IComputationKind 
where PLATFORM:IPlatform
{

	IIterator<IKVPair<IString,IInteger>> Output_data {get;}
	IString Input_data {get;}


} // end main interface 

} // end namespace 
