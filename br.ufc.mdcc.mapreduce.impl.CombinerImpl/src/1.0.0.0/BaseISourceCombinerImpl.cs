/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.mapreduce.Combiner;
using environment.MPIDirect;

namespace br.ufc.mdcc.mapreduce.impl.CombinerImpl { 

public abstract class BaseISourceCombinerImpl<ORV>: 
	Synchronizer, BaseISourceCombiner<ORV>
where ORV:IData
{

	private IIterator<ORV> source_data = null;

		public IIterator<ORV> Source_data {
		get {
			if (this.source_data == null)
					this.source_data = (IIterator<ORV>) Services.getPort("source_data");
			return this.source_data;
		}
	}

	private  IMPIDirect mpi_comm = null;

	protected IMPIDirect Mpi_comm {
		get {
			if (this.mpi_comm == null) 
			{
				this.mpi_comm = (IMPIDirect) Services.getPort("mpi_comm");
			}
			return this.mpi_comm;
		}
	}


}
}
