/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Double;
using br.ufc.mdcc.mapreduce.MapReduce;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.mapreduce.user.PartitionFunction;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.mapreduce.user.CombineFunction;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PageRank;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.BreakInNodes;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PageNode;

namespace br.ufc.mdcc.mapreduce.example.graph.pagerank.impl.PageRankImpl { 

	public abstract class BaseIMasterImpl<PLATFORM>: Computation, BaseIMaster<PLATFORM>
		where PLATFORM:IPlatform{

		private IString input_data = null;
		public IString Input_data {
			get {
				if (this.input_data == null)
					this.input_data = (IString) Services.getPort("input_data");
				return this.input_data;
			}
		}

		private IIterator<IKVPair<IString,IInteger>> output_data = null;
		public IIterator<IKVPair<IString,IInteger>> Output_data {
			get {
				if (this.output_data == null)
					this.output_data = (IIterator<IKVPair<IString,IInteger>>) Services.getPort("output_data");
				return this.output_data;
			}
		}

		private IManagerMapReduce<IString, IInteger, IPageNode<IInteger>, IBreakInNodes, IPartitionFunction<IInteger>, IInteger, IKVPair<IInteger, IDouble>, ICombineFunction<IKVPair<IInteger, IDouble>,IIterator<IKVPair<IInteger,IDouble>>>,	IIterator<IKVPair<IInteger, IDouble>>, PLATFORM> page_rank = null;
		protected IManagerMapReduce<IString, IInteger, IPageNode<IInteger>, IBreakInNodes, IPartitionFunction<IInteger>, IInteger, IKVPair<IInteger, IDouble>, ICombineFunction<IKVPair<IInteger, IDouble>,IIterator<IKVPair<IInteger,IDouble>>>, IIterator<IKVPair<IInteger, IDouble>>, PLATFORM> Page_rank {
			get {
				if (this.page_rank == null)
					this.page_rank = (IManagerMapReduce<IString, IInteger, IPageNode<IInteger>, IBreakInNodes, IPartitionFunction<IInteger>, IInteger, IKVPair<IInteger, IDouble>, ICombineFunction<IKVPair<IInteger, IDouble>,IIterator<IKVPair<IInteger,IDouble>>>, IIterator<IKVPair<IInteger, IDouble>>, PLATFORM>) Services.getPort("page_rank");
				return this.page_rank;
			}
		}
	}
}

/*Info:
 * In, IString
 * IMK, IInteger
 * IMV, IPageNode<IInteger>,
 * Sf, IBreakInNodes
 * Bf, IPartitionFunction<IInteger>,
 * OMK, IInteger
 * OMV, IDouble
 * ORV, IKVPair<IInteger, IDouble>, 
 * Cf, ICombineFunction<IKVPair<IInteger, IDouble>,IIterator<IKVPair<IInteger,IDouble>>>,	
 * Out, IIterator<IKVPair<IInteger, IDouble>>, 
 * PLATFORM> 
*/
