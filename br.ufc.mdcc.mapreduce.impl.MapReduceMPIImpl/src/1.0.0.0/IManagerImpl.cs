using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.user.SplitFunction;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.MapReduce;
using br.ufc.mdcc.mapreduce.user.PartitionFunction;
using br.ufc.mdcc.mapreduce.user.CombineFunction;
using System.Threading.Tasks;
using System.Diagnostics;

namespace br.ufc.mdcc.mapreduce.impl.MapReduceMPIImpl { 

	public class IManagerImpl<In, IMK, IMV, OMK, ORV, Out, Sf, Bf, Cf, PLATFORM> : BaseIManagerImpl<In, IMK, IMV, OMK, ORV, Out, Sf, Bf, Cf, PLATFORM>, IManagerMapReduce<In, IMK, IMV, OMK, ORV, Out, Sf, Bf, Cf, PLATFORM>
		where In:IData
		where IMK:IData
		where IMV:IData
		where Sf:ISplitFunction<In, IMK, IMV>
		where Bf:IPartitionFunction<IMK>
		where Cf:ICombineFunction<ORV,Out>
		where OMK:IData
		where PLATFORM:IPlatform
		where ORV:IData
		where Out:IData
{

		public IManagerImpl() { } 

	public override void main() 
	{ 
			Task farm_map_task = new Task(delegate {this.Farm_map.go();});
			Task farm_reduce_task = new Task(delegate {this.Farm_reduce.go();});

			farm_map_task.Start();
			farm_reduce_task.Start();

			Trace.WriteLine (Rank + ": --- FINISH MAP REDUCE MANAGER #1!");
			farm_reduce_task.Wait();
			Trace.WriteLine (Rank + ": --- FINISH MAP REDUCE MANAGER #2!");
			farm_map_task.Wait();	
			Trace.WriteLine (Rank + ": --- FINISH MAP REDUCE MANAGER #3!");
	}

}

}
