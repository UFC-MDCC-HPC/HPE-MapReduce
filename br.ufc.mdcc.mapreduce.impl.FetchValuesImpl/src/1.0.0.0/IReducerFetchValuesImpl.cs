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
			IKVPairInstance<OMK,IIterator<OMV>> kv;

			IIteratorInstance<IKVPair<OMK,IIterator<OMV>>> reduce_job_instance = (IIteratorInstance<IKVPair<OMK,IIterator<OMV>>>) Reduce_job.Instance;

			IDictionary<object,IIteratorInstance<OMV>> kv_cache = new Dictionary<object, IIteratorInstance<OMV>>();

			worldcomm.Receive<IKVPairInstance<OMK,IIterator<OMV>>>(MPI.Unsafe.MPI_ANY_SOURCE, MPI.Unsafe.MPI_ANY_TAG, out kv, out status);
			while (status.Tag != TAG_FETCHVALUES_OMV_FINISH)
			{
				IIteratorInstance<OMV> iterator = null;
				if (!kv_cache.ContainsKey(kv.Key))
				{
					iterator = Reduce_job_values_factory.newIteratorInstance ();

					kv_cache.Add(kv.Key, (IIteratorInstance<OMV>) kv.Value);
					reduce_job_instance.put (kv);
				}
				else 
					kv_cache.TryGetValue(kv.Key, out iterator);
								
				iterator.putAll((IIteratorInstance<OMV>) kv.Value);

				worldcomm.Receive<IKVPairInstance<OMK,IIterator<OMV>>>(MPI.Unsafe.MPI_ANY_SOURCE, MPI.Unsafe.MPI_ANY_TAG, out kv, out status);
			} 
		}
	}
}
