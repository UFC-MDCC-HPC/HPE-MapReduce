using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Platform;

namespace br.ufc.mdcc.mapreduce.example.CountWords { 

public interface IWordCounter<PLATFORM> : BaseIWordCounter<PLATFORM>
where PLATFORM:IPlatform
{


} // end main interface 

} // end namespace 
