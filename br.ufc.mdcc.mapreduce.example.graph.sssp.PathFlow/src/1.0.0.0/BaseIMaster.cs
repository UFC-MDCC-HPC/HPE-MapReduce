/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.String;
//using br.ufc.mdcc.mapreduce.example.graph.sssp.DataPath;

namespace br.ufc.mdcc.mapreduce.example.graph.sssp.PathFlow { 

public interface BaseIMaster<PLATFORM> : IComputationKind 
where PLATFORM:IPlatform
{

	IIterator<IKVPair<IString, IString>> Output_data {get;}
	IString Input_data {get;}


} // end main interface 

} // end namespace 
