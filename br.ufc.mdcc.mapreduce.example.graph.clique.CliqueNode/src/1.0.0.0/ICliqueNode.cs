using System.Collections.Generic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.graph.DataNode;
using System;

namespace br.ufc.mdcc.mapreduce.example.graph.clique.CliqueNode { 
	public interface ICliqueNode : BaseICliqueNode, IDataNode{
		object newInstance (int _id);
	} // end main interface 
	public interface ICliqueNodeInstance: ICloneable{
		int IdInstance { get; set;}
		IList<int> NeighborsInstance { set; get; }
	}
} // end namespace 
