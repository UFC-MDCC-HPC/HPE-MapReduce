using System.Collections.Generic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.graph.DataNode;

namespace br.ufc.mdcc.mapreduce.example.graph.pagerank.PageNode { 

	public interface IPageNode : BaseIPageNode, IDataNode{
		object newInstance (int _id);
	} // end main interface 
	public interface IPageNodeInstance{
		int IdInstance { get; set;}
		double PgrankInstance { get; set;}
		IList<int> NeighborsInstance { set; get; }
	}
} // end namespace 
