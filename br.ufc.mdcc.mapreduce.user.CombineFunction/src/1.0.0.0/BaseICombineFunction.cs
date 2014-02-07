/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Iterator;

namespace br.ufc.mdcc.mapreduce.user.CombineFunction { 

	public interface BaseICombineFunction<ORV, O> : IComputationKind 
		where O:IData
		where ORV:IData
{
		IIterator<ORV>Input_data {get;}
		O Output_data {get;}
} // end main interface 

} // end namespace 
