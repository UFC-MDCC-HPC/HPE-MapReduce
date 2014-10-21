using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.splitter.ScatterSplitData;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Iterator;
using System.Diagnostics;

namespace br.ufc.mdcc.mapreduce.splitter.impl.ScatterSplitDataImpl { 

public class ITargetScatterSplitDataImpl<IMK, IMV> : BaseITargetScatterSplitDataImpl<IMK, IMV>, ITargetScatterSplitData<IMK, IMV>
	where IMK:IData
	where IMV:IData {
		// Variáveis do Ambiente MPI.
		private MPI.Intracommunicator comm = null;
		private int TAG_SPLITTER_IMK = 245;
		private int TAG_SPLITTER_IMV = 246;
		private int TAG_SPLITTER_IMK_FINISH = 247;

		override public void initialize()
		{
			comm = this.Communicator;
		}

		public override void main() 
		{ 
			int count =0;

			// 1. recebe os bins enviados pelo gerente (unidade source),
			//    através do MPI, e os insere no Target_data.

			Trace.WriteLine(WorldComm.Rank + ": STARTING SCATTER SPLIT DATA TARGET");

			MPI.CompletedStatus status;
			int source_rank = this.UnitRanks["source"][0];
			object bin_key; 
			object bin_value;

			IIteratorInstance<IKVPair<IMK, IMV>> target_data_instance = (IIteratorInstance<IKVPair<IMK, IMV>>) Target_data.Instance;

			Trace.WriteLine(WorldComm.Rank + ": BEGIN RECEIVE BIN KEY from " + source_rank + "count=" + (count++));
			comm.Receive<object> (source_rank, MPI.Unsafe.MPI_ANY_TAG, out bin_key, out status);
			Trace.WriteLine(WorldComm.Rank + ": END RECEIVE BIN KEY from " + source_rank);
			while (status.Tag != TAG_SPLITTER_IMK_FINISH)
			{
				Trace.WriteLine(WorldComm.Rank + ": BEGIN RECEIVE BIN VALUE from " + source_rank);
				comm.Receive<object> (source_rank, TAG_SPLITTER_IMV, out bin_value, out status);
				Trace.WriteLine(WorldComm.Rank + ": END RECEIVE BIN VALUE from " + source_rank);
				IKVPairInstance<IMK, IMV> pair = (IKVPairInstance<IMK, IMV>) Target_data.createItem();
				pair.Key = bin_key;
				pair.Value = bin_value;
				target_data_instance.put(pair);
				Trace.WriteLine(WorldComm.Rank + ": BEGIN RECEIVE BIN KEY from " + source_rank + "count=" + (count++));
				comm.Receive<object> (source_rank, MPI.Unsafe.MPI_ANY_TAG, out bin_key, out status);
			Trace.WriteLine(WorldComm.Rank + ": END RECEIVE BIN KEY from " + source_rank);

			}

			Trace.WriteLine(WorldComm.Rank + ": FINISH ALL BIN KEYs #1 !!!");
			target_data_instance.finish();
			Trace.WriteLine(WorldComm.Rank + ": FINISH ALL BIN KEYs #2 !!!");

		}
	}
}
