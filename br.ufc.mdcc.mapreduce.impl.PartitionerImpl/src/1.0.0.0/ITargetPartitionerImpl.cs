using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.Partitioner;
using environment.MPIDirect;
using br.ufc.mdcc.common.KVPair;

using System.Collections.Generic;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.Iterator;

// Essa é a unidade manager. Existe apenas uma.
// Precisa receber os valores dos iteradores de todos os mappers (unidades source do Partitioner).
namespace br.ufc.mdcc.mapreduce.impl.PartitionerImpl 
{ 
	public class ITargetPartitionerImpl<OMK> : BaseITargetPartitionerImpl<OMK>, ITargetPartition<OMK>
	where OMK:IData 
	{
		private MPI.Intracommunicator worldcomm = null;

		public ITargetPartitionerImpl() { } 

		override public void initialize()
		{
			// Inicializar o comunicador MPI. 
			worldcomm = Mpi_comm.worldComm();
		}

		public override void main() 
		{

		}
	}
}
