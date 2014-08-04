/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.common.graph.DataNode { 

public interface BaseIDataNode<TID, VAL, EDG> : BaseIData, IDataStructureKind 
where TID:IData
where VAL:IData
where EDG:IData
{

	TID Id_node {get;}
	VAL Value_node {get;}
	EDG Edge_node {get;}


} // end main interface 

} // end namespace 
