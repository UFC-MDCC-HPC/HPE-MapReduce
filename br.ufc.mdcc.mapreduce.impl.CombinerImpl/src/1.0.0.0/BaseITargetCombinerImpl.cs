/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.Combiner;

namespace br.ufc.mdcc.mapreduce.impl.CombinerImpl { 

public abstract class BaseITargetCombinerImpl<ORED>: Synchronizer, BaseITargetCombiner<ORED>
where ORED:IData
{

private ORED target_data = default(ORED);

public ORED Target_data {
	get {
		if (this.target_data == null)
			this.target_data = (ORED) Services.getPort("target_data");
		return this.target_data;
	}
}


}

}
