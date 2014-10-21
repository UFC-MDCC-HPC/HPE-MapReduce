using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.example.graph.sssp.fast.PathFlow;
using br.ufc.mdcc.common.Integer;
using System.Diagnostics;

namespace br.ufc.mdcc.mapreduce.example.graph.sssp.fast.impl.PathFlowImpl { 

	public class IPathFlowMapImpl<PLATFORM> : BaseIPathFlowMapImpl<PLATFORM>, IPathFlowMap<PLATFORM>
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
				Trace.WriteLine (Rank + "AFTER PATH ROW MAP LOOP " + done + " --- " + Termination_flag.Instance.GetHashCode());
			}
		}

	}

}
