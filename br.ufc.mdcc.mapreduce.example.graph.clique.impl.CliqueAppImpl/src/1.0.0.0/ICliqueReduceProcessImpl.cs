using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.example.graph.clique.CliqueApp;

namespace br.ufc.mdcc.mapreduce.example.graph.clique.impl.CliqueAppImpl { 

public class ICliqueReduceProcessImpl<PLATFORM> : BaseICliqueReduceProcessImpl<PLATFORM>, ICliqueReduceProcess<PLATFORM>
where PLATFORM:IPlatform
{

public ICliqueReduceProcessImpl() { 

} 

public override void main() { 
			Clique.go();
}

}

}
