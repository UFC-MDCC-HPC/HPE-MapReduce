using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.graph.DataNode;

namespace br.ufc.mdcc.mapreduce.example.graph.clique.CliqueNode { 
	public interface ICliqueNode<TID> : BaseICliqueNode<TID>, IDataNode<TID>
		where TID:IData{
		ICliqueNodeInstance<TID> newInstance(object id);
	}
	public interface ICliqueNodeInstance<TID>
		where TID:IData{
		object Id { get; set;} //TID Id
		object Neighbors { set; get; } //IIterator<TID>
	}
}
