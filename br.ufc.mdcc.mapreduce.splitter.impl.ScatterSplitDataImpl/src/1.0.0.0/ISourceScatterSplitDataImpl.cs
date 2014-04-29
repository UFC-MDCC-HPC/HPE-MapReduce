using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.splitter.ScatterSplitData;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Iterator;
using System.Collections.Generic;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.mapreduce.user.PartitionFunction;

namespace br.ufc.mdcc.mapreduce.splitter.impl.ScatterSplitDataImpl { 

	public class ISourceScatterSplitDataImpl<IMK, IMV, Bf> : BaseISourceScatterSplitDataImpl<IMK, IMV, Bf>, ISourceScatterSplitData<IMK, IMV, Bf>
		where IMK:IData
		where IMV:IData 
		where Bf:IPartitionFunction<IMK>
	{
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

			IIteratorInstance<IKVPair<IMK, IMV>> bins_instance = (IIteratorInstance<IKVPair<IMK, IMV>> ) Bins.Instance;

			// 1. Ler os bins, um a um, do iterator, e enviá-los a cada mapper (unidades target) usando MPI.
			while (!bins_instance.HasFinished) 
			{
				// Ler um bin. 
				IKVPairInstance<IMK, IMV> bin = (IKVPairInstance<IMK, IMV>) bins_instance.fetch_next ();

				// Recuperar a chave do bin.
				Key.Instance = bin.Key;

				// Descobre o rank do Mapper.
				Bin_function.go ();

				int rank = (int) ((IIntegerInstance)Rank.Instance).Value;

				// Inicia o envio do bin para o Mapper.
				//requestList.Add(worldcomm.ImmediateSend<IKVPair<IMK, IMV>> (bin, Rank.Value, tag));
				worldcomm.Send<object> (bin.Key, rank, TAG_SPLITTER_IMK);
				worldcomm.Send<object> (bin.Value, rank, TAG_SPLITTER_IMV);
			}

			// send "finish" message
			MPI.RequestList requests = new MPI.RequestList();
			int size_workers = this.UnitSize["target"];
			for (int i=0; i<size_workers;i++)
			{
				MPI.Request request = worldcomm.ImmediateSend<object> (0, i, TAG_SPLITTER_IMK_FINISH);
				requests.Add(request);
			}
			requests.WaitAll();

			//requestList.WaitAll();
		}
	}
}
