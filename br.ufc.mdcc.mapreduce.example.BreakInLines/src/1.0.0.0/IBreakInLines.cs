using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.user.SplitFunction;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.common.Integer;

namespace br.ufc.mdcc.mapreduce.example.BreakInLines { 

public interface IBreakInLines : BaseIBreakInLines, ISplitFunction<IString,IInteger,IString>
{


} // end main interface 

} // end namespace 
