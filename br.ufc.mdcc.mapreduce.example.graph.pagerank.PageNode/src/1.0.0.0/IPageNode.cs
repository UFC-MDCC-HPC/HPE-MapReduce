using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.graph.DataNode;

namespace br.ufc.mdcc.mapreduce.example.graph.pagerank.PageNode { 

	public interface IPageNode<TID> : BaseIPageNode<TID>, IDataNode<TID>
		where TID:IData{
		IPageNodeInstance<TID> newInstance(object id);
	}
	public interface IPageNodeInstance<TID>
		where TID:IData{
		object Id { get; set;} //TID Id
		object Pgrank { get; set;} //IPGRank Pgrank
		object Neighbors { set; get; } //IIterator<TID>
	}
} // end namespace 
