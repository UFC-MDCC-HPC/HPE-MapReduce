/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Set;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.farm.Scatter;

namespace br.ufc.mdcc.mapreduce.Splitter { 

public interface BaseISourceSplitter<I, B> : BaseISource<I, B>, ISynchronizerKind 
where I:IData
where B:IData
{

	I Source_data {get;}


} // end main interface 

} // end namespace 
