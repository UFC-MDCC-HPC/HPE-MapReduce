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
		private int tag = 345;
		MPI.RequestList requestList;
		List<MPI.Request> requests;

		public ISourceScatterSplitDataImpl() { 
			// Inicializar o comunicador MPI. 
			worldcomm = Mpi_comm.worldComm();

			// Lista de requisições para controlar o progresso da comunicação.
			requestList = new MPI.RequestList();
			requests = new List<MPI.Request>();
        } 

		public override void main() { 
			// 1. Ler os bins, um a um, do iterator, e enviá-los a cada mapper (unidades target) usando MPI.
			while (!Bins.HasFinished) {
				// Ler um bin. 
				IKVPair<IMK, IMV> bin = Bins.fetch_next ();

				// Recuperar a chave do bin.
				Key = bin.Key;

				// Descobre o rank do Mapper.
				Rank = Bin_function.go ();

				// Inicia o envio do bin para o Mapper.
				requests.Add (worldcomm.ImmediateSend<IKVPair<IMK, IMV>> (bin, Rank, tag));
			}

			// Espera todas os envios terminarem.
			foreach (MPI.Request request in requests.ToArray()) {
				requestList.Add(request);
			}
			requestList.WaitAll();
		}
	}
}
