/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.MapReduce;
using br.ufc.mdcc.mapreduce.example.graph.clique.CliqueNode;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.mapreduce.user.PartitionFunction;
using br.ufc.mdcc.mapreduce.example.graph.clique.CliqueMap;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.example.graph.clique.Clique;

namespace br.ufc.mdcc.mapreduce.example.graph.clique.impl.CliqueImpl { 

	public abstract class BaseICliqueMapImpl<PLATFORM>: Computation, BaseICliqueMap<PLATFORM>
		where PLATFORM:IPlatform{

		private IMapWorker<IInteger, ICliqueNode<IInteger>, IInteger, IKVPair<IInteger, IIterator<IInteger>>, IPartitionFunction<IInteger>, ICliqueMap, PLATFORM> clique = null;
		protected IMapWorker<IInteger, ICliqueNode<IInteger>, IInteger, IKVPair<IInteger, IIterator<IInteger>>, IPartitionFunction<IInteger>, ICliqueMap, PLATFORM> Clique {
			get {
				if (this.clique == null)
					this.clique = (IMapWorker<IInteger, ICliqueNode<IInteger>, IInteger, IKVPair<IInteger, IIterator<IInteger>>, IPartitionFunction<IInteger>, ICliqueMap, PLATFORM>) Services.getPort("clique");
				return this.clique;
			}
		}
	}
}
//IMapWorker<IMK, IMV, OMK, OMV, Pf, Mf, PLATFORM>
//IMK:IInteger
//IMV:ICliqueNode<IInteger>
//OMK: IInteger
//OMV: IKVPair<IInteger, IIterator<IInteger>>
//ORV: IKVPair<IInteger, IIterator<IKVPair<IInteger, IIterator<IInteger>>>>