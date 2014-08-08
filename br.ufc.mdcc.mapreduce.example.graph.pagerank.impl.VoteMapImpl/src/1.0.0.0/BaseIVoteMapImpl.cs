using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.Double;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PageNode;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.VoteMap;

namespace br.ufc.mdcc.mapreduce.example.graph.pagerank.impl.VoteMapImpl { 
	public abstract class BaseIVoteMapImpl: Computation, BaseIVoteMap{

		private IIterator<IKVPair<IString, IDouble>> output_data = null;
		public IIterator<IKVPair<IString, IDouble>> Output_data {
			get {
				if (this.output_data == null)
					this.output_data = (IIterator<IKVPair<IString, IDouble>>) Services.getPort("output_data");
				return this.output_data;
			}
		}

		private IInteger input_key = default(IInteger);
		public IInteger Input_key {
			get {
				if (this.input_key == null)
					this.input_key = (IInteger) Services.getPort("input_key");
				return this.input_key;
			}
		}

		private IPageNode input_value = default(IPageNode);
		public IPageNode Input_value {
			get {
				if (this.input_value == null)
					this.input_value = (IPageNode) Services.getPort("input_value");
				return this.input_value;
			}
		}
	}
}
