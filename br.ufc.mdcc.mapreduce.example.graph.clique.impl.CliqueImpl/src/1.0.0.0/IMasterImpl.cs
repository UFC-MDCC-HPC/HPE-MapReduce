using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.example.graph.clique.Clique;

namespace br.ufc.mdcc.mapreduce.example.graph.clique.impl.CliqueImpl { 

	public class IMasterImpl<PLATFORM> : BaseIMasterImpl<PLATFORM>, IMaster<PLATFORM>
		where PLATFORM:IPlatform{
		public IMasterImpl() { 

		} 

		public override void main() { 
			this.Clique.go();
		}
	}
}
