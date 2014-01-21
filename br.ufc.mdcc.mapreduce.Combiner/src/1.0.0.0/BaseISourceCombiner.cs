/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.farm.Gather;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Iterator;


namespace br.ufc.mdcc.mapreduce.Combiner { 

public interface BaseISourceCombiner<ORV> : 
	BaseIGatherSource<IIterator<ORV>>, 
	ISynchronizerKind 
where ORV:IData
{



} // end main interface 

} // end namespace 
