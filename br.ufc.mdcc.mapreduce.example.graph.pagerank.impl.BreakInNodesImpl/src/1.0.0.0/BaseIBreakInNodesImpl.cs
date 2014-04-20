/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Iterator;
//using br.ufc.mdcc.common.String;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PageNode;
using br.ufc.mdcc.common.Integer;

using br.ufc.mdcc.mapreduce.example.graph.pagerank.BreakInNodes;

namespace br.ufc.mdcc.mapreduce.example.graph.pagerank.impl.BreakInNodesImpl { 

	public abstract class BaseIBreakInNodesImpl: Computation, BaseIBreakInNodes{
		private IIterator<IKVPair<IInteger, IPageNode<IInteger>>> output_data = null;
		public IIterator<IKVPair<IInteger, IPageNode<IInteger>>> Output_data {
			get {
				if (this.output_data == null)
					this.output_data = (IIterator<IKVPair<IInteger, IPageNode<IInteger>>>) Services.getPort("output_data");
				return this.output_data;
			}
		}

		private IIterator<IPageNode<IInteger>> input_data = null;
		public IIterator<IPageNode<IInteger>> Input_data {
			get {
				if (this.input_data == null)
					this.input_data = (IIterator<IPageNode<IInteger>>) Services.getPort("input_data");
				return this.input_data;
			}
		}
	}
}
