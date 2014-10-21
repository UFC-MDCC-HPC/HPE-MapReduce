
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.user.SplitFunction;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.mapreduce.example.graph.sssp.fast.PathInfo;
using br.ufc.mdcc.common.Integer;

namespace br.ufc.mdcc.mapreduce.example.graph.sssp.fast.SplitPathInfo { 

	public interface ISplitPathInfo : BaseISplitPathInfo, ISplitFunction<IIterator<IPathInfo>,IInteger,IPathInfo>
{


} // end main interface 

} // end namespace 
