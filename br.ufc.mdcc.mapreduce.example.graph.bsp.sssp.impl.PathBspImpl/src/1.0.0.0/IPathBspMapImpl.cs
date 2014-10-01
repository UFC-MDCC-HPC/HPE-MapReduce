using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.example.graph.bsp.sssp.PathBsp;
using br.ufc.mdcc.common.Integer;
using System.Diagnostics;

namespace br.ufc.mdcc.mapreduce.example.graph.bsp.sssp.impl.PathBspImpl { 

	public class IPathBspMapImpl<PLATFORM> : BaseIPathBspMapImpl<PLATFORM>, IPathBspMap<PLATFORM>
	where PLATFORM:IPlatform
	{

		public override void main() 
		{ 
			int done = 0;

			while (done == 0) 
			{
				this.Path_bsp.go ();
				this.Set_termination_flag.go ();
				IIntegerInstance termination_flag = (IIntegerInstance) Termination_flag.Instance;
				done = termination_flag.Value;
				//Trace.WriteLine (Rank + "AFTER PATH ROW MAP LOOP " + done + " --- " + Termination_flag.Instance.GetHashCode());
			}
		}

	}

}
