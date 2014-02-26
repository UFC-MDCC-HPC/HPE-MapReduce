using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.splitter.ScatterSplitData;
using br.ufc.mdcc.common.KVPair;

namespace br.ufc.mdcc.mapreduce.splitter.impl.ScatterSplitDataImpl { 

public class ITargetScatterSplitDataImpl<IMK, IMV> : BaseITargetScatterSplitDataImpl<IMK, IMV>, ITargetScatterSplitData<IMK, IMV>
	where IMK:IData
	where IMV:IData {
		// Variáveis do Ambiente MPI.
		private MPI.Intracommunicator worldcomm = null;
		private int TAG_SPLITTER_IMK = 245;
		private int TAG_SPLITTER_IMV = 246;
		private int TAG_SPLITTER_IMK_FINISH = 247;

		public ITargetScatterSplitDataImpl() { } 

		override public void initialize()
		{
			worldcomm = Mpi_comm.worldComm();
		}

		public override void main() 
		{ 
			// 1. recebe os bins enviados pelo gerente (unidade source),
			//    através do MPI, e os insere no Target_data.

			MPI.CompletedStatus status;
			int source_rank = this.SingletonUnitRank["source"];
			IMK bin_key; 
			IMV bin_value;

			worldcomm.Receive<IMK> (source_rank, MPI.Unsafe.MPI_ANY_TAG, out bin_key, out status);
			while (status.Tag != TAG_SPLITTER_IMK_FINISH)
			{
				worldcomm.Receive<IMV> (source_rank, TAG_SPLITTER_IMV, out bin_value, out status);

				IKVPair<IMK, IMV> bin = Target_data.createItem();
				bin.Key.loadFrom(bin_key);
				bin.Value.loadFrom(bin_value);

				worldcomm.Receive<IMK> (source_rank, MPI.Unsafe.MPI_ANY_TAG, out bin_key, out status);
			}

		}
	}
}
