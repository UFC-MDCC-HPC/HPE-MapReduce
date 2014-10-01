using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.user.CombineFunction;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.String;

namespace br.ufc.mdcc.mapreduce.example.graph.bsp.sssp.PathBspCombineFunction { 

	public interface IPathBspCombineFunction<ORV, Out> : BaseIPathBspCombineFunction<ORV, Out>, ICombineFunction<ORV, Out>
		where ORV: IKVPair<IString, IString>
		where Out: IString
{


} // end main interface 

} // end namespace 
