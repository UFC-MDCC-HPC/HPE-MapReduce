using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.user.MapFunction;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.String;
//using br.ufc.mdcc.mapreduce.example.graph.bsp.sssp.DataPath;

namespace br.ufc.mdcc.mapreduce.example.graph.bsp.sssp.PathBspMap { 

	public interface IPathBspMap : BaseIPathBspMap, IMapFunction<IInteger, IString, IString, IString>
{


} // end main interface 

} // end namespace 
