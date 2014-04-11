/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.graph.DataNode;

namespace br.ufc.mdcc.mapreduce.example.graph.clique.CliqueNode { 

public interface BaseICliqueNode<T> : BaseIDataNode<T>, IDataStructureKind 
where T:IData
{

	IIterator<T> Neighbors {get;}


} // end main interface 

} // end namespace 
