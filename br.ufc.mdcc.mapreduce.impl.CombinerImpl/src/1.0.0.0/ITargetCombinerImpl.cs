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

        public ITargetCombinerImpl() {
            worldcomm = Mpi_comm.WorldComm;
        }

        public override void main() {
            startThreads();
        }

        /* Recebimento de ORVs das unidades source */
        public void receiveORVs() {
            while (true) {
                ORV orv = worldcomm.Receive<ORV>(MPI.Unsafe.MPI_ANY_SOURCE, tag);
                Combine_input_data.put(orv);
            }
        }

        /* Método da Thread que chama o CombineFunction */
        public void performCombineFunction() {
            Combine_function.go();
        }

        /*Threads start*/
        private void startThreads() {
            /*Instancias*/
            Thread tReceive = new Thread(new ThreadStart(receiveORVs));
            Thread tPerformCombineFunction = new Thread(new ThreadStart(performCombineFunction));

            /*Starting*/
            tReceive.Start();
            tPerformCombineFunction.Start();

            /* Joins*/
            tReceive.Join();
            tPerformCombineFunction.Join();
        }
    }
}
