using System;
using System.Threading;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.Shuffler;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.impl.KVPairImpl;
using System.Collections.Generic;

namespace br.ufc.mdcc.mapreduce.impl.ShufflerImpl {
    public class ITargetShufflerImpl<OMK, OMV>: BaseITargetShufflerImpl<OMK, OMV>, ITargetShuffler<OMK, OMV>
        where OMK: IData
        where OMV: IData {
        
        private MPI.Intracommunicator worldcomm = null;
        private int tag = 345;
        private List<OMK> omks;
        private object lock_omk = new object();
        private int start = 0;
        private int end = 0;
        private int max = int.MaxValue;
        private int gerente = 0;
        private Semaphore counter_sem;

        public ITargetShufflerImpl() {
            worldcomm = Mpi_comm.worldComm();
            omks = new List<OMK>();
            counter_sem = new Semaphore(0,int.MaxValue);
        }

        public override void main() {
            /* 1. Receber as chaves OMK enviadas pelo gerente (unidade source).
             * 2. Buscar nos mappers (que unidade ?) os valores.
             * 	  (buscando ainda solução para comunicação com os mappers)
             */
			startThreads ();
        }

		/* 1.Recebimento das OMKs, adicionando em lista para uso posterior no receiveOMV
		     onde serão obtidos OMVs de acordo com cada chave OMK. */
        public void receiveOMK() {
            Object o;
            OMK omk = default(OMK);
            bool finalized = false;
            while (!finalized) {
                o = worldcomm.Receive<Object>(MPI.Unsafe.MPI_ANY_SOURCE, tag);
                try {
                    omk = (OMK) o;
                }
                catch {
                    finalized = true;
                }
                lock (lock_omk) {
                    if (!finalized) {
                        omks.Add(omk);
                        counter_sem.Release();
                    }
                }
            }
            max = omks.Count;
            counter_sem.Release();
        }

        /* 2. Após sinalização do semáforo, informando que exite omk, configura-se a faixa de leitura da Lista omks (start/end). 
         * Para isso, adquire o lock_omk, para que não ocorram alterações pela outra thread em omks. 
         * Após definição de faixa, efetua-se RPC para adquirir os OMVs de cada chave omk, com base na faixa start/end da Lista omks. 
         * O Loop é finalizado quando a variável "end=max", o que ocorre com a finalização do método receiveOMK e a atribuição end=omks.Count */
        public void receiveOMV() {
            while (end!=max) {
                counter_sem.WaitOne();
                lock (lock_omk) {
                    start = end;
                    end = omks.Count;
                }
                for (int i = start; i < end; i++) {
					IKVPair<OMK, IIterator<OMV>> kvpair = new IKVPairImpl<OMK, IIterator<OMV>>();
                    IIterator<OMV> iteratorOMV = RPC(omks[i]);
                    kvpair.Key.readFrom(omks[i]);
                    kvpair.Value.readFrom(iteratorOMV);
                    Target_data.put(kvpair);
                }
            }
        }

        /* 3. Essa função modulariza a operação de recebimento de OMVs. Talvez por RPC. */
        private IIterator<OMV> RPC(OMK k) {
            //A implementar

            return default(IIterator<OMV>);
        }

        /* 4. Escuta broadcast de finalização do gerente. Libera "receiveOMK" enviando new Object() */
        private void anuncieFinishedListen() {
            bool b = false;
            worldcomm.Broadcast<bool>(ref b, gerente);
            worldcomm.Send<Object>(new Object(), worldcomm.Rank, tag);
        }

        /* 5. início de Threds */
        private void startThreads() {
            /*Instancias*/
            Thread tReceiveOMK = new Thread(new ThreadStart(receiveOMK));
            Thread tReceiveOMV = new Thread(new ThreadStart(receiveOMV));
            Thread tanuncieFinishedListen = new Thread(new ThreadStart(anuncieFinishedListen));

            /*Starting*/
            tReceiveOMK.Start();
            tReceiveOMV.Start();
            tanuncieFinishedListen.Start();

            /* Joins*/
            tanuncieFinishedListen.Join();
            tReceiveOMK.Join();
            tReceiveOMV.Join();
        }
    }
}
