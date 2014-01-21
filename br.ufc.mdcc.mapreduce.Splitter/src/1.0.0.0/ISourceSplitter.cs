using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.farm.Scatter;

namespace br.ufc.mdcc.mapreduce.Splitter { 

public interface ISourceSplitter<I, B> : 
	BaseISourceSplitter<I, B>, 
	IScatterSource<I>
where I:IData
where B:IData
{


} // end main interface 

} // end namespace 
