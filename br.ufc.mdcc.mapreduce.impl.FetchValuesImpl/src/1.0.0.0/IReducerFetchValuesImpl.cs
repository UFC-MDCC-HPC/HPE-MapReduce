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
		private MPI.Intracommunicator comm = null;
		static private int TAG_FETCHVALUES_OMV = 345;
		static private int TAG_FETCHVALUES_OMV_FINISH = 347;


		//public IReducerFetchValuesImpl() {	} 

		override public void initialize()
		{
			// Inicializar o comunicador MPI. 
			comm = this.Communicator;
		}

		public override void main() 
		{ 
			MPI.CompletedStatus status;
			IKVPairInstance<OMK,OMV> kv;

			int senders_size = this.UnitSize ["mapper"];

			IIteratorInstance<IKVPair<OMK,IIterator<OMV>>> reduce_job_instance = (IIteratorInstance<IKVPair<OMK,IIterator<OMV>>>) Reduce_job.Instance;

			IDictionary<object,IIteratorInstance<OMV>> kv_cache = new Dictionary<object,IIteratorInstance<OMV>>();

			int finished_senders = 0;

	//		Console.WriteLine(WorldComm.Rank + ": PARTITIONER (FETCH VALUES TARGET) BEGIN RECEIVE 1 !");
			comm.Receive<IKVPairInstance<OMK,OMV>>(MPI.Unsafe.MPI_ANY_SOURCE, MPI.Unsafe.MPI_ANY_TAG, out kv, out status);
	//		Console.WriteLine(WorldComm.Rank + ": PARTITIONER (FETCH VALUES TARGET) END RECEIVE 1  ! tag=" + status.Tag + ", source=" + status.Source);

			int count=0;
			bool last_finished = false;
			if (status.Tag == TAG_FETCHVALUES_OMV_FINISH) 
			{
				finished_senders ++;
				last_finished = true;
			}

			while (finished_senders < senders_size)
			{
				if (!last_finished) {
					IIteratorInstance<OMV> iterator = null;
					if (!kv_cache.ContainsKey (kv.Key)) {
		//				Console.WriteLine (WorldComm.Rank + ": PARTITIONER (FETCH VALUES TARGET) LOOP RECV 1 !" + (count++) + " " + kv.Key.GetType ());
						iterator = Reduce_job_values_factory.newIteratorInstance ();
						kv_cache.Add (kv.Key, iterator);
						IKVPairInstance<OMK,IIterator<OMV>> item = (IKVPairInstance<OMK,IIterator<OMV>>)Reduce_job.createItem ();
						item.Key = kv.Key;
						item.Value = iterator;
						reduce_job_instance.put (item);
					} else {
		//				Console.WriteLine (WorldComm.Rank + ": PARTITIONER (FETCH VALUES TARGET) LOOP RECV 2 !" + (count++));
						kv_cache.TryGetValue (kv.Key, out iterator);
					}								
					iterator.put (kv.Value);
				} 
				else 
				{
					last_finished = false;
		//			Console.WriteLine(WorldComm.Rank + ": PARTITIONER (FETCH VALUES TARGET) - FINISH DETECTED ");
				}

		//		Console.WriteLine(WorldComm.Rank + ": PARTITIONER (FETCH VALUES TARGET) BEGIN RECEIVE n !");
				comm.Receive<IKVPairInstance<OMK,OMV>>(MPI.Unsafe.MPI_ANY_SOURCE, MPI.Unsafe.MPI_ANY_TAG, out kv, out status);
		//		Console.WriteLine(WorldComm.Rank + ": PARTITIONER (FETCH VALUES TARGET) END RECEIVE n ! tag=" + status.Tag + ", source=" + status.Source);

				if (status.Tag == TAG_FETCHVALUES_OMV_FINISH) 
				{
					finished_senders ++;
					last_finished = true;
				}
			} 

			foreach (KeyValuePair<object,IIteratorInstance<OMV>> kv_item in kv_cache)
				kv_item.Value.finish();

			reduce_job_instance.finish();
		//	Console.WriteLine(WorldComm.Rank + ": PARTITIONER (FETCH VALUES TARGET) - CLOSING OUTPUT STREAM ");


		}
	}
}
