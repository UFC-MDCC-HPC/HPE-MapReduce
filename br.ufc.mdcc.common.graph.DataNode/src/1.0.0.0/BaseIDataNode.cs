/* AUTOMATICALLY GENERATE CODE */

using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.common.graph.DataNode { 
	public interface BaseIDataNode<TID> : BaseIData, IDataStructureKind 
		where TID:IData{

		TID Id_node { get; }

	} // end main interface 
} // end namespace 
