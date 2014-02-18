using System;
using System.Threading;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.Combiner;
using br.ufc.mdcc.mapreduce.user.CombineFunction;

namespace br.ufc.mdcc.mapreduce.impl.CombinerImpl {
    public class ITargetCombinerImpl<ORV, O> : BaseITargetCombinerImpl<ORV, O>, ITargetCombiner<ORV, O>
        where O : IData
        where ORV : IData {

        private MPI.Intracommunicator worldcomm;
        private int tag = 347;
        private int listenFinished = 0;
        private int size = 0;
        private bool finalizeCombine = false;

        public ITargetCombinerImpl() {
            worldcomm = Mpi_comm.WorldComm;
            size = worldcomm.Size;
        }

        public override void main() {
            startThreads();
        }

        /* Recebimento de ORVs das unidades source */
        public void receiveCombineORVs() {
            while (listenFinished != (size - 1)) {
                ORV orv = worldcomm.Receive<ORV>(MPI.Unsafe.MPI_ANY_SOURCE, tag);
                if (listenFinished != (size - 1)) Combine_input_data.put(orv);
            }
            finalizeCombine = true;
        }

        private void anuncieFinishedListen() {
            while (listenFinished != (size - 1)) {
                listenFinished = listenFinished + worldcomm.Receive<int>(MPI.Unsafe.MPI_ANY_SOURCE, tag + 1);
            }
            worldcomm.Send<ORV>(default(ORV), worldcomm.Rank, tag);
        }

        /* Método da Thread que chama o CombineFunction */
        public void performCombineFunction() {
            while (!finalizeCombine) {
                Combine_function.go();
            }
        }

        /*Threads start*/
        private void startThreads() {
            /*Instancias*/
            Thread tReceive = new Thread(new ThreadStart(receiveCombineORVs));
            Thread tanuncieFinishedListen = new Thread(new ThreadStart(anuncieFinishedListen));
            Thread tperformCombine = new Thread(new ThreadStart(performCombineFunction));

            /*Starting*/
            tReceive.Start();
            tanuncieFinishedListen.Start();
            tperformCombine.Start();

            /* Joins*/
            tReceive.Join();
            tanuncieFinishedListen.Join();
            tperformCombine.Join();
        }
    }
}
