using System;
using System.Threading;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.Combiner;
using br.ufc.mdcc.mapreduce.user.CombineFunction;
using br.ufc.mdcc.common.Iterator;
using System.Diagnostics;

namespace br.ufc.mdcc.mapreduce.impl.CombinerImpl {
	public class ITargetCombinerImpl<ORV, O, Cf> : BaseITargetCombinerImpl<ORV, O, Cf>, ITargetCombiner<ORV, O, Cf>
        where O : IData
        where ORV : IData 
		where Cf: ICombineFunction<ORV, O> 
	{

        private MPI.Intracommunicator comm;
        private int size_reducers = 0;
		private int[] rank_reducers = null;
 		private int TAG_COMBINER_ORV = 547;
		private int TAG_COMBINER_ORV_FINISH = 548;

		public ITargetCombinerImpl() { }

		override public void after_initialize()
		{
			// Inicializar o comunicador MPI. 
			comm = this.Communicator;
			size_reducers = this.UnitSize["source"];
			rank_reducers = this.UnitRanks["source"];
		}

        public override void main() 
		{ 
            startThreads(); 
        }

		private IIteratorInstance<ORV> combine_input_data_instance;

        /* Recebimento de ORVs das unidades source */
		public void receiveCombineORVs() 
		{
			int listenFinishedObject = 0;
			Trace.WriteLine(WorldComm.Rank + ": START COMBINER TARGET !!!");

			object orv;
            MPI.CompletedStatus status;
            while (listenFinishedObject < size_reducers) 
			{
				Trace.WriteLine(WorldComm.Rank + ": BEGIN RECEIVE COMBINER TARGET to ");
				comm.Receive<object>(MPI.Unsafe.MPI_ANY_SOURCE, MPI.Unsafe.MPI_ANY_TAG, out orv, out status);
				Trace.WriteLine(WorldComm.Rank + ": END RECEIVE COMBINER TARGET to " + (status.Source));

				if (status.Tag == TAG_COMBINER_ORV_FINISH) 
					listenFinishedObject = listenFinishedObject + 1;
				else
					combine_input_data_instance.put(orv);
            }

			combine_input_data_instance.finish();
            
			Trace.WriteLine(WorldComm.Rank + ": FINISH COMBINER TARGET !!!");
        }

        /* M�todo da Thread que chama o CombineFunction */
        public void performCombineFunction() 
		{
             Combine_function.go();            
        }

        /* Threads start */
        private void startThreads() 
		{
			combine_input_data_instance = (IIteratorInstance<ORV>) Combine_input_data.Instance;

			/*Instancias*/
            Thread tReceive = new Thread(new ThreadStart(receiveCombineORVs));
            Thread tperformCombine = new Thread(new ThreadStart(performCombineFunction));

            /*Starting*/
            tReceive.Start();
            tperformCombine.Start();

            /* Joins*/
			Trace.WriteLine(WorldComm.Rank + ": FINISH COMBINER THREADS #0 !!!");
            tReceive.Join();
			Trace.WriteLine(WorldComm.Rank + ": FINISH COMBINER THREADS #1 !!!");
            tperformCombine.Join();
			Trace.WriteLine(WorldComm.Rank + ": FINISH COMBINER THREADS #2 !!!");

      }
    }
}
