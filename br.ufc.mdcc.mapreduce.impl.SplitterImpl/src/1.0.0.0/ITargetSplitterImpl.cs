using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.Splitter;
using System.Diagnostics;

namespace br.ufc.mdcc.mapreduce.impl.SplitterImpl { 
	public class ITargetSplitterImpl<IMK, IMV> : BaseITargetSplitterImpl<IMK, IMV>, ITargetSplitter<IMK, IMV>
	where IMK:IData
	where IMV:IData 
	{
		public override void main() 
		{ 
			// Executar Send_bins.go()
			Trace.WriteLine(Rank + ": STARTING SPLITER TARGET");
			Send_bins.go ();
			Trace.WriteLine(Rank + ": FINISHING SPLITER TARGET");
		}
	}
}
