/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.mapreduce.Shuffler;

namespace br.ufc.mdcc.mapreduce.impl.ShufflerImpl { 

public abstract class BaseISourceShufflerImpl<OMK, OPK>: 
	Synchronizer, 
	BaseISourceShuffler<OMK, OPK>
where OMK:IData
where OPK:IData
{

		private IIterator<IKVPair<OMK,OPK>> source_data = null;

		public IIterator<IKVPair<OMK,OPK>> Source_data {
	get {
		if (this.source_data == null)
					this.source_data = (IIterator<IKVPair<OMK,OPK>>) Services.getPort("source_data");
		return this.source_data;
	}
}




}

}
