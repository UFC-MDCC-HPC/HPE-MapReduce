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
        private int size_reducers = 0;
        private bool finalize = false;
        private int listenFinishedObject = 0;
        private Semaphore semCombineFunction;

        public ITargetCombinerImpl() {
            worldcomm = Mpi_comm.WorldComm;
            size_reducers = this.UnitSize["source"];
            semCombineFunction = new Semaphore(0, int.MaxValue);
        }

        public override void main() { 
            startThreads(); 
        }

        /* Recebimento de ORVs das unidades source */
        public void receiveCombineORVs() {
            ORV orv = default(ORV);
            Object o;
            while (listenFinishedObject != size_reducers) {
                bool put = true;
                o = worldcomm.Receive<Object>(MPI.Unsafe.MPI_ANY_SOURCE, tag);
                try { 
                    orv = (ORV) o; 
                } 
                catch {
                    listenFinishedObject = listenFinishedObject + 1;
                    put = false;
                }
                if (put) {
                    Combine_input_data.put(orv);
                    semCombineFunction.Release();
                }
            }
            finalize = true;
            semCombineFunction.Release();
        }

        /* Método da Thread que chama o CombineFunction */
        public void performCombineFunction() {
            while (!finalize) {
                semCombineFunction.WaitOne();
                if (!finalize) Combine_function.go();
            }
        }

        /* Threads start */
        private void startThreads() {
            /*Instancias*/
            Thread tReceive = new Thread(new ThreadStart(receiveCombineORVs));
            Thread tperformCombine = new Thread(new ThreadStart(performCombineFunction));

            /*Starting*/
            tReceive.Start();
            tperformCombine.Start();

            /* Joins*/
            tReceive.Join();
            tperformCombine.Join();
        }
    }
}
