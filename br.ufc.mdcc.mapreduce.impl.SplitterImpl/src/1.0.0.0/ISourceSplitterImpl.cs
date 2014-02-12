using System;
using System.Threading.Tasks;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.user.SplitFunction;
using br.ufc.mdcc.mapreduce.Splitter;

namespace br.ufc.mdcc.mapreduce.impl.SplitterImpl { 

	public class ISourceSplitterImpl<I, IMK, IMV, Sf> : BaseISourceSplitterImpl<I, IMK, IMV, Sf>, ISourceSplitter<I, IMK, IMV, Sf>
    where I:IData
    where IMK:IData
    where IMV:IData
	where Sf:ISplitFunction<I, IMK, IMV>     {
        public ISourceSplitterImpl() { 

        } 

        public override void main() { 
			// 1. Criar uma thread para executar Split_function.go();
			Task split_function_task = new Task (delegate {
				Split_function.go ();
			});
			split_function_task.Start ();
			// 2. Criar uma thread para executar Send_bins.go()
			Task send_bins_task = new Task (delegate {
				Send_bins.go();
			});
			send_bins_task.Start ();
        }
    }
}
