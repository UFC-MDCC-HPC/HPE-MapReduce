using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.FetchValues;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.mapreduce.user.PartitionFunction;
using environment.MPIDirect;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Threading;

namespace br.ufc.mdcc.mapreduce.impl.FetchValuesImpl { 

	public class IMapperFetchValuesImpl<P,OMK,OMV> : BaseIMapperFetchValuesImpl<P,OMK,OMV>, IFetchValuesMapper<P,OMK,OMV>
		where OMK:IData
		where OMV:IData
		where P:IPartitionFunction<OMK>
		{



		private MPI.Intracommunicator worldcomm = null;
		static private int TAG_FETCHVALUES_OMV = 345;
		static private int TAG_FETCHVALUES_OMV_FINISH = 347;

		public IMapperFetchValuesImpl() { } 

		override public void initialize()
		{
			// Inicializar o comunicador MPI. 
			worldcomm = Mpi_comm.worldComm();
		}

		private ConcurrentQueue<KeyValuePair<OMK,OMV>>[] values;




		public override void main() 
		{ 

			/* 1. Ler os elementos de Source_data, um a um, e copiar a chave (OMK) em Data_key.
			 * 2. A cada chave de Source_data, chamar Partition_function.go();
			 * 3. Enviar o resultado de Partition_function.go(), via MPI, para o gerente (unidade target).
			 */

			int nr = this.UnitSize["reducer"];
			values = new ConcurrentQueue<KeyValuePair<OMK,OMV>>[nr];

			TaskFactory task_factory = new TaskFactory();
			for (int reducer_rank=0; reducer_rank<nr; reducer_rank++) {
				values[reducer_rank] = new ConcurrentQueue<KeyValuePair<OMK,OMV>>();
				task_factory.StartNew(delegate { send_values(reducer_rank); });
			}


			// 1. Ler os elementos de Source_data, um a um, e copiar a chave (OMK) em Data_key.
			while (!Map_result.HasFinished) 
			{
				IKVPair<OMK, OMV> item = Map_result.fetch_next ();
				Data_key.loadFrom(item.Key);

				// 2. A cada chave de Source_data, chamar Partition_function.go();
				Partition_function.go ();

				int reducer_rank = Partition_key.Value;					
				KeyValuePair<OMK,OMV> pair = new KeyValuePair<OMK, OMV>(item.Key,item.Value);
				values[reducer_rank].Enqueue(pair);
			}

			for (int reducer_rank=0; reducer_rank<nr; reducer_rank++) 
			{
				values[reducer_rank].Enqueue(new KeyValuePair<OMK, OMV>());
			}



		}

		private void send_values(int reducer_rank) 
		{
			ConcurrentQueue<KeyValuePair<OMK,OMV>> reducer_values = values[reducer_rank];

			int tag = TAG_FETCHVALUES_OMV;
			do
			{
				KeyValuePair<OMK,OMV> pair;
				if (reducer_values.TryDequeue(out pair)) 
				{
					tag = pair.Key == null ? TAG_FETCHVALUES_OMV_FINISH : TAG_FETCHVALUES_OMV;
					worldcomm.Send<KeyValuePair<OMK,OMV>> (pair, reducer_rank, tag);
				}

			}
			while(tag == TAG_FETCHVALUES_OMV_FINISH);

		}


	}

}
