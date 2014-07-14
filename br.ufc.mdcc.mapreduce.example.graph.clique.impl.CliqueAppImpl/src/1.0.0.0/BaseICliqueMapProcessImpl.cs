/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.example.graph.clique.Clique;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.example.graph.clique.CliqueApp;

namespace br.ufc.mdcc.mapreduce.example.graph.clique.impl.CliqueAppImpl { 

public abstract class BaseICliqueMapProcessImpl<PLATFORM>: Application, BaseICliqueMapProcess<PLATFORM>
where PLATFORM:IPlatform
{

private ICliqueMap<PLATFORM> clique = null;

protected ICliqueMap<PLATFORM> Clique {
	get {
		if (this.clique == null)
			this.clique = (ICliqueMap<PLATFORM>) Services.getPort("clique");
		return this.clique;
	}
}



}

}
