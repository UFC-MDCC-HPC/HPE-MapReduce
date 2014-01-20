using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.mapreduce.user.SplitFunction { 

public interface ISplitFunction<I, T> : BaseISplitFunction<I, T>
where I:IData
where T:IData
{


} // end main interface 

} // end namespace 
