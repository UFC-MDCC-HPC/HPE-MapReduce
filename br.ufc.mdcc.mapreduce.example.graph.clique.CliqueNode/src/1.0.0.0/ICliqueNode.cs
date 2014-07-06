using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.graph.DataNode;


namespace br.ufc.mdcc.mapreduce.example.graph.clique.CliqueNode { 
	public interface ICliqueNode<TID> : BaseICliqueNode<TID>, IDataNode<TID>
		where TID:IData{
	}
	public interface ICliqueNodeInstance<TID>
		where TID:IData{
		object IdInstance { get; set;} //TID Id
		IIteratorInstance<TID> NeighborsInstance { set; get; } //IIterator<TID>
	}
}
