/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.MapReduce;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.mapreduce.example.graph.clique.CliqueReduce;
using br.ufc.mdcc.mapreduce.example.graph.clique.CliqueNode;
using br.ufc.mdcc.mapreduce.example.graph.clique.Clique;

namespace br.ufc.mdcc.mapreduce.example.graph.clique.impl.CliqueImpl { 

	public abstract class BaseICliqueReduceImpl<PLATFORM>: Computation, BaseICliqueReduce<PLATFORM>
		where PLATFORM:IPlatform{

		//<                      OMK,     OMV,           ORV,                          Rf,        PLATFORM>
		private IReduceWorker<IString, ICliqueNode, IKVPair<IString, ICliqueNode>, ICliqueReduce, PLATFORM> clique = null;
		protected IReduceWorker<IString, ICliqueNode, IKVPair<IString, ICliqueNode>, ICliqueReduce, PLATFORM> Clique {
			get {
				if (this.clique == null)
					this.clique = (IReduceWorker<IString, ICliqueNode, IKVPair<IString, ICliqueNode>, ICliqueReduce, PLATFORM>) Services.getPort("clique");
				return this.clique;
			}
		}

	}
}
