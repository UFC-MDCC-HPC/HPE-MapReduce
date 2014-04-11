using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.mapreduce.example.graph.pagerank.PGRank { 

public interface IPGRank : BaseIPGRank, IData
{
double Value { get; set; }
double Error { get; }

} // end main interface 

} // end namespace 
