using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.example.graph.sssp.PathFlow;

namespace br.ufc.mdcc.mapreduce.example.graph.sssp.impl.PathFlowImpl { 

public class IMasterImpl<PLATFORM> : BaseIMasterImpl<PLATFORM>, IMaster<PLATFORM>
where PLATFORM:IPlatform
{

public IMasterImpl() { 

} 

public override void main() 
{ 
    this.Path_flow.go ();
			Console.WriteLine (Rank + ": --- FINISH PATH_FLOW.GO !");
}

}

}
