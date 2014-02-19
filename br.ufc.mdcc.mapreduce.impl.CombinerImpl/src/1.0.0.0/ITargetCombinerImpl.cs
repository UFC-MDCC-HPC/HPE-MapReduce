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
        private int size = 0;
        private bool finalizeCombine = false;
        private int listenFinished = 0;
        private Semaphore semCombineFunction;

        public ITargetCombinerImpl() {
            worldcomm = Mpi_comm.WorldComm;
            size = worldcomm.Size;
            semCombineFunction = new Semaphore(0, int.MaxValue);
        }

        public override void main() { 
            startThreads(); 
        }

        /* Recebimento de ORVs das unidades source */
        public void receiveCombineORVs() {
            ORV orv;
            Object o;
            while (!finalizeCombine) {
                o = worldcomm.Receive<Object>(MPI.Unsafe.MPI_ANY_SOURCE, tag);
                try { 
                    orv = (ORV) o; 
                } 
                catch {
                    finalizeCombine = true;
                    break;
                }
                Combine_input_data.put(orv);
                semCombineFunction.Release();
            }
            semCombineFunction.Release();
        }

        /* Escuta todos os an�ncios dos reducers finalizados e destrava o m�todo receiveCombineORVs */
        private void anuncieFinishedListen() {
            while (listenFinished != (size - 1)) {
                listenFinished = listenFinished + worldcomm.Receive<int>(MPI.Unsafe.MPI_ANY_SOURCE, tag + 1);
            }
            worldcomm.Send<Object>(new Object(), worldcomm.Rank, tag);
        }

        /* M�todo da Thread que chama o CombineFunction */
        public void performCombineFunction() {
            while (!finalizeCombine) {
                semCombineFunction.WaitOne();
                if (!finalizeCombine) Combine_function.go();
            }
        }

        /* Threads start */
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
