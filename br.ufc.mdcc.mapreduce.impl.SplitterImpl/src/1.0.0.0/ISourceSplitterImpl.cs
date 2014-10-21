using System;
using System.Threading.Tasks;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.user.SplitFunction;
using br.ufc.mdcc.mapreduce.Splitter;
using br.ufc.mdcc.mapreduce.user.PartitionFunction;
using System.Diagnostics;

namespace br.ufc.mdcc.mapreduce.impl.SplitterImpl { 

	public class ISourceSplitterImpl<I, IMK, IMV, Sf, Bf> : BaseISourceSplitterImpl<I, IMK, IMV, Sf, Bf>, ISourceSplitter<I, IMK, IMV, Sf, Bf>
    where I:IData
    where IMK:IData
    where IMV:IData
	where Sf:ISplitFunction<I, IMK, IMV>  
	where Bf:IPartitionFunction<IMK>
	   
	{
        public override void main() 
		{ 
			// 2. Criar uma thread para executar Send_bins.go()
			Task send_bins_task = new Task (delegate {
				Trace.WriteLine("BEFORE SEND BINS TASK");
				Send_bins.go();
				Trace.WriteLine("AFTER SEND BINS TASK");
			});

			// 1. Criar uma thread para executar Split_function.go();
			//Task split_function_task = new Task (delegate {
				Trace.WriteLine("BEFORE SPLIT FUNCTION TASK");
				Split_function.go();
				Trace.WriteLine("AFTER SPLIT FUNCTION TASK");
			//});

			//split_function_task.Start ();
			send_bins_task.Start ();

			Trace.WriteLine (Rank + ": SPLITTER FINISH #1");
			send_bins_task.Wait ();
			Trace.WriteLine (Rank + ": SPLITTER FINISH #2");
			//split_function_task.Wait ();
			Trace.WriteLine (Rank + ": SPLITTER FINISH #3");
        }
    }
}
