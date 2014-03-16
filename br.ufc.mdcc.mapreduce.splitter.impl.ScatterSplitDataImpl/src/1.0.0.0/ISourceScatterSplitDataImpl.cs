using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.splitter.ScatterSplitData;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Iterator;
using System.Collections.Generic;

namespace br.ufc.mdcc.mapreduce.splitter.impl.ScatterSplitDataImpl { 

public class ISourceScatterSplitDataImpl<IMK, IMV> : BaseISourceScatterSplitDataImpl<IMK, IMV>, ISourceScatterSplitData<IMK, IMV>
	where IMK:IData
	where IMV:IData {
		// Variáveis do Ambiente MPI.
		private MPI.Intracommunicator worldcomm = null;
		private int TAG_SPLITTER_IMK = 245;
		private int TAG_SPLITTER_IMV = 246;
		private int TAG_SPLITTER_IMK_FINISH = 247;
		//MPI.RequestList requestList;
		//List<MPI.Request> requests;

		public ISourceScatterSplitDataImpl() { 
        } 

		override public void initialize()
		{
			// Inicializar o comunicador MPI. 
			worldcomm = Mpi_comm.worldComm();

			// Lista de requisições para controlar o progresso da comunicação.
			//requestList = new MPI.RequestList();
		}

		public override void main() 
		{ 
			Bin_function.NumberOfPartitions = this.UnitSize["target"];

			// 1. Ler os bins, um a um, do iterator, e enviá-los a cada mapper (unidades target) usando MPI.
			while (!Bins.HasFinished) 
			{
				// Ler um bin. 
				IKVPair<IMK, IMV> bin = Bins.fetch_next ();

				// Recuperar a chave do bin.
				Key.loadFrom(bin.Key);

				// Descobre o rank do Mapper.
				Bin_function.go ();

				// Inicia o envio do bin para o Mapper.
				//requestList.Add(worldcomm.ImmediateSend<IKVPair<IMK, IMV>> (bin, Rank.Value, tag));
				worldcomm.Send<IMK> (bin.Key, Rank.Value, TAG_SPLITTER_IMK);
				worldcomm.Send<IMV> (bin.Value, Rank.Value, TAG_SPLITTER_IMV);
			}

			// send "finish" message
			MPI.RequestList requests = new MPI.RequestList();
			int size_workers = this.UnitSize["target"];
			for (int i=0; i<size_workers;i++)
			{
				MPI.Request request = worldcomm.ImmediateSend<IMK> (default(IMK), i, TAG_SPLITTER_IMK_FINISH);
				requests.Add(request);
			}
			requests.WaitAll();

			//requestList.WaitAll();
		}
	}
}
