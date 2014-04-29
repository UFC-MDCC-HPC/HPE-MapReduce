/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.mapreduce.example.graph.clique.CliqueNode;

namespace br.ufc.mdcc.mapreduce.example.graph.clique.Clique { 

	public interface BaseIMaster<PLATFORM> : IComputationKind 
		where PLATFORM:IPlatform{
		IIterator<IKVPair<IInteger,IIterator<IKVPair<IInteger, IIterator<IInteger>>>>> Output_data {get;}
		IIterator<ICliqueNode<IInteger>> Input_data {get;}//IString Input_data {get;}
	} // end main interface 
} // end namespace 


//ISplitFunction<I, IMK, IMV>
//IMK:IInteger
//IMV:ICliqueNode<IInteger>
//OMK: IInteger
//OMV: IKVPair<IInteger, IIterator<IInteger>>
//ORV: IKVPair<IInteger, IIterator<IKVPair<IInteger, IIterator<IInteger>>>>
