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
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.mapreduce.example.graph.bsp.sssp.PathBspReduce;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;

namespace br.ufc.mdcc.mapreduce.impl.ReducerBspImpl 
{
    public class IWorkReducerBspImpl<OMK, OMV, ORV, R> :
    BaseIWorkReducerBspImpl<OMK, OMV, ORV, R>, IReducer<OMK, OMV, ORV, R>
        where OMK : IString
		where OMV : IString
		where ORV : IKVPair<OMK, OMV>
		where R : IReduceFunction<OMK, OMV, ORV>//IPathBspReduce
	{
		private MPI.RequestList request = new MPI.RequestList ();
		private int active = 0;

        public IWorkReducerBspImpl() { }

        public override void main() {
			/* 1. Ler pares chave (OMK) e valores (OMV) de Input.
             * 2. Para cada par, atribuir a Key e Values e chamar Reduce_function.go();
             * 3. Pegar o resultado de Reduction_function.go() de Output_reduce (ORV) 
             *    e colocar no iterator Output.
             */
			IIteratorInstance<IKVPair<OMK, IIterator<OMV>>> input_instance = (IIteratorInstance<IKVPair<OMK, IIterator<OMV>>>) Input.Instance;
			IIteratorInstance<ORV> output_instance = (IIteratorInstance<ORV>) Output.Instance;
			
			//long t0 = (long)(DateTime.UtcNow - (new DateTime (1970, 1, 1, 0, 0, 0, DateTimeKind.Utc))).TotalMilliseconds;

			object kvpair_object;
			while (input_instance.fetch_next(out kvpair_object)) {
				IKVPairInstance<OMK, IIterator<OMV>> kvpair = (IKVPairInstance<OMK, IIterator<OMV>>) kvpair_object;
				Input_reduce.Instance = kvpair;
				Reduce_function.go ();
				active++;
				active = active - Reduce_function.Active;
            }
			string candidates_buffer = sincronize ();

			while (active>0) {
				active = 0;
				string[] lines = candidates_buffer.Split(new char[] {System.Environment.NewLine[0]});
				foreach (string line in lines) {
					if (!line.Trim().Equals ("")) {
						string[] values = line.Split (' ');
						Reduce_function.step (int.Parse(values[0]), double.Parse(values[1]));
						active++;
						active = active - Reduce_function.Active;
					}
				}
				candidates_buffer = sincronize ();
			}
			Reduce_function.apply ();
			output_instance.put(Output_reduce.Instance);

			output_instance.finish ();

			//long t1 = (long)(DateTime.UtcNow - (new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc))).TotalMilliseconds; 
			//writeFile ("./logTIME-REDUCE", "TIME: " + (t1 - t0) + " ms."+System.Environment.NewLine+"BSP");
        }
        
		public string sincronize()
		{
			string candidates_buffer = "";
			
			for (int i = 0; i < this.Communicator.Size; i++) 
			{
				if (i != this.Communicator.Rank) 
				{
					request.Add (this.Communicator.ImmediateSend<string> (Reduce_function.CandidatesBuffer [i], i, 0));
					Reduce_function.CandidatesBuffer [i] = "";
				}
			}
			
			for (int i = 0; i < this.Communicator.Size; i++) 
			{
				if (i != this.Communicator.Rank)
					Reduce_function.CandidatesBuffer[this.Communicator.Rank] = 
						Reduce_function.CandidatesBuffer[this.Communicator.Rank] + this.Communicator.Receive<string> (i, 0);
			}
			
			request.WaitAll ();
			candidates_buffer = Reduce_function.CandidatesBuffer[this.Communicator.Rank];
			active = this.Communicator.Allreduce<int> (active, MPI.Operation<int>.Max);
			Reduce_function.clearCandidatesBuffer ();
			
			return candidates_buffer;
		}
<<<<<<< HEAD
		
		public static void clearWriteFile(string PATH, string saida){
			using (System.IO.StreamWriter file = new System.IO.StreamWriter(@PATH, false)){
				file.WriteLine(saida);
			}
		}
=======
//		public static void writeFile(string PATH, string saida){
//			using (System.IO.StreamWriter file = new System.IO.StreamWriter(@PATH, false)){
//				file.WriteLine(saida);
//			}
//		}
>>>>>>> f9b138758bf27f697181bf0b58c94783eced21af
    }
}