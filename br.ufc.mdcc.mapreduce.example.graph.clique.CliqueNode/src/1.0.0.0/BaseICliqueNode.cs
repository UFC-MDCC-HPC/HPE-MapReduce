/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.graph.DataNode;

namespace br.ufc.mdcc.mapreduce.example.graph.clique.CliqueNode { 

public interface BaseICliqueNode<TID> : BaseIDataNode<TID>, IDataStructureKind 
where TID:IData
{

	IIterator<TID> Neighbors {get;}


} // end main interface 

} // end namespace 
