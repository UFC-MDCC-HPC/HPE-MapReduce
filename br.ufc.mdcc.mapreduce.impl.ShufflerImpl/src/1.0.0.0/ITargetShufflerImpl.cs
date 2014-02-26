using System;
using System.Threading;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.Shuffler;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using System.Collections.Generic;

namespace br.ufc.mdcc.mapreduce.impl.ShufflerImpl {
    public class ITargetShufflerImpl<OMK, OMV>: BaseITargetShufflerImpl<OMK, OMV>, ITargetShuffler<OMK, OMV>
        where OMK: IData
        where OMV: IData {
        
        private MPI.Intracommunicator worldcomm = null;
       	static private int TAG_SHUFFLER_OMV = 445;
		static private int TAG_SHUFFLER_OMV_FINISH = 446;

        public ITargetShufflerImpl() {}

		override public void initialize()
		{
			// Inicializar o comunicador MPI. 
			worldcomm = Mpi_comm.worldComm();
		}

        public override void main() 
		{
            /* 1. Receber as chaves OMK enviadas pelo gerente (unidade source).
             * 2. Buscar nos mappers (que unidade ?) os valores.
             * 	  (buscando ainda solução para comunicação com os mappers)
             */
			startThreads ();
        }

		/* 5. início de Threds */
		private void startThreads() 
		{
			/* Instancias */
			Thread tReceiveOMK = new Thread(new ThreadStart(receiveOMK));
			Thread tReceiveOMV = new Thread(new ThreadStart(receiveOMV));

			/* Starting */
			tReceiveOMK.Start();
			tReceiveOMV.Start();

			/* Joins */
			tReceiveOMK.Join();
			tReceiveOMV.Join();
		}


		/* 1.Recebimento das OMKs, adicionando em lista para uso posterior no receiveOMV
		     onde serão obtidos OMVs de acordo com cada chave OMK. */
        public void receiveOMK() 
		{
			OMK omk;
			int source_rank = this.SingletonUnitRank["source"];
			MPI.CompletedStatus status;

			worldcomm.Receive<OMK> (source_rank, MPI.Unsafe.MPI_ANY_TAG, out omk, out status);
			while (status.Tag != TAG_SHUFFLER_OMV_FINISH) 
			{
				IKVPair<OMK,IIterator<OMV>> item = this.Target_data.createItem ();
				item.Key.loadFrom (omk);	
									
				worldcomm.Receive<OMK> (source_rank, MPI.Unsafe.MPI_ANY_TAG, out omk, out status);
			}
        }

        /* 2. Após sinalização do semáforo, informando que exite omk, configura-se a faixa de leitura da Lista omks (start/end). 
         * Para isso, adquire o lock_omk, para que não ocorram alterações pela outra thread em omks. 
         * Após definição de faixa, efetua-se RPC para adquirir os OMVs de cada chave omk, com base na faixa start/end da Lista omks. 
         * O Loop é finalizado quando a variável "end=max", o que ocorre com a finalização do método receiveOMK e a atribuição end=omks.Count */
        public void receiveOMV() 
		{
			Fetch_values.go ();
        }

 
  
    }
}
