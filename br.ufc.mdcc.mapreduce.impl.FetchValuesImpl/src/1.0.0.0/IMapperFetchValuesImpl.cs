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
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.Integer;

namespace br.ufc.mdcc.mapreduce.impl.FetchValuesImpl { 

	public class IMapperFetchValuesImpl<OMK,OMV,P> : BaseIMapperFetchValuesImpl<OMK,OMV,P>, IFetchValuesMapper<OMK,OMV,P>
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

			private ConcurrentQueue<IKVPairInstance<OMK,OMV>>[] values;
			private int[] counts;

			public override void main() 
			{ 

				/* 1. Ler os elementos de Source_data, um a um, e copiar a chave (OMK) em Data_key.
				 * 2. A cada chave de Source_data, chamar Partition_function.go();
				 * 3. Enviar o resultado de Partition_function.go(), via MPI, para o gerente (unidade target).
				 */

				int nr = this.UnitSize["reducer"];
				values = new ConcurrentQueue<IKVPairInstance<OMK,OMV>>[nr];
				counts = new int[nr];

				TaskFactory task_factory = new TaskFactory();
				for (int reducer_rank=0; reducer_rank<nr; reducer_rank++) {
					values[reducer_rank] = new ConcurrentQueue<IKVPairInstance<OMK,OMV>>();
					task_factory.StartNew(delegate { send_values(reducer_rank); });
				}

				Partition_function.NumberOfPartitions = nr;

				IIteratorInstance<IKVPair<OMK,OMV>> map_result_instance = (IIteratorInstance<IKVPair<OMK,OMV>>) Map_result.Instance;


				// 1. Ler os elementos de Source_data, um a um, e copiar a chave (OMK) em Data_key.
				while (!map_result_instance.HasFinished) 
				{
					IKVPairInstance<OMK,OMV> item = (IKVPairInstance<OMK,OMV>) map_result_instance.fetch_next ();

					Data_key.Instance = item.Key;

					// 2. A cada chave de Source_data, chamar Partition_function.go();
					Partition_function.go ();

					int reducer_rank = (int) ((IIntegerInstance)Partition_key.Instance).Value;					

					values[reducer_rank].Enqueue(item);
					counts[reducer_rank]++;
				}

			}

			private void send_values(int reducer_rank) 
			{
				ConcurrentQueue<IKVPairInstance<OMK,OMV>> reducer_values = values[reducer_rank];
				int count_values = counts[reducer_rank];

				int tag = TAG_FETCHVALUES_OMV;
				do
				{
					IKVPairInstance<OMK,OMV> pair;
					if (count_values>0 && reducer_values.TryDequeue(out pair)) 
					{
						count_values--;
						tag = count_values==0 ? TAG_FETCHVALUES_OMV_FINISH : TAG_FETCHVALUES_OMV;
						worldcomm.Send<IKVPairInstance<OMK,OMV>>(pair, reducer_rank, tag);
					}

				}
				while(tag == TAG_FETCHVALUES_OMV_FINISH);

			}


	}

}
