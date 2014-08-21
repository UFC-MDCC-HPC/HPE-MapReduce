/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.example.graph.sssp.PathFlow;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.example.graph.sssp.PathFlowApp;

namespace br.ufc.mdcc.mapreduce.example.graph.sssp.impl.PathFlowAppImpl { 

public abstract class BaseIPathFlowMapProcessImpl<PLATFORM>: Application, BaseIPathFlowMapProcess<PLATFORM>
where PLATFORM:IPlatform
{

private IPathFlowMap<PLATFORM> path_flow = null;

protected IPathFlowMap<PLATFORM> Path_flow {
	get {
		if (this.path_flow == null)
			this.path_flow = (IPathFlowMap<PLATFORM>) Services.getPort("path_flow");
		return this.path_flow;
	}
}



}

}
