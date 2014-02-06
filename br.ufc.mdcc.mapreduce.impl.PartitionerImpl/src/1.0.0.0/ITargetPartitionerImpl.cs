using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.Partitioner;
using environment.MPIDirect;

namespace br.ufc.mdcc.mapreduce.impl.PartitionerImpl { 

public class ITargetPartitionerImpl<OMK> : BaseITargetPartitionerImpl<OMK>, ITargetPartition<OMK>
where OMK:IData
{

		public ITargetPartitionerImpl() { 

		} 

		public override void main() 
		{
			/* receber o par de chaves (OMK, OPK) dos mappers (unidade source)
			 * e copiar no iterator Target_data.
			 */

		}


}

}
