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
			// Vou ter que receber number_of_mappers jokers até finalizar.
			int number_of_mappers = this.UnitSize["source"];
			int jokers = 0;

			while (jokers != number_of_mappers) {
				// Recebe o par do mapper
				MPI.Request request = new MPI.Request ();
				IKVPair<OMK, IInteger> pair = new IKVPairImpl<OMK, IInteger> ();
				request = worldcomm.ImmediateReceive<IKVPair<OMK, IInteger>> (MPI.Unsafe.MPI_ANY_SOURCE, tag, pair);
				request.Wait ();

				// Verifica se é um joker. Caso contrário, adiciona em target_data.
				if (pair.Key == -1) {
					jokers++;
				} else {
					Target_data.put (pair);
				}
			}
		}
	}
}
