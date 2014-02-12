using System;
using System.Threading;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.Shuffler;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.impl.IteratorImpl;
using br.ufc.mdcc.common.Integer;
using System.Collections.Generic;

namespace br.ufc.mdcc.mapreduce.impl.ShufflerImpl {
    public class ISourceShufflerImpl<OMK>: BaseISourceShufflerImpl<OMK>, ISourceShuffler<OMK>
    where OMK: IData {

        private MPI.Intracommunicator worldcomm;
        private int tag = 345;
        
        public ISourceShufflerImpl() {
			worldcomm = Mpi_comm.WorldComm;
        }

        public override void main() {
            /* 1. Ler os pares de chaves (OMK, OPK) de Source_data
             * 2. Enviar cada chave OMK para o reducer (unidade target)
             *    determinada pela chave OPK.
             */
			startThreads();
        }

		//Iniciar Threads
		private void startThreads(){
			Thread tRead = new Thread(new ThreadStart(readKVPairSendOMK));
			tRead.Start();
			tRead.Join();
		}

		//Ler pares KV do Iterator, separar omks de opks e enviar por MPI ao target
		//No caso, Loop infinito, onde a thread dorme em Source_data.fetch_next(); aguardando
		//dados, caso não exista.
		private void readKVPairSendOMK() {
            while (!Source_data.HasFinished) {
                IKVPair<OMK, IInteger> kvpair = Source_data.fetch_next();
                OMK omk = kvpair.Key;
                int opk = (int) (Object) kvpair.Value;
                worldcomm.Send<OMK>(omk, opk, tag);
            }
        }
    }
}
