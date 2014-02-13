using System;
using System.Threading;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.Shuffler;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.impl.IteratorImpl;
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

        public ITargetShufflerImpl() {
            worldcomm = Mpi_comm.worldComm();
            omks = new List<OMK>();
        }
        public override void main() {
            /* 1. Receber as chaves OMK enviadas pelo gerente (unidade source).
             * 2. Buscar nos mappers (que unidade ?) os valores.
             * 	  (buscando ainda solução para comunicação com os mappers)
             */
			startThreads ();
        }
		private void startThreads(){
			Thread tReceiveOMK = new Thread(new ThreadStart(receiveOMK));
			Thread tReceiveOMV = new Thread(new ThreadStart(receiveOMV));
			tReceiveOMK.Start();
			tReceiveOMV.Start();
			tReceiveOMK.Join();
			tReceiveOMV.Join();
		}

		/* 1.Recebimento das OMKs, adicionando em lista para uso posterior no receiveOMV
		     onde serão obtidos OMVs de acordo com cada chave OMK. */
        public void receiveOMK() {
            while (true) {
                OMK omk  = worldcomm.Receive<OMK>(MPI.Unsafe.MPI_ANY_SOURCE, tag); //if (omk.Equals(null)) { break; }
                lock (lock_omk) { 
                    omks.Add(omk);
                }
            }
        }

        /* 2. Primeiramente se configura a faixa de leitura da Lista-omks (start/end). Para isso, adquire o lock_omk
              para que não ocorra alterações pela outra thread. Após isso, efetura-se RPC para adquirir os OMVs, com base 
              na faixa start/end da Lista omks.*/
        public void receiveOMV() {
            while (true) {
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
    }
}
