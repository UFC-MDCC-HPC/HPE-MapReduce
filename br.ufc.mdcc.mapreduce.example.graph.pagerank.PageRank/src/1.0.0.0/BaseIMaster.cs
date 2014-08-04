/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Double;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.String;

namespace br.ufc.mdcc.mapreduce.example.graph.pagerank.PageRank { 

public interface BaseIMaster<PLATFORM> : IComputationKind 
where PLATFORM:IPlatform
{

	//IData Output {get;}
	//IData Input {get;}
	IIterator<IKVPair<IInteger,IDouble>> Output_data {get;}
	IString Input_data {get;}

} // end main interface 

} // end namespace 
