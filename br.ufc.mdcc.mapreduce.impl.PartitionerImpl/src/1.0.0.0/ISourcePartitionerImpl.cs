using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.user.PartitionFunction;
using br.ufc.mdcc.mapreduce.Partitioner;
using environment.MPIDirect;
using br.ufc.mdcc.common.KVPair;
using System.Collections.Generic;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.Iterator;

namespace br.ufc.mdcc.mapreduce.impl.PartitionerImpl { 
	public class ISourcePartitionerImpl<OMK, OMV, P> : BaseISourcePartitionerImpl<OMK, OMV, P>, ISourcePartition<OMK, OMV, P>
    where OMK:IData
    where OMV:IData
	where P:IPartitionFunction<OMK> {
		// Variáveis do Ambiente MPI.
		private MPI.Intracommunicator worldcomm = null;
		private int tag = 345;
		MPI.RequestList requestList;
		List<MPI.Request> requests;

		public ISourcePartitionerImpl() { 
			// Inicializar o comunicador MPI. 
			worldcomm = Mpi_comm.worldComm();

			// Lista de requisições para controlar o progresso da comunicação.
			requestList = new MPI.RequestList();
			requests = new List<MPI.Request>();
		} 

		public override void main() {
			/* 1. Ler os elementos de Source_data, um a um, e copiar a chave (OMK) em Data_key.
			 * 2. A cada chave de Source_data, chamar Partition_function.go();
			 * 3. Enviar o resultado de Partition_function.go(), via MPI, para o gerente (unidade target).
			 */

			// 1. Ler os elementos de Source_data, um a um, e copiar a chave (OMK) em Data_key.
			while (!Source_data.HasFinished) {
				IKVPair<OMK, OMV> item = Source_data.fetch_next ();
				Data_key = item.Key;

				// 2. A cada chave de Source_data, chamar Partition_function.go();
				// Dúvida: cada invocação de .go() vai preenchendo o iterador Output_partition_info_source?
				// Primeira opção) Caso seja assim, posso chamar .go() várias vezes e só depois do while enviar o iterator via MPI.
				// Segunda opção) Caso a cada invocação crie um iterator diferente, devo enviar dentro do while.
				Partition_function.go ();
			}
			// 3. Enviar o resultado de Partition_function.go(), via MPI, para o gerente (unidade target).
			// Dúvida 1: como saber o rank da unidade target? Ou não precisa?
			// Dúvida 2: posso mandar logo todo o iterator?
			requestList.Add(worldcomm.ImmediateSend<IIterator<IKVPair<OMK, IInteger>>> (Output_partition_info_source, worldcomm.Rank, tag));
			requestList.WaitAll ();
		}
    }
}
