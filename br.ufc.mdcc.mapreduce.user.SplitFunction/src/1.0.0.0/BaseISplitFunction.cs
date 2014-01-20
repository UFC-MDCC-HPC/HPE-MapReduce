/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Set;

namespace br.ufc.mdcc.mapreduce.user.SplitFunction { 

public interface BaseISplitFunction<I, T> : IComputationKind 
where I:IData
where T:IData
{

	I Input_data {get;}
	ISet<T> Output_data {get;}


} // end main interface 

} // end namespace 
