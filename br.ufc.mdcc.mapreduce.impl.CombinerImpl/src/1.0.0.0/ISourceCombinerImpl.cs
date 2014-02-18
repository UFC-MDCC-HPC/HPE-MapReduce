using System;
using System.Threading;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.Combiner;

namespace br.ufc.mdcc.mapreduce.impl.CombinerImpl {
    public class ISourceCombinerImpl<ORV> : BaseISourceCombinerImpl<ORV>, ISourceCombiner<ORV>
    where ORV : IData {

        private MPI.Intracommunicator worldcomm;
        private int tag = 347;
        private int gerente = 0;

        public ISourceCombinerImpl() {
            worldcomm = Mpi_comm.WorldComm;
        }

        public override void main() {

            startThreads();
        }

        public void sendORVsToTarget() {
            while (!Source_data.HasFinished) {
                ORV orv = Source_data.fetch_next();
                worldcomm.Send<ORV>(orv, gerente, tag);
            }
            worldcomm.Send<int>(1, gerente, tag+1);
        }

        private void startThreads() {
            /*Instancias*/
            Thread tSend = new Thread(new ThreadStart(sendORVsToTarget));

            /*Starting*/
            tSend.Start();

            /* Joins*/
            tSend.Join();
        }
    }
}
