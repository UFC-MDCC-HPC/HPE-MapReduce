using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.example.graph.sssp.PathFlow;
using br.ufc.mdcc.common.Integer;
using System.Diagnostics;

namespace br.ufc.mdcc.mapreduce.example.graph.sssp.impl.PathFlowImpl { 

	public class IPathFlowReduceImpl<PLATFORM> : BaseIPathFlowReduceImpl<PLATFORM>, IPathFlowReduce<PLATFORM>
	where PLATFORM:IPlatform
	{
		public override void main() 
		{ 
			int done = 0;

			while (done == 0) 
			{
				this.Path_flow.go ();
				this.Set_termination_flag.go ();
				IIntegerInstance termination_flag = (IIntegerInstance) Termination_flag.Instance;
				done = termination_flag.Value;
				Trace.WriteLine (Rank + "AFTER PATH ROW REDUCE LOOP " + done);
			}
		}

	}


}
