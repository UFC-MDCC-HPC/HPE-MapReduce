using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.example.graph.sssp.PathFlow;

namespace br.ufc.mdcc.mapreduce.example.graph.sssp.impl.PathFlowImpl { 

public class IPathFlowReduceImpl<PLATFORM> : BaseIPathFlowReduceImpl<PLATFORM>, IPathFlowReduce<PLATFORM>
where PLATFORM:IPlatform
{

public IPathFlowReduceImpl() { 

} 

public override void main() { 
this.Path_flow.go ();
}

}

}
