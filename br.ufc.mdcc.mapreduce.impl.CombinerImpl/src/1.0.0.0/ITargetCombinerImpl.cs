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
        private int size_reducers = 0;
        private int listenFinishedObject = 0;
		private int TAG_COMBINER_ORV = 547;
		private int TAG_COMBINER_ORV_FINISH = 548;

		public ITargetCombinerImpl() { }

		override public void initialize()
		{
			// Inicializar o comunicador MPI. 
			worldcomm = Mpi_comm.worldComm();
			size_reducers = this.UnitSize["source"];
		}

        public override void main() 
		{ 
            startThreads(); 
        }

        /* Recebimento de ORVs das unidades source */
        public void receiveCombineORVs() 
		{
            ORV orv;
            MPI.CompletedStatus status;
            while (listenFinishedObject != size_reducers) 
			{
                worldcomm.Receive<ORV>(MPI.Unsafe.MPI_ANY_SOURCE, MPI.Unsafe.MPI_ANY_TAG, out orv, out status);
				Combine_input_data.put(orv);

				if (status.Tag == TAG_COMBINER_ORV_FINISH) {
					listenFinishedObject = listenFinishedObject + 1;
				}
            }
            
        }

        /* Método da Thread que chama o CombineFunction */
        public void performCombineFunction() 
		{
             Combine_function.go();            
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
