using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.example.graph.clique.CliqueApp;

namespace br.ufc.mdcc.mapreduce.example.graph.clique.impl.CliqueAppImpl { 

	public class ICliqueMapProcessImpl<PLATFORM> : BaseICliqueMapProcessImpl<PLATFORM>, ICliqueMapProcess<PLATFORM>
		where PLATFORM:IPlatform{

		public ICliqueMapProcessImpl() { } 

		public override void main() { 
			Clique.go();
		}
	}
}
