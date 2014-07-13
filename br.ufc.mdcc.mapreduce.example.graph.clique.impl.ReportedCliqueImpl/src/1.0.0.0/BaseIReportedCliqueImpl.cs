/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.mapreduce.example.graph.clique.ReportedClique;

namespace br.ufc.mdcc.mapreduce.example.graph.clique.impl.ReportedCliqueImpl { 
	public abstract class BaseIReportedCliqueImpl: DataStructure, BaseIData{
		private IIterator<IKVPair<IInteger, IIterator<IInteger>>> items = null;
		protected IIterator<IKVPair<IInteger, IIterator<IInteger>>> Items {
			get {
				if (this.items == null)
					this.items = (IIterator<IKVPair<IInteger, IIterator<IInteger>>>) Services.getPort("items");
				return this.items;
			}
		}
	}
}
