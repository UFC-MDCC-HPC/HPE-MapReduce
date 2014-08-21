/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.MapReduce;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.mapreduce.example.graph.sssp.PathFlowReduce;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.example.graph.sssp.PathFlow;
//using br.ufc.mdcc.mapreduce.example.graph.sssp.DataPath;

namespace br.ufc.mdcc.mapreduce.example.graph.sssp.impl.PathFlowImpl { 

	public abstract class BaseIPathFlowReduceImpl<PLATFORM>: Computation, BaseIPathFlowReduce<PLATFORM>
		where PLATFORM:IPlatform{
		//<                   OMK,      OMV,          ORV,                                Rf,             PLATFORM>
		private IReduceWorker<IString, IString, IKVPair<IString, IString>, IPathFlowReduce, PLATFORM> path_flow = null;
		protected IReduceWorker<IString, IString, IKVPair<IString, IString>, IPathFlowReduce, PLATFORM> Path_flow {
			get {
				if (this.path_flow == null)
					this.path_flow = (IReduceWorker<IString, IString, IKVPair<IString, IString>, IPathFlowReduce, PLATFORM>) Services.getPort("path_flow");
				return this.path_flow;
			}
		}
	}
}
