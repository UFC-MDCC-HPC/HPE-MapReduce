/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.MapReduce;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PageNode;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.mapreduce.user.PartitionFunction;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.BreakInPageNodes;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Double;
using br.ufc.mdcc.mapreduce.user.CombineFunction;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PageRank;

namespace br.ufc.mdcc.mapreduce.example.graph.pagerank.impl.PageRankImpl { 
	public abstract class BaseIMasterImpl<PLATFORM>: Computation, BaseIMaster<PLATFORM>
		where PLATFORM:IPlatform{

		private IIterator<IKVPair<IInteger,IDouble>> output_data = null;
		public IIterator<IKVPair<IInteger,IDouble>> Output_data {
			get {
				if (this.output_data == null)
					this.output_data = (IIterator<IKVPair<IInteger,IDouble>>) Services.getPort("output_data");
				return this.output_data;
			}
		}

		private IString input_data = null;//private IData input_data = null;
		public IString Input_data {
			get {
				if (this.input_data == null)
					this.input_data = (IString) Services.getPort("input_data");
				return this.input_data;
			}
		}

		/*private IManagerMapReduce<IString, IPageNode<IInteger>, IInteger, IPartitionFunction<IInteger>, IBreakInPageNodes, IInteger, PLATFORM, IIterator<IKVPair<IDouble, IInteger>>, IKVPair<IDouble, IInteger>, IDouble, ICombineFunction<IKVPair<IDouble, IInteger>, IIterator<IKVPair<IDouble, IInteger>>>> page_rank = null;
		protected IManagerMapReduce<IString, IPageNode<IInteger>, IInteger, IPartitionFunction<IInteger>, IBreakInPageNodes, IInteger, PLATFORM, IIterator<IKVPair<IDouble, IInteger>>, IKVPair<IDouble, IInteger>, IDouble, ICombineFunction<IKVPair<IDouble, IInteger>, IIterator<IKVPair<IDouble, IInteger>>>> Page_rank {
			get {
				if (this.page_rank == null)
					this.page_rank = (IManagerMapReduce<IString, IPageNode<IInteger>, IInteger, IPartitionFunction<IInteger>, IBreakInPageNodes, IInteger, PLATFORM, IIterator<IKVPair<IDouble, IInteger>>, IKVPair<IDouble, IInteger>, IDouble, ICombineFunction<IKVPair<IDouble, IInteger>, IIterator<IKVPair<IDouble, IInteger>>>>) Services.getPort("page_rank");
				return this.page_rank;
			}
		}*/

		private IManagerMapReduce<IString, IInteger, IPageNode, IInteger, IKVPair<IInteger, IDouble>, IIterator<IKVPair<IInteger, IDouble>>, IBreakInPageNodes, IPartitionFunction<IInteger>, ICombineFunction<IKVPair<IInteger, IDouble>,IIterator<IKVPair<IInteger,IDouble>>>, PLATFORM> page_rank = null;
		protected IManagerMapReduce<IString, IInteger, IPageNode, IInteger, IKVPair<IInteger, IDouble>, IIterator<IKVPair<IInteger, IDouble>>, IBreakInPageNodes, IPartitionFunction<IInteger>, ICombineFunction<IKVPair<IInteger, IDouble>,IIterator<IKVPair<IInteger,IDouble>>>, PLATFORM> Page_rank {
			get {
				if (this.page_rank == null)
					this.page_rank = (IManagerMapReduce<IString, IInteger, IPageNode, IInteger, IKVPair<IInteger, IDouble>, IIterator<IKVPair<IInteger, IDouble>>, IBreakInPageNodes, IPartitionFunction<IInteger>, ICombineFunction<IKVPair<IInteger, IDouble>,IIterator<IKVPair<IInteger,IDouble>>>, PLATFORM>) Services.getPort("page_rank");
				return this.page_rank;
			}
		}

	}
}
