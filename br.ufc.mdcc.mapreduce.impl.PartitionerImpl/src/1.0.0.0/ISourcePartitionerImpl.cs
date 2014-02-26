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

// Essa é a unidade Mapper. Existem várias.
// Criar uma thread em para ler Source_data elemento a elemento e enviar para o target.
using System.Threading.Tasks;


namespace br.ufc.mdcc.mapreduce.impl.PartitionerImpl 
{ 
	public class ISourcePartitionerImpl<OMK, OMV, P> : BaseISourcePartitionerImpl<OMK, OMV, P>, ISourcePartition<OMK, OMV, P>
    where OMK:IData
    where OMV:IData
	where P:IPartitionFunction<OMK> 
	{
		// Variáveis do Ambiente MPI.
		private MPI.Intracommunicator worldcomm = null;
		static private int TAG_PARTITIONER_OPK = 345;
		static private int TAG_PARTITIONER_OPK_FINISH = 347;
		static private int TAG_PARTITIONER_OMK = 346;

		public ISourcePartitionerImpl() { } 

		override public void initialize()
		{
			// Inicializar o comunicador MPI. 
			worldcomm = Mpi_comm.worldComm();
		}


		public override void main() 
		{

			Task fetch_values_task = new Task (delegate {
				Fetch_values.go ();
			});

			fetch_values_task.Start ();


			/* 1. Ler os elementos de Source_data, um a um, e copiar a chave (OMK) em Data_key.
			 * 2. A cada chave de Source_data, chamar Partition_function.go();
			 * 3. Enviar o resultado de Partition_function.go(), via MPI, para o gerente (unidade target).
			 */

			// 1. Ler os elementos de Source_data, um a um, e copiar a chave (OMK) em Data_key.
			while (!Source_data.HasFinished) 
			{
				IKVPair<OMK, OMV> item = Source_data.fetch_next ();
				Data_key.loadFrom(item.Key);

				// 2. A cada chave de Source_data, chamar Partition_function.go();
				Partition_function.go ();

				// 3. Enviar o resultado de Partition_function.go(), via MPI, para o gerente (unidade target).
				int tag = Source_data.HasFinished ? TAG_PARTITIONER_OPK_FINISH : TAG_PARTITIONER_OPK;
				worldcomm.Send<int> (Partition_key.Value, this.SingletonUnitRank["target"], tag);
				worldcomm.Send<OMK> (Data_key, this.SingletonUnitRank["target"], TAG_PARTITIONER_OMK);
			}

			fetch_values_task.Wait();
		}
    }
}
