using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.user.PartitionFunction;
using br.ufc.mdcc.mapreduce.Partitioner;

namespace br.ufc.mdcc.mapreduce.impl.PartitionerImpl { 

public class ISourcePartitionerImpl<OMK, OMV, OPK, P> : BaseISourcePartitionerImpl<OMK, OMV, OPK, P>, ISourcePartition<OMK, OMV, OPK, P>
where OMK:IData
where OMV:IData
where OPK:IData
where P:IPartitionFunction<OMK, OPK>
{

		public ISourcePartitionerImpl() { 

		} 

		public override void main() 
		{
			/* 1. Ler os elementos de Source_data, um a um, e 
			 *    copiar a chave (OMK) em Data_key.
			 * 2. A cada chave de Source_data, chamar Partition_function.go();
			 * 3. Enviar o resultado de Partition_function.go(), via MPI,
			 *    para o gerente (unidade target).
			 */

		}

}

}
