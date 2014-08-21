/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.MapReduce;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.mapreduce.user.PartitionFunction;
using br.ufc.mdcc.mapreduce.example.graph.sssp.PathFlowMap;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.example.graph.sssp.PathFlow;
//using br.ufc.mdcc.mapreduce.example.graph.sssp.DataPath;

namespace br.ufc.mdcc.mapreduce.example.graph.sssp.impl.PathFlowImpl { 

	public abstract class BaseIPathFlowMapImpl<PLATFORM>: Computation, BaseIPathFlowMap<PLATFORM>
		where PLATFORM:IPlatform{
		//      <          IMK,      IMV,     OMK,      OMV,         Pf,                           Mf,        PLATFORM>
		private IMapWorker<IInteger, IString, IString, IString, IPartitionFunction<IString>, IPathFlowMap, PLATFORM> path_flow = null;
		protected IMapWorker<IInteger, IString, IString, IString, IPartitionFunction<IString>, IPathFlowMap, PLATFORM> Path_flow {
			get {
				if (this.path_flow == null)
					this.path_flow = (IMapWorker<IInteger, IString, IString, IString, IPartitionFunction<IString>, IPathFlowMap, PLATFORM>) Services.getPort("path_flow");
				return this.path_flow;
			}
		}
	}
}
