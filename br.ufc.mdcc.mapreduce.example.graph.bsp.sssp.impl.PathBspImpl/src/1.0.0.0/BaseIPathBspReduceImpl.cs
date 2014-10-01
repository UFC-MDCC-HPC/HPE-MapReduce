/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.MapReduce;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.mapreduce.example.graph.bsp.sssp.PathBspReduce;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.example.graph.bsp.sssp.PathBsp;
using br.ufc.mdcc.common.communication.Broadcast;
//using br.ufc.mdcc.mapreduce.example.graph.bsp.sssp.DataPath;

namespace br.ufc.mdcc.mapreduce.example.graph.bsp.sssp.impl.PathBspImpl { 

	public abstract class BaseIPathBspReduceImpl<PLATFORM>: Computation, BaseIPathBspReduce<PLATFORM>
		where PLATFORM:IPlatform{
		//<                   OMK,      OMV,          ORV,                                Rf,             PLATFORM>
		private IReduceWorker<IString, IString, IKVPair<IString, IString>, IPathBspReduce, PLATFORM> path_bsp = null;
		protected IReduceWorker<IString, IString, IKVPair<IString, IString>, IPathBspReduce, PLATFORM> Path_bsp {
			get {
				if (this.path_bsp == null)
					this.path_bsp = (IReduceWorker<IString, IString, IKVPair<IString, IString>, IPathBspReduce, PLATFORM>) Services.getPort("path_bsp");
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
