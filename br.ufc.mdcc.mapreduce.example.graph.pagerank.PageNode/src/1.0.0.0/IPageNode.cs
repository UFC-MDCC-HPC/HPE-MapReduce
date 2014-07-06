using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.graph.DataNode;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PGRank;
using br.ufc.mdcc.common.Iterator;

namespace br.ufc.mdcc.mapreduce.example.graph.pagerank.PageNode { 

	public interface IPageNode<TID> : BaseIPageNode<TID>, IDataNode<TID>
		where TID:IData{
	}
	public interface IPageNodeInstance<TID>
		where TID:IData{
		object IdInstance { get; set;} //TID Id
		IPGRankInstance PgrankInstance { get; set;} //IPGRank Pgrank
		IIteratorInstance<TID> NeighborsInstance { set; get; } //IIterator<TID>
	}
} // end namespace 
