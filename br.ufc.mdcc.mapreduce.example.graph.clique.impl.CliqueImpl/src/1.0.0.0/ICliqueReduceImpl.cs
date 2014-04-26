using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.example.graph.clique.Clique;

namespace br.ufc.mdcc.mapreduce.example.graph.clique.impl.CliqueImpl { 

	public class ICliqueReduceImpl<PLATFORM> : BaseICliqueReduceImpl<PLATFORM>, ICliqueReduce<PLATFORM>
		where PLATFORM:IPlatform{

		public ICliqueReduceImpl() { } 

		public override void main() { 
			this.Clique.go();

		}
	}
}
