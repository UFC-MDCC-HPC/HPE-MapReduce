/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.MapReduce;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.mapreduce.user.PartitionFunction;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.example.graph.sssp.fast.PathFlow;
//using br.ufc.mdcc.mapreduce.example.graph.sssp.fast.DataPath;
using br.ufc.mdcc.common.communication.Broadcast;
using br.ufc.mdcc.mapreduce.example.graph.sssp.fast.PathInfo;
using br.ufc.mdcc.mapreduce.user.MapFunction;

namespace br.ufc.mdcc.mapreduce.example.graph.sssp.fast.impl.PathFlowImpl { 

	public abstract class BaseIPathFlowMapImpl<PLATFORM>: Computation, BaseIPathFlowMap<PLATFORM>
		where PLATFORM:IPlatform{
		//      <          IMK,      IMV,     OMK,      OMV,         Pf,                           Mf,        PLATFORM>
		private IMapWorker<IInteger, IPathInfo, IInteger, IPathInfo, IPartitionFunction<IInteger>, IMapFunction<IInteger,IPathInfo,IInteger,IPathInfo>, PLATFORM> path_flow = null;
		protected IMapWorker<IInteger, IPathInfo, IInteger, IPathInfo, IPartitionFunction<IInteger>, IMapFunction<IInteger,IPathInfo,IInteger,IPathInfo>, PLATFORM> Path_flow {
			get {
				if (this.path_flow == null)
					this.path_flow = (IMapWorker<IInteger, IPathInfo, IInteger, IPathInfo, IPartitionFunction<IInteger>, IMapFunction<IInteger,IPathInfo,IInteger,IPathInfo>, PLATFORM>) Services.getPort("path_flow");
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
