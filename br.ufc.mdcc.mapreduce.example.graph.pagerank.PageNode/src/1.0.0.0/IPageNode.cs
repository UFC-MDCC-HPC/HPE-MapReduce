using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.graph.DataNode;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PGRank;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.Integer;

namespace br.ufc.mdcc.mapreduce.example.graph.pagerank.PageNode { 

	public interface IPageNode : BaseIPageNode, IDataNode<IInteger, IPGRank, IIterator<IInteger>>{
	} // end main interface 
	public interface IPageNodeInstance{
		object IdInstance { get; set;}
		IPGRankInstance PgrankInstance { get; set;}
		IIteratorInstance<IInteger> NeighborsInstance { set; get; }
	}
} // end namespace 
