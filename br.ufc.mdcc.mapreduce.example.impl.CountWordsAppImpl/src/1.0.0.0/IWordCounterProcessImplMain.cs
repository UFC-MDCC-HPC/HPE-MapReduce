using DGAC;
using br.ufc.mdcc.common.Platform;

namespace br.ufc.mdcc.mapreduce.example.impl.CountWordsAppImpl { 

	public class IWordCounterProcessImplMain {

		static void Main(string [] args) {

			IWordCounterProcessImpl word_counter_process = new IWordCounterProcessImpl();

			BackEnd.DGACInit("0024000004800000940000000602000000240000525341310004000011000000651da64daaeb7fc2770237a63093ef2e295e6d26e5b9c7e4c8210034f415c0d33ebae46d832c9e0ad1b04e61e779e8499ba5c6843d66629bb2315e21a3bc1f14b1ad1002d942bb1c47a778ee7b7559cd9bf30c15379cf4c6f529d0811eeb5b09589376d0f705a67e87d18a722e4355a5b1569cd16df7e59a1f1cd6fe2a973cdb","word_counter_process",word_counter_process,args);
			word_counter_process.createSlices();
			word_counter_process.compute();
			BackEnd.DGACFinalize();

		}

	}

}
