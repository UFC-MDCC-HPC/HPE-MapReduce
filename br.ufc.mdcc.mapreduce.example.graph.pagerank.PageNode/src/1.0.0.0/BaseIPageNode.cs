/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PGRank;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.graph.DataNode;

namespace br.ufc.mdcc.mapreduce.example.graph.pagerank.PageNode { 

public interface BaseIPageNode<T> : BaseIDataNode<T>, IDataStructureKind 
where T:IData
{

	IPGRank Pgrank {get;}
	IIterator<T> Neighbors {get;}


} // end main interface 

} // end namespace 
