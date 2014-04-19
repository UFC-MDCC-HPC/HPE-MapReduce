/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PageRank;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PageRankApp;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.common.Double;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Integer;

namespace br.ufc.mdcc.mapreduce.example.graph.pagerank.impl.PageRankAppImpl { 
	public abstract class BaseIMasterProcessImpl<PLATFORM>: Application, BaseIMasterProcess<PLATFORM>
		where PLATFORM:IPlatform{

		private IString input_data = null;
		public IString Input_data {
			get {
				if (this.input_data == null)
					this.input_data = (IString) Services.getPort("input_data");
				return this.input_data;
			}
		}

		private IIterator<IKVPair<IInteger,IDouble>> output_data = null;
		public IIterator<IKVPair<IInteger,IDouble>> Output_data {
			get {
				if (this.output_data == null)
					this.output_data = (IIterator<IKVPair<IInteger,IDouble>>) Services.getPort("output_data");
				return this.output_data;
			}
		}

		private IMaster<PLATFORM> page_rank = null;
		protected IMaster<PLATFORM> Page_rank {
			get {
				if (this.page_rank == null)
					this.page_rank = (IMaster<PLATFORM>) Services.getPort("page_rank");
				return this.page_rank;
			}
		}
	}
}
