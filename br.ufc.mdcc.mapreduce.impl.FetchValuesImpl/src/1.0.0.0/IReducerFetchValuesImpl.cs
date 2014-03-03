using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.FetchValues;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.KVPair;
using System.Collections.Generic;
using br.ufc.mdcc.common.Iterator;


namespace br.ufc.mdcc.mapreduce.impl.FetchValuesImpl { 

	public class IReducerFetchValuesImpl<OMK,OMV> : BaseIReducerFetchValuesImpl<OMK,OMV>, IFetchValuesReducer<OMK,OMV>
		where OMK:IData
		where OMV:IData
		{
		// Variáveis do Ambiente MPI.
		private MPI.Intracommunicator worldcomm = null;
		static private int TAG_FETCHVALUES_OMV = 345;
		static private int TAG_FETCHVALUES_OMV_FINISH = 347;


		public IReducerFetchValuesImpl() {	} 

		override public void initialize()
		{
			// Inicializar o comunicador MPI. 
			worldcomm = Mpi_comm.worldComm();
		}

		public override void main() 
		{ 
			MPI.CompletedStatus status;
			KeyValuePair<OMK,OMV> kv;

			IDictionary<OMK,IIterator<OMV>> kv_cache = new Dictionary<OMK, IIterator<OMV>>();

			worldcomm.Receive<KeyValuePair<OMK,OMV>>(MPI.Unsafe.MPI_ANY_SOURCE, MPI.Unsafe.MPI_ANY_TAG, out kv, out status);
			while (status.Tag != TAG_FETCHVALUES_OMV_FINISH)
			{
				IIterator<OMV> iterator;
				if (!kv_cache.ContainsKey(kv.Key))
				{
					IKVPair<OMK, IIterator<OMV>> pair = Reduce_job.createItem();
					pair.Key.loadFrom(kv.Key);
					iterator = pair.Value;
					kv_cache.Add(kv.Key, iterator);
				}
				else 
					kv_cache.TryGetValue(kv.Key, out iterator);
								
				iterator.put(kv.Value);

				worldcomm.Receive<KeyValuePair<OMK,OMV>>(MPI.Unsafe.MPI_ANY_SOURCE, MPI.Unsafe.MPI_ANY_TAG, out kv, out status);
			} 



		}
	}
}
