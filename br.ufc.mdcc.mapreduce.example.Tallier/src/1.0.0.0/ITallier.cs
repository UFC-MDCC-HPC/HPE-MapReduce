using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.user.ReduceFunction;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.KVPair;

namespace br.ufc.mdcc.mapreduce.example.Tallier { 

	public interface ITallier : BaseITallier, IReduceFunction<IString,IInteger,IKVPair<IString,IInteger>>
{


} // end main interface 

} // end namespace 
