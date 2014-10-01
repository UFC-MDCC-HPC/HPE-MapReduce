/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.example.graph.bsp.sssp.PathBsp;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.example.graph.bsp.sssp.PathBspApp;

namespace br.ufc.mdcc.mapreduce.example.graph.bsp.sssp.impl.PathBspAppImpl { 

public abstract class BaseIPathBspReduceProcessImpl<PLATFORM>: Application, BaseIPathBspReduceProcess<PLATFORM>
where PLATFORM:IPlatform
{

private IPathBspReduce<PLATFORM> path_bsp = null;

protected IPathBspReduce<PLATFORM> Path_bsp {
	get {
		if (this.path_bsp == null)
			this.path_bsp = (IPathBspReduce<PLATFORM>) Services.getPort("path_bsp");
		return this.path_bsp;
	}
}



}

}
