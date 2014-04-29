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
        private MPI.Intracommunicator worldcomm;
		private int TAG_COMBINER_ORV = 547;
		private int TAG_COMBINER_ORV_FINISH = 548;
        private int gerente = 0;

		public ISourceCombinerImpl() { }

		override public void initialize()
		{
			// Inicializar o comunicador MPI. 
			worldcomm = Mpi_comm.worldComm();
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

			while (!source_data_instance.HasFinished) 
			{
				object orv = source_data_instance.fetch_next();
				if (source_data_instance.HasFinished) 
					worldcomm.Send<object>(orv, gerente, TAG_COMBINER_ORV);
				else
					worldcomm.Send<object>(orv, gerente, TAG_COMBINER_ORV_FINISH);
            }            
        }

    }
}
