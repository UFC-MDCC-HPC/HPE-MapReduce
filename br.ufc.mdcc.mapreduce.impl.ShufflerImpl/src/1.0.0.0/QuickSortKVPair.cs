using System;
using System.Collections.Generic;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.mapreduce.impl.ShufflerImpl {
    public static class QuickSortKVPair {
        public static int particione(List<IKVPair<IData, IData>> A, int p, int r, bool byValue=false) {
            IKVPair<IData, IData> pivo = A[r]; //int pivo = A[r];
            int i = -1;
            if (!byValue) {
                int pivoKey = ((int)(Object)pivo.Key);
                i = p - 1;
                for (int j = p; j <= r - 1; j++) {
                    if (((int)(Object)A[j].Key) <= pivoKey) {
                        i = i + 1;
                        IKVPair<IData, IData> temp = A[j];
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
                        IKVPair<IData, IData> temp = A[j];
                        A[j] = A[i];
                        A[i] = temp;
                    }
                }
            }
            A[r] = A[i + 1];
            A[i + 1] = pivo;
            return i + 1;
        }
        public static void sort(List<IKVPair<IData, IData>> A, int p, int r, bool byValue=false) {
            if (p < r) {
                int q = particione(A, p, r, byValue);
                sort(A, p, q - 1, byValue);
                sort(A, q + 1, r, byValue);
            }
        }
    }
}
