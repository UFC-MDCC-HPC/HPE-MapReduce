/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.KMVPair;
using br.ufc.mdcc.mapreduce.reducer.FeedReducing;

namespace br.ufc.mdcc.mapreduce.reducer.impl.FeedReducingImpl { 

public abstract class BaseIFeedReducingImpl<OMV, OMK>: Computation, BaseIFeedReducing<OMV, OMK>
where OMV:IData
where OMK:IData
{

	private IKMVPair<OMK,OMV> output_values = null;

	public IKMVPair<OMK,OMV> Output_values {
		get {
			if (this.output_values == null)
					this.output_values = (IKMVPair<OMK,OMV>) Services.getPort("output_values");
			return this.output_values;
		}
	}

	private IIterator<IKMVPair<OMK, OMV>> input = null;

	public IIterator<IKMVPair<OMK, OMV>> Input {
		get {
			if (this.input == null)
						this.input = (IIterator<IKMVPair<OMK, OMV>>) Services.getPort("input");
			return this.input;
		}
}



}

}
