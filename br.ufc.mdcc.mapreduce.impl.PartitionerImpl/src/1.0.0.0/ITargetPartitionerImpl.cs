using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.Partitioner;

namespace br.ufc.mdcc.mapreduce.impl.PartitionerImpl { 

public class ITargetPartitionerImpl<OMK, OPK> : BaseITargetPartitionerImpl<OMK, OPK>, ITargetPartition<OMK, OPK>
where OMK:IData
where OPK:IData
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
