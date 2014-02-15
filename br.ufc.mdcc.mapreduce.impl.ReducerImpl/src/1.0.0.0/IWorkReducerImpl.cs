using System;
using System.Threading;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.user.ReduceFunction;
using br.ufc.mdcc.mapreduce.Reducer;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Iterator;

namespace br.ufc.mdcc.mapreduce.impl.ReducerImpl {
    public class IWorkReducerImpl<OMK, OMV, ORV, R> :
    BaseIWorkReducerImpl<OMK, OMV, ORV, R>, IReducer<OMK, OMV, ORV, R>
        where OMK : IData
        where OMV : IData
        where ORV : IData
        where R : IReduceFunction<ORV, OMK, OMV> {

        public IWorkReducerImpl() {

        }

        public override void main() {
            /* 1. Ler pares chave (OMK) e valores (OMV) de Input.
             * 2. Para cada par, atribuir a Key e Values e chamar Reduce_function.go();
             * 3. Pegar o resultado de Reduction_function.go() de Output_reduce (ORV) 
             *    e colocar no iterator Output.
             */
            startThreads();
        }

        private void readPair_OMK_OMVs() {
            while (!Input.HasFinished) {
                IKVPair<OMK, IIterator<OMV>> kvpair = Input.fetch_next();
                Key.readFrom(kvpair.Key);
                Values.readFrom(kvpair.Value);
                int rf = Reduce_function.go();
                Output.put(Output_item);
            }
        }

        private void startThreads() {
            /*Instancias*/
            Thread treadPairOMKOMV = new Thread(new ThreadStart(readPair_OMK_OMVs));

            /*Starting*/
            treadPairOMKOMV.Start();

            /* Joins*/
            treadPairOMKOMV.Join();
        }
    }
}