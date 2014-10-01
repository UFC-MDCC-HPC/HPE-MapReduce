/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.MapReduce;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.mapreduce.user.PartitionFunction;
using br.ufc.mdcc.mapreduce.example.graph.bsp.sssp.PathBspMap;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.example.graph.bsp.sssp.PathBsp;
//using br.ufc.mdcc.mapreduce.example.graph.bsp.sssp.DataPath;
using br.ufc.mdcc.common.communication.Broadcast;

namespace br.ufc.mdcc.mapreduce.example.graph.bsp.sssp.impl.PathBspImpl { 

	public abstract class BaseIPathBspMapImpl<PLATFORM>: Computation, BaseIPathBspMap<PLATFORM>
		where PLATFORM:IPlatform{
		//      <          IMK,      IMV,     OMK,      OMV,         Pf,                           Mf,        PLATFORM>
		private IMapWorker<IInteger, IString, IString, IString, IPartitionFunction<IString>, IPathBspMap, PLATFORM> path_bsp = null;
		protected IMapWorker<IInteger, IString, IString, IString, IPartitionFunction<IString>, IPathBspMap, PLATFORM> Path_bsp {
			get {
				if (this.path_bsp == null)
					this.path_bsp = (IMapWorker<IInteger, IString, IString, IString, IPartitionFunction<IString>, IPathBspMap, PLATFORM>) Services.getPort("path_bsp");
				return this.path_bsp;
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
