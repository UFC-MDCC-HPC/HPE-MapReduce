using System;
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
        //private List<IKVPair<OMK, IInteger>> sourceList = new List<IKVPair<OMK, IInteger>>();
        private MPI.Intracommunicator worldcomm = null;
        public ISourceShufflerImpl() {
            worldcomm = Mpi_comm.worldComm();
        }

        public override void main() {
            /* 1. Ler os pares de chaves (OMK, OPK) de Source_data
             * 2. Enviar cada chave OMK para o reducer (unidade target)
             *    determinada pela chave OPK.
             */
            readSend();
        }
        public void readSend() {
            while (!Source_data.HasFinished) {
                IKVPair<OMK, IInteger> kvpair = Source_data.fetch_next();
                Object opk = kvpair.Value;
                worldcomm.ImmediateSend<OMK>(kvpair.Key, (int) opk, 0);
            }
        }
    }
}
