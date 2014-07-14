/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.example.graph.clique.Clique;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.example.graph.clique.CliqueApp;

namespace br.ufc.mdcc.mapreduce.example.graph.clique.impl.CliqueAppImpl { 

public abstract class BaseICliqueReduceProcessImpl<PLATFORM>: Application, BaseICliqueReduceProcess<PLATFORM>
where PLATFORM:IPlatform
{

private ICliqueReduce<PLATFORM> clique = null;

protected ICliqueReduce<PLATFORM> Clique {
	get {
		if (this.clique == null)
			this.clique = (ICliqueReduce<PLATFORM>) Services.getPort("clique");
		return this.clique;
	}
}



}

}
