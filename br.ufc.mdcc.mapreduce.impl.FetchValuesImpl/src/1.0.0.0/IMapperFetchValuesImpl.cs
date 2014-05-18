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
			private MPI.Intracommunicator comm = null;
			static private int TAG_FETCHVALUES_OMV = 345;
			static private int TAG_FETCHVALUES_OMV_FINISH = 347;

			public IMapperFetchValuesImpl() {	} 

			override public void initialize()
			{
				// Inicializar o comunicador MPI. 
				comm = this.Communicator;
			}

			public override void main() 
			{ 

				/* 1. Ler os elementos de Source_data, um a um, e copiar a chave (OMK) em Data_key.
				 * 2. A cada chave de Source_data, chamar Partition_function.go();
				 * 3. Enviar o resultado de Partition_function.go(), via MPI, para o gerente (unidade target).
				 */

				int[] reducer_ranks = this.UnitRanks["reducer"];
				int nr = this.UnitSize["reducer"];
				
				Partition_function.NumberOfPartitions = nr;

				IIteratorInstance<IKVPair<OMK,OMV>> map_result_instance = (IIteratorInstance<IKVPair<OMK,OMV>>) Map_result.Instance;

				int count=0;
				IKVPairInstance<OMK,OMV> last_item = null;

				object item_object;
				// 1. Ler os elementos de Source_data, um a um, e copiar a chave (OMK) em Data_key.
				while (map_result_instance.fetch_next(out item_object)) 
				{
					IKVPairInstance<OMK,OMV> item = (IKVPairInstance<OMK,OMV>) item_object;
					last_item = item;

					Data_key.Instance = item.Key;

					// 2. A cada chave de Source_data, chamar Partition_function.go();
					Partition_function.go ();

					int i = (int) ((IIntegerInstance)Partition_key.Instance).Value;					
					
					Console.WriteLine(WorldComm.Rank + ": PARTITIONER (FETCH VALUES SOURCE) LOOP - SEND TO " + reducer_ranks[i] + ", source rank is " + comm.Rank + ", count=" + (count++) + "i=" + i); 

					comm.Send<IKVPairInstance<OMK,OMV>>(item, reducer_ranks[i], TAG_FETCHVALUES_OMV);
				}
				
				for (int i=0; i < nr; i++)
					comm.Send<IKVPairInstance<OMK,OMV>>(last_item, reducer_ranks[i], TAG_FETCHVALUES_OMV_FINISH);

				Console.WriteLine(WorldComm.Rank + ": PARTITIONER (FETCH VALUES SOURCE) - FINISH ");
			}



	}

}
