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
		private MPI.Intracommunicator comm = null;
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
			comm = this.Communicator;

			// Lista de requisições para controlar o progresso da comunicação.
			//requestList = new MPI.RequestList();
		}

		public override void main() 
		{ int count = 0;

			Console.WriteLine(WorldComm.Rank + ": STARTING SCATTER SPLIT DATA SOURCE");

			Bin_function.NumberOfPartitions = this.UnitSize["target"];

			IIteratorInstance<IKVPair<IMK, IMV>> bins_instance = (IIteratorInstance<IKVPair<IMK, IMV>> ) Bins.Instance;
			int[] rank_workers = this.UnitRanks["target"];		

			// 1. Ler os bins, um a um, do iterator, e enviá-los a cada mapper (unidades target) usando MPI.
			object bins_object;
			while (bins_instance.fetch_next(out bins_object)) 
			{
				Console.WriteLine(WorldComm.Rank + ": LOOP BIN");

				// Ler um bin. 
				IKVPairInstance<IMK, IMV> bin = (IKVPairInstance<IMK, IMV>) bins_object;

				// Recuperar a chave do bin.
				Key.Instance = bin.Key;

				// Descobre o rank do Mapper.
				Console.WriteLine(WorldComm.Rank + ": BEFORE BIN FUNCTION");
				Bin_function.go ();
				Console.WriteLine(WorldComm.Rank + ": AFTER BIN FUNCTION");

				int i = (int) ((IIntegerInstance)Rank.Instance).Value;
				int rank = rank_workers[i];

				// Inicia o envio do bin para o Mapper.
				//requestList.Add(worldcomm.ImmediateSend<IKVPair<IMK, IMV>> (bin, Rank.Value, tag));
				Console.WriteLine(WorldComm.Rank + ": SEND BIN KEY/VALUE to " + rank + "cont=" + (count++));
				comm.Send<object> (bin.Key, rank, TAG_SPLITTER_IMK);  Console.WriteLine(WorldComm.Rank + ": SEND BIN KEY OK to " + rank);
				comm.Send<object> (bin.Value, rank, TAG_SPLITTER_IMV); Console.WriteLine(WorldComm.Rank + ": SEND BIN VALUE OK to " + rank);
			}

			// send "finish" message
			MPI.RequestList requests = new MPI.RequestList();
			
			foreach (int i in rank_workers)
			{
				Console.WriteLine(WorldComm.Rank + ": BEGIN SEND BIN FINISH OK to " + i);
				MPI.Request request = comm.ImmediateSend<object> (0, i, TAG_SPLITTER_IMK_FINISH);
				Console.WriteLine(WorldComm.Rank + ": END SEND BIN FINISH OK to " + i);
				
				requests.Add(request);
			}

			requests.WaitAll();
			Console.WriteLine(WorldComm.Rank + ": SEND BIN FINISH OK ALL ");

			//requestList.WaitAll();
		}
	}
}
