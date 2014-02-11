using System;
using System.Threading;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.Shuffler;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.impl.IteratorImpl;
using br.ufc.mdcc.common.Integer;
using System.Collections.Generic;

namespace br.ufc.mdcc.mapreduce.impl.ShufflerImpl {
    public class ISourceShufflerImpl<OMK>: BaseISourceShufflerImpl<OMK>, ISourceShuffler<OMK>
    where OMK: IData {

        private MPI.Intracommunicator worldcomm;
        private int tag = 345;
        //HashSet<int> opks;
        
        public ISourceShufflerImpl() {
            worldcomm = Mpi_comm.worldComm();
            //opks = new HashSet<int>();
        }

        public override void main() {
            /* 1. Ler os pares de chaves (OMK, OPK) de Source_data
             * 2. Enviar cada chave OMK para o reducer (unidade target)
             *    determinada pela chave OPK.
             */
            Thread tRead = new Thread(new ThreadStart(readSend));
            tRead.Start();
            tRead.Join();
        }
        private void readSend() {
            //MPI.RequestList requestList = new MPI.RequestList();
            //List<MPI.Request> requests = new List<MPI.Request>();
            //bool finish = Source_data.HasFinished;
            while (!Source_data.HasFinished) {
                IKVPair<OMK, IInteger> kvpair = Source_data.fetch_next();
                OMK omk = kvpair.Key;
                int opk = (int) (Object) kvpair.Value;
                worldcomm.Send<OMK>(omk, opk, tag);
                //opks.Add(opk);
                //finish = Source_data.HasFinished;
                /*
                //if (finish) {
                //    foreach(int i in opks) requests.Add(worldcomm.ImmediateSend<OMK>(null, i, tag));
                //    foreach (MPI.Request request in requests.ToArray()) requestList.Add(request);
                //    requestList.WaitAll();
                //}
                 **/
            }
            //opks = new HashSet<int>();
        }
    }
}
