/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.MapReduce;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.example.graph.clique.Clique;
using br.ufc.mdcc.mapreduce.example.graph.clique.CliqueReduce;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.Iterator;

namespace br.ufc.mdcc.mapreduce.example.graph.clique.impl.CliqueImpl { 

	public abstract class BaseICliqueMapImpl<PLATFORM>: Computation, BaseICliqueMap<PLATFORM>
		where PLATFORM:IPlatform{

		private IReduceWorker<IInteger, IKVPair<IInteger, IIterator<IInteger>>, IKVPair<IInteger, IIterator<IKVPair<IInteger, IIterator<IInteger>>>>, ICliqueReduce, PLATFORM> clique = null;
		protected IReduceWorker<IInteger, IKVPair<IInteger, IIterator<IInteger>>, IKVPair<IInteger, IIterator<IKVPair<IInteger, IIterator<IInteger>>>>, ICliqueReduce, PLATFORM> Clique {
			get {
				if (this.clique == null)
					this.clique = (IReduceWorker<IInteger, IKVPair<IInteger, IIterator<IInteger>>, IKVPair<IInteger, IIterator<IKVPair<IInteger, IIterator<IInteger>>>>, ICliqueReduce, PLATFORM>) Services.getPort("clique");
				return this.clique;
			}
		}
	}
}
//IReduceWorker<OMK, ORV, Rf, OMV, PLATFORM>
//IMK:IInteger
//IMV:ICliqueNode<IInteger>
//OMK: IInteger
//OMV: IKVPair<IInteger, IIterator<IInteger>>
//ORV: IKVPair<IInteger, IIterator<IKVPair<IInteger, IIterator<IInteger>>>>


