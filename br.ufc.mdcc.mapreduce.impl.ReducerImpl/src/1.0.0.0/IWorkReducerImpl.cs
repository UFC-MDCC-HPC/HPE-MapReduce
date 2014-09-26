using System;
using System.Threading;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.user.ReduceFunction;
using br.ufc.mdcc.mapreduce.Reducer;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Iterator;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;

namespace br.ufc.mdcc.mapreduce.impl.ReducerImpl 
{
    public class IWorkReducerImpl<OMK, OMV, ORV, R> :
    BaseIWorkReducerImpl<OMK, OMV, ORV, R>, IReducer<OMK, OMV, ORV, R>
        where OMK : IData
        where OMV : IData
        where ORV : IData
        where R : IReduceFunction<OMK, OMV, ORV> 
	{

        public IWorkReducerImpl() { }

        public override void main() {
            /* 1. Ler pares chave (OMK) e valores (OMV) de Input.
             * 2. Para cada par, atribuir a Key e Values e chamar Reduce_function.go();
             * 3. Pegar o resultado de Reduction_function.go() de Output_reduce (ORV) 
             *    e colocar no iterator Output.
             */
            readPair_OMK_OMVs(); //startThreads();
        }

        private void readPair_OMK_OMVs() 
		{
			IIteratorInstance<IKVPair<OMK, IIterator<OMV>>> input_instance = (IIteratorInstance<IKVPair<OMK, IIterator<OMV>>>) Input.Instance;
			IIteratorInstance<ORV> output_instance = (IIteratorInstance<ORV>) Output.Instance;

			object kvpair_object;
			int count=0;
			while (input_instance.fetch_next(out kvpair_object)) 
			{
				Trace.WriteLine(WorldComm.Rank + ": REDUCER LOOP 1!" + (count++));
				IKVPairInstance<OMK, IIterator<OMV>> kvpair = (IKVPairInstance<OMK, IIterator<OMV>>) kvpair_object;
				Input_reduce.Instance = kvpair;
				Reduce_function.go();				
				output_instance.put(Output_reduce.Instance);	
            }

			output_instance.finish();

			Trace.WriteLine(WorldComm.Rank + ": FINISH REDUCER !!!");
        }

        private void startThreads() {
            /*Instancias*/
            Thread treadPairOMKOMV = new Thread(new ThreadStart(readPair_OMK_OMVs));

            /*Starting*/
            treadPairOMKOMV.Start(); 	
            /* Joins*/
            treadPairOMKOMV.Join();
        }
    }
}