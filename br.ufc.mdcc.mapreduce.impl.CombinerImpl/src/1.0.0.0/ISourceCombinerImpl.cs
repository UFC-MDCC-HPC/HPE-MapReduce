using System;
using System.Threading;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.Combiner;
using br.ufc.mdcc.common.Iterator;

namespace br.ufc.mdcc.mapreduce.impl.CombinerImpl {
    public class ISourceCombinerImpl<ORV> : BaseISourceCombinerImpl<ORV>, ISourceCombiner<ORV>
    where ORV : IData 
{
        private MPI.Intracommunicator comm;
		private int TAG_COMBINER_ORV = 547;
		private int TAG_COMBINER_ORV_FINISH = 548;
        private int root = 0;

		public ISourceCombinerImpl() { }

		override public void initialize()
		{
			// Inicializar o comunicador MPI. 
			comm = this.Communicator;
		}


		public override void main() 
		{
            startThreads();
        }

		private void startThreads() 
		{
			/* Instancias */
			Thread tSend = new Thread(new ThreadStart(sendORVsToTarget));

			/* Starting */
			tSend.Start();

			/* Joins */
			tSend.Join();
		}

        public void sendORVsToTarget() 
		{
			IIteratorInstance<ORV> source_data_instance = (IIteratorInstance<ORV>) Source_data.Instance;

			root = this.UnitRanks["target"][0];

			object orv,last_orv=null;
			
			Console.WriteLine(WorldComm.Rank + ": START COMBINER SOURCE !!!");

			while (source_data_instance.fetch_next(out orv)) 
			{
				last_orv = orv;
				Console.WriteLine(WorldComm.Rank + ": BEGIN SEND COMBINER SOURCE to " + root);
				comm.Send<object>(orv, root, TAG_COMBINER_ORV);
				Console.WriteLine(WorldComm.Rank + ": END SEND COMBINER SOURCE to " + root);
			}

			Console.WriteLine(WorldComm.Rank + ": BEGIN SEND FINISH COMBINER SOURCE to " + root);
			comm.Send<object>(last_orv, root, TAG_COMBINER_ORV_FINISH);
			Console.WriteLine(WorldComm.Rank + ": END SEND FINISH COMBINER SOURCE to " + root);

			Console.WriteLine(WorldComm.Rank + ": FINISH COMBINER SOURCE !!!");
        }

    }
}
