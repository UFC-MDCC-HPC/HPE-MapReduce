using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Platform;

namespace br.ufc.mdcc.mapreduce.example.CountWordsApp { 

public interface IWordCounterProcess<PLATFORM> : BaseIWordCounterProcess<PLATFORM>
where PLATFORM:IPlatform
{


} // end main interface 

} // end namespace 
