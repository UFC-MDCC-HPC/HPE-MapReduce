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
namespace br.ufc.mdcc.mapreduce.impl.PartitionerImpl { 
public class ITargetPartitionerImpl<OMK> : BaseITargetPartitionerImpl<OMK>, ITargetPartition<OMK>
	where OMK:IData {
		// Variáveis do Ambiente MPI.
		private MPI.Intracommunicator worldcomm = null;
		private int tag = 345;
		public ITargetPartitionerImpl() { 
			worldcomm = Mpi_comm.worldComm();
		} 

		public override void main() {
			/* 1. Receber o par de chaves (OMK, OPK) dos mappers (unidade source) e copiar no iterator Target_data.
			 * Dúvida: é só um par?
			 */

			// Recebe o iterator enviado pelo source.
			MPI.Request request = new MPI.Request ();
			request = worldcomm.ImmediateReceive<IIterator<IKVPair<OMK, IInteger>>> (MPI.Unsafe.MPI_ANY_SOURCE, tag, Target_data);
			request.Wait ();
		}
	}
}
