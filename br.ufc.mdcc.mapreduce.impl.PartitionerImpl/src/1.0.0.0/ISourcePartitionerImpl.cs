using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.user.PartitionFunction;
using br.ufc.mdcc.mapreduce.Partitioner;
using environment.MPIDirect;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.impl.KVPairImpl;
using System.Collections.Generic;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.Iterator;

// Essa é a unidade Mapper. Existem várias.
// Criar uma thread em para ler Source_data elemento a elemento e enviar para o target.
namespace br.ufc.mdcc.mapreduce.impl.PartitionerImpl { 
	public class ISourcePartitionerImpl<OMK, OMV, P> : BaseISourcePartitionerImpl<OMK, OMV, P>, ISourcePartition<OMK, OMV, P>
    where OMK:IData
    where OMV:IData
	where P:IPartitionFunction<OMK> {
		// Variáveis do Ambiente MPI.
		private MPI.Intracommunicator worldcomm = null;
		private int tag = 345;

		public ISourcePartitionerImpl() { 
			// Inicializar o comunicador MPI. 
			worldcomm = Mpi_comm.worldComm();
		} 

		public override void main() {
			/* 1. Ler os elementos de Source_data, um a um, e copiar a chave (OMK) em Data_key.
			 * 2. A cada chave de Source_data, chamar Partition_function.go();
			 * 3. Enviar o resultado de Partition_function.go(), via MPI, para o gerente (unidade target).
			 */

			// 1. Ler os elementos de Source_data, um a um, e copiar a chave (OMK) em Data_key.
			while (!Source_data.HasFinished) {
				IKVPair<OMK, OMV> item = Source_data.fetch_next ();
				Data_key.readFrom(item.Key);

				// 2. A cada chave de Source_data, chamar Partition_function.go();
				IInteger omv = Partition_function.go ();
				IKVPair<OMK, IInteger> result = new IKVPairImpl<OMK, IInteger> ();
				result.Key = Data_key;
				result.Value = omv;

				// 3. Enviar o resultado de Partition_function.go(), via MPI, para o gerente (unidade target).
				worldcomm.Send<IKVPair<OMK, IInteger>> (result, this.UnitRanks["target"][0], tag);
			}

			// 4. Após o final do iterador, envia um par coringa para confirmar o fim.
			IKVPair<OMK, IInteger> joker = new IKVPairImpl<OMK, IInteger> ();
			joker.Key = -1;
			joker.Value = -1;
			worldcomm.Send<IKVPair<OMK, IInteger>> (joker, 0, tag);
		}
    }
}
