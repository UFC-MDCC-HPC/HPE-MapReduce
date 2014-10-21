/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.MapReduce;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.mapreduce.example.graph.sssp.fast.PathFlowReduce;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.example.graph.sssp.fast.PathFlow;
using br.ufc.mdcc.common.communication.Broadcast;
//using br.ufc.mdcc.mapreduce.example.graph.sssp.fast.DataPath;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.mapreduce.example.graph.sssp.fast.PathInfo;

namespace br.ufc.mdcc.mapreduce.example.graph.sssp.fast.impl.PathFlowImpl { 

	public abstract class BaseIPathFlowReduceImpl<PLATFORM>: Computation, BaseIPathFlowReduce<PLATFORM>
		where PLATFORM:IPlatform{
		//<                   OMK,      OMV,          ORV,                                Rf,             PLATFORM>
		private IReduceWorker<IInteger, IPathInfo, IKVPair<IInteger, IIterator<IPathInfo>>, IPathFlowReduce, PLATFORM> path_flow = null;
		protected IReduceWorker<IInteger, IPathInfo, IKVPair<IInteger, IIterator<IPathInfo>>, IPathFlowReduce, PLATFORM> Path_flow {
			get {
				if (this.path_flow == null)
					this.path_flow = (IReduceWorker<IInteger, IPathInfo, IKVPair<IInteger, IIterator<IPathInfo>>, IPathFlowReduce, PLATFORM>) Services.getPort("path_flow");
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
