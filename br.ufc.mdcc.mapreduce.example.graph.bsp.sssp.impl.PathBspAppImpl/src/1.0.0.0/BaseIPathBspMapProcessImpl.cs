/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.example.graph.bsp.sssp.PathBsp;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.example.graph.bsp.sssp.PathBspApp;

namespace br.ufc.mdcc.mapreduce.example.graph.bsp.sssp.impl.PathBspAppImpl { 

public abstract class BaseIPathBspMapProcessImpl<PLATFORM>: Application, BaseIPathBspMapProcess<PLATFORM>
where PLATFORM:IPlatform
{

private IPathBspMap<PLATFORM> path_bsp = null;

protected IPathBspMap<PLATFORM> Path_bsp {
	get {
		if (this.path_bsp == null)
			this.path_bsp = (IPathBspMap<PLATFORM>) Services.getPort("path_bsp");
		return this.path_bsp;
	}
}



}

}
