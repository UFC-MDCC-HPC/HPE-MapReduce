using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.example.graph.sssp.fast.PathFlowApp;
using System.Diagnostics;

namespace br.ufc.mdcc.mapreduce.example.graph.sssp.fast.impl.PathFlowAppImpl { 

	public class IPathFlowMapProcessImpl<PLATFORM> : BaseIPathFlowMapProcessImpl<PLATFORM>, IPathFlowMapProcess<PLATFORM>
	where PLATFORM:IPlatform
	{

		public override void main() { 
		//	TextWriterTraceListener writer = new TextWriterTraceListener(System.Console.Out);
		//	Trace.Listeners.Add(writer);
			this.Path_flow.go();
		}

	}

}
