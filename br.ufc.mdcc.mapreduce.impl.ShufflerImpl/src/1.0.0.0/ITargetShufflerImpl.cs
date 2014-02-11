using System;
using System.Threading;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.Shuffler;
using br.ufc.mdcc.common.impl.IteratorImpl;
using System.Collections.Generic;

namespace br.ufc.mdcc.mapreduce.impl.ShufflerImpl {
    public class ITargetShufflerImpl<OMK, OMV>: BaseITargetShufflerImpl<OMK, OMV>, ITargetShuffler<OMK, OMV>
        where OMK: IData
        where OMV: IData {
        
        private MPI.Intracommunicator worldcomm = null;
        private int tag = 345;
        private List<OMK> omks;

        public ITargetShufflerImpl() {
            worldcomm = Mpi_comm.worldComm();
            omks = new List<OMK>();
        }
        public override void main() {
            /* 1. Receber as chaves OMK enviadas pelo gerente (unidade source).
             * 2. Buscar nos mappers (que unidade ?) os valores.
             * 	  (buscando ainda solução para comunicação com os mappers)
             */
            Thread tReceive = new Thread(new ThreadStart(receive));
            tReceive.Start();
            tReceive.Join();
        }
        public void receive() {
            while (true) {
                OMK omk  = worldcomm.Receive<OMK>(MPI.Unsafe.MPI_ANY_SOURCE, tag);
                if (omk.Equals(null)) { break; }
                omks.Add(omk);
            }
        }
    }
}
