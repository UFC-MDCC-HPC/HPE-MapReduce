using System;
using System.Threading;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.Shuffler;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.Integer;
using System.Collections.Generic;

namespace br.ufc.mdcc.mapreduce.impl.ShufflerImpl {
    public class ISourceShufflerImpl<OMK>: BaseISourceShufflerImpl<OMK>, ISourceShuffler<OMK>
    where OMK: IData {

        private MPI.Intracommunicator worldcomm;
		static private int TAG_SHUFFLER_OMV = 445;
		static private int TAG_SHUFFLER_OMV_FINISH = 446;
        private int gerente = 0;
        
        public ISourceShufflerImpl() {   }

		override public void initialize()
		{
			// Inicializar o comunicador MPI. 
			worldcomm = Mpi_comm.worldComm();
		}

        public override void main() 
		{
            /* 1. Ler os pares de chaves (OMK, OPK) de Source_data
             * 2. Enviar cada chave OMK para o reducer (unidade target)
             *    determinada pela chave OPK.
             */
			startThreads();
        }

		/* 1. Iniciar Threads */
		private void startThreads()
		{
			//Thread tRead = new Thread(new ThreadStart(readKVPairSendOMK));
			//tRead.Start();
			//tRead.Join();

			readKVPairSendOMK ();
		}

		/* 2. Ler pares KV do KVPair do Iterator, separar omks de opks em KVPair, e enviar omks por MPI ao target */
		private void readKVPairSendOMK() 
		{
            while (!Source_data.HasFinished) 
			{
                IKVPair<OMK, IInteger> kvpair = Source_data.fetch_next();
                OMK omk = kvpair.Key;
				int opk = (int) kvpair.Value.Value;
				worldcomm.Send<OMK>(omk, opk, TAG_SHUFFLER_OMV);
            }

			// 3. SEND "finish" message
			MPI.RequestList requests = new MPI.RequestList();
			int size_workers = this.UnitSize["target"];
			for (int i=0; i<size_workers;i++) 
			{
				MPI.Request request = worldcomm.ImmediateSend<OMK> (default(OMK), i, TAG_SHUFFLER_OMV_FINISH);
				requests.Add(request);
			}
			requests.WaitAll();
        }
    }
}
