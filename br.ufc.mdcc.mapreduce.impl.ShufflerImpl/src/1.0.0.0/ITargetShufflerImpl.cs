using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.Shuffler;
using System.Collections.Generic;

namespace br.ufc.mdcc.mapreduce.impl.ShufflerImpl {
    public class ITargetShufflerImpl<OMK, OMV>: BaseITargetShufflerImpl<OMK, OMV>, ITargetShuffler<OMK, OMV>
        where OMK: IData
        where OMV: IData {
        private MPI.Intracommunicator worldcomm = null;
        private int tag = 345;
        private OMK[] omks;
        public ITargetShufflerImpl() {
            worldcomm = Mpi_comm.worldComm();
        }

        public override void main() {
            /* 1. Receber as chaves OMK enviadas pelo gerente (unidade source).
             * 2. Buscar nos mappers (que unidade ?) os valores.
             * 	  (buscando ainda solução para comunicação com os mappers)
             */
            receive();
        }
        public void receive() {
            MPI.Request[] requests = new MPI.Request[2];
            int[] len = new int[1];
            requests[0] = worldcomm.ImmediateReceive<int>(MPI.Unsafe.MPI_ANY_SOURCE, tag+1, len);
            requests[0].Wait();
            omks = new OMK[len[0]];
            requests[1] = worldcomm.ImmediateReceive<OMK>(MPI.Unsafe.MPI_ANY_SOURCE, tag, omks);
            requests[1].Wait();
        }
    }
}
