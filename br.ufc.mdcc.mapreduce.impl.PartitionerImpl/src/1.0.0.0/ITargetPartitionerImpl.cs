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
			//			// Vou ter que receber number_of_mappers jokers até finalizar.
			//			int number_of_mappers = this.UnitSize["source"];
			//			int jokers = 0;

			//			while (jokers < number_of_mappers) 
			//			{
			//				// Recebe o par do mapper
				//MPI.Request request = new MPI.Request ();
			//	IKVPair<OMK, IInteger> pair = Target_data.createItem();

			//				int pair_value;
			//				MPI.CompletedStatus status;
			//				worldcomm.Receive<int> (MPI.Unsafe.MPI_ANY_SOURCE, MPI.Unsafe.MPI_ANY_TAG, out pair_value, out status);

			//				// Verifica se é um joker. Caso contrário, adiciona em target_data.
			//				OMK pair_key;
			//				worldcomm.Receive<OMK> (status.Source, TAG_PARTITIONER_OMK, out pair_key);
			//				pair.Key = pair_key;
			//				pair.Value.Value = pair_value;

			//				if (status.Tag == TAG_PARTITIONER_OPK_FINISH) jokers++;
			//			}
		}
	}
}
