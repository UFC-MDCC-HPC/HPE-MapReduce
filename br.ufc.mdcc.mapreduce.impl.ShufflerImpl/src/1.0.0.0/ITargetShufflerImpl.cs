using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.Shuffler;

namespace br.ufc.mdcc.mapreduce.impl.ShufflerImpl {
    public class ITargetShufflerImpl<OMK, OMV>: BaseITargetShufflerImpl<OMK, OMV>, ITargetShuffler<OMK, OMV>
        where OMK: IData
        where OMV: IData {
        private MPI.Intracommunicator worldcomm = null;
        public ITargetShufflerImpl() {
        }

        public override void main() {
            /* 1. Receber as chaves OMK enviadas pelo gerente (unidade source).
             * 2. Buscar nos mappers (que unidade ?) os valores.
             * 	  (buscando ainda solução para comunicação com os mappers)
             */
        }
        public void receive() {
            while (!Source_data.HasFinished) {
                IKVPair<OMK, IInteger> kvpair = Source_data.fetch_next();
                Object opk = kvpair.Value;
                worldcomm.ImmediateSend<OMK>(kvpair.Key, (int)opk, 0);
            }


        }
    }
}
