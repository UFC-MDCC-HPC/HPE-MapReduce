using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.example.graph.sssp.PathFlowApp;

namespace br.ufc.mdcc.mapreduce.example.graph.sssp.impl.PathFlowAppImpl { 

public class IPathFlowMapProcessImpl<PLATFORM> : BaseIPathFlowMapProcessImpl<PLATFORM>, IPathFlowMapProcess<PLATFORM>
where PLATFORM:IPlatform
{

public IPathFlowMapProcessImpl() { 

} 

public override void main() { 
this.Path_flow.go();
}

}

}
