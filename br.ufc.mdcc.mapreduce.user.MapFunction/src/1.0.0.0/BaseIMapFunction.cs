/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.mapreduce.user.MapFunction { 

public interface BaseIMapFunction<IMK, IMV> : IComputationKind 
where IMK:IData
where IMV:IData
{

	IIterator<IData> Output_data {get;}
	IMK Input_key {get;}
	IMV Input_value {get;}


} // end main interface 

} // end namespace 
