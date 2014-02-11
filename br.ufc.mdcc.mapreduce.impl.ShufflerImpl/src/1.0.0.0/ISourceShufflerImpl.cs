using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.Shuffler;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.Integer;
using System.Collections.Generic;

namespace br.ufc.mdcc.mapreduce.impl.ShufflerImpl {
    public class ISourceShufflerImpl<OMK>: BaseISourceShufflerImpl<OMK>, ISourceShuffler<OMK>
    where OMK: IData {
        private List<IKVPair<OMK, IInteger>> sourceList = new List<IKVPair<OMK, IInteger>>();
        private MPI.Intracommunicator worldcomm = null;
        private int tag = 345;
        public ISourceShufflerImpl() {
            worldcomm = Mpi_comm.worldComm();
        }

        public override void main() {
            /* 1. Ler os pares de chaves (OMK, OPK) de Source_data
             * 2. Enviar cada chave OMK para o reducer (unidade target)
             *    determinada pela chave OPK.
             */
            read();
            QuickSortListKVPair.sort(sourceList, true);
            sendOMKs();
        }
        private void read() {
            while (!Source_data.HasFinished){
                IKVPair<OMK, IInteger> kvpair = Source_data.fetch_next();
                sourceList.Add(kvpair);
            }
        }
        private void sendOMKs() {
            MPI.RequestList requestList = new MPI.RequestList();
            List<MPI.Request> requests = new List<MPI.Request>();
            int i = 0;
            int j = 0;
            while (i < sourceList.Count) {
                List<OMK> listOMK = new List<OMK>();
                IInteger opk = sourceList[i].Value;
                while (j < sourceList.Count) {
                    if (opk.Equals(sourceList[j].Value)) {
                        listOMK.Add(sourceList[j].Key);
                        j++;
                    }
                    else {
                        i = j;
                        requests.Add(worldcomm.ImmediateSend<int>(listOMK.Count, (int)(Object)opk, tag+1));
                        requests.Add(worldcomm.ImmediateSend<OMK>(listOMK.ToArray(), (int)(Object)opk, tag));
                        break; 
                    }
                }
                if (j == sourceList.Count) {
                    requests.Add(worldcomm.ImmediateSend<int>(listOMK.Count, (int)(Object)opk, tag + 1));
                    requests.Add(worldcomm.ImmediateSend<OMK>(listOMK.ToArray(), (int)(Object)opk, tag)); 
                    i = j; 
                }
            }
            foreach (MPI.Request request in requests.ToArray()) {
                requestList.Add(request);
            }
            requestList.WaitAll();
        }
        public static class QuickSortListKVPair {
            private static int particione(List<IKVPair<OMK, IInteger>> A, int p, int r, bool byValue = false) {
                IKVPair<OMK, IInteger> pivo = A[r];
                int i = -1;
                if (!byValue) {
                    int pivoKey = ((int)(Object)pivo.Key);
                    i = p - 1;
                    for (int j = p; j <= r - 1; j++) {
                        if (((int)(Object)A[j].Key) <= pivoKey) {
                            i = i + 1;
                            IKVPair<OMK, IInteger> temp = A[j];
                            A[j] = A[i];
                            A[i] = temp;
                        }
                    }
                }
                else {
                    int pivoValue = ((int)(Object)pivo.Value);
                    i = p - 1;
                    for (int j = p; j <= r - 1; j++) {
                        if (((int)(Object)A[j].Value) <= pivoValue) {
                            i = i + 1;
                            IKVPair<OMK, IInteger> temp = A[j];
                            A[j] = A[i];
                            A[i] = temp;
                        }
                    }
                }
                A[r] = A[i + 1];
                A[i + 1] = pivo;
                return i + 1;
            }
            private static void sortStart(List<IKVPair<OMK, IInteger>> A, int p, int r, bool byValue = false) {
                if (p < r) {
                    int q = particione(A, p, r, byValue);
                    sortStart(A, p, q - 1, byValue);
                    sortStart(A, q + 1, r, byValue);
                }
            }
            public static void sort(List<IKVPair<OMK, IInteger>> A, bool byValue = false) {
                int n = A.Count - 1;
                QuickSortListKVPair.sortStart(A, 0, n, byValue);
                for (int i = 0; i < A.Count; i++) {
                    System.Console.WriteLine(A[i]);
                }
            }
        }
    }
}
