using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.example.graph.bsp.sssp.PathBspApp;

namespace br.ufc.mdcc.mapreduce.example.graph.bsp.sssp.impl.PathBspAppImpl { 

public class IPathBspMapProcessImpl<PLATFORM> : BaseIPathBspMapProcessImpl<PLATFORM>, IPathBspMapProcess<PLATFORM>
where PLATFORM:IPlatform
{

public IPathBspMapProcessImpl() { 

} 

public override void main() { 
this.Path_bsp.go();
}

}

}
