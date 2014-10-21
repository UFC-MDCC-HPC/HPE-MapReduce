/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.MapReduce;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.mapreduce.user.PartitionFunction;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.mapreduce.user.CombineFunction;
using br.ufc.mdcc.mapreduce.example.graph.sssp.fast.PathFlow;
//using br.ufc.mdcc.mapreduce.example.graph.sssp.fast.DataPath;
using br.ufc.mdcc.mapreduce.example.graph.sssp.fast.PathFlowCombineFunction;
using br.ufc.mdcc.common.communication.Broadcast;
using br.ufc.mdcc.mapreduce.example.graph.sssp.fast.PathInfo;
using br.ufc.mdcc.mapreduce.example.graph.sssp.fast.SplitPathInfo;

namespace br.ufc.mdcc.mapreduce.example.graph.sssp.fast.impl.PathFlowImpl { 

	public abstract class BaseIMasterImpl<PLATFORM>: Computation, BaseIMaster<PLATFORM>
		where PLATFORM:IPlatform{

		private IString output_data = null;
		public IString Output_data {
			get {
				if (this.output_data == null)
					this.output_data = (IString) Services.getPort("output_data");
				return this.output_data;
			}
		}

		private IString input_data = null;
		public IString Input_data {
			get {
				if (this.input_data == null)
					this.input_data = (IString) Services.getPort("input_data");
				return this.input_data;
			}
		}

		private IIterator<IPathInfo> initial_data = null;
		public IIterator<IPathInfo> Initial_data {
			get {
				if (this.initial_data == null)
					this.initial_data = (IIterator<IPathInfo>) Services.getPort("initial_data");
				return this.initial_data;
			}
		}

		private IKVPair<IInteger, IIterator<IPathInfo>> final_distances = null;
		public IKVPair<IInteger, IIterator<IPathInfo>> Final_distances {
			get {
				if (this.final_distances == null)
					this.final_distances = (IKVPair<IInteger, IIterator<IPathInfo>>) Services.getPort("final_distances");
				return this.final_distances;
			}
		}

		//IManagerMapReduce      <In,                   IMK,      IMV,       OMK,      ORV,                                     Out,                                    Sf,             Bf,                           Cf<ORV,Out>,                                                                                                PLATFORM>
		private IManagerMapReduce<IIterator<IPathInfo>, IInteger, IPathInfo, IInteger, IKVPair<IInteger, IIterator<IPathInfo>>, IKVPair<IInteger,IIterator<IPathInfo>>, ISplitPathInfo, IPartitionFunction<IInteger>, IPathFlowCombineFunction<IKVPair<IInteger, IIterator<IPathInfo>>, IKVPair<IInteger, IIterator<IPathInfo>>>, PLATFORM> path_flow = null;
		protected IManagerMapReduce<IIterator<IPathInfo>, IInteger, IPathInfo, IInteger, IKVPair<IInteger, IIterator<IPathInfo>>, IKVPair<IInteger,IIterator<IPathInfo>>, ISplitPathInfo, IPartitionFunction<IInteger>, IPathFlowCombineFunction<IKVPair<IInteger, IIterator<IPathInfo>>, IKVPair<IInteger, IIterator<IPathInfo>>>, PLATFORM> Path_flow {
			get {
				if (this.path_flow == null)
					this.path_flow = (IManagerMapReduce<IIterator<IPathInfo>, IInteger, IPathInfo, IInteger, IKVPair<IInteger, IIterator<IPathInfo>>, IKVPair<IInteger,IIterator<IPathInfo>>, ISplitPathInfo, IPartitionFunction<IInteger>, IPathFlowCombineFunction<IKVPair<IInteger, IIterator<IPathInfo>>, IKVPair<IInteger, IIterator<IPathInfo>>>, PLATFORM>) Services.getPort("path_flow");
				return this.path_flow;
			}
		}
		
		private IBroadcast<IInteger> set_termination_flag = null;
		protected IBroadcast<IInteger> Set_termination_flag {
		   get {
				if (this.set_termination_flag == null)
					this.set_termination_flag = (IBroadcast<IInteger>) Services.getPort("set_termination_flag");
				return this.set_termination_flag;
		   }
		}

		private IInteger termination_flag = null;
		protected IInteger Termination_flag {
			get {
				if (this.termination_flag == null)
					this.termination_flag = (IInteger) Services.getPort("termination_flag");
				return this.termination_flag;
			}
		}

		
	}
}
