/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;

namespace br.ufc.mdcc.mapreduce.user.SplitFunction { 

	public interface BaseISplitFunction<I, IMK, IMV> : IComputationKind 
		where I:IData
		where IMK:IData
		where IMV:IData
{

		I Input_data {get;}
		IIterator<IKVPair<IMK,IMV>> Output_data {get;}


} // end main interface 

} // end namespace 
