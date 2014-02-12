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
		private int tag = 345;
		public ITargetScatterSplitDataImpl() { 
			worldcomm = Mpi_comm.worldComm();
		} 

		public override void main() { 

			// 1. recebe os bins enviados pelo gerente (unidade source),
			//    através do MPI, e os insere no Target_data.

			// Recebe o bin enviado pelo gerente.
			MPI.Request request = new MPI.Request ();
			IKVPair<IMK, IMV>[] bin = new IKVPair<IMK, IMV>[1];
			request = worldcomm.ImmediateReceive<IKVPair<IMK, IMV>> (MPI.Unsafe.MPI_ANY_SOURCE, tag, bin);
			request.Wait ();

			// Inserir no target_data.
			Target_data.put (bin [0]);
		}
	}
}
