using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.example.graph.bsp.sssp.PathBsp;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.common.Integer;
using System.Collections.Generic;
using System.Diagnostics;

namespace br.ufc.mdcc.mapreduce.example.graph.bsp.sssp.impl.PathBspImpl { 

	public class IMasterImpl<PLATFORM> : BaseIMasterImpl<PLATFORM>, IMaster<PLATFORM>
	where PLATFORM:IPlatform
	{
		public override void main() 
		{ 
			string[] string_iteracoes = readInput ("/home/hpe/iteracoes").Split(new char[] {System.Environment.NewLine[0]});
			int iteracoes = int.Parse (string_iteracoes [0]);

			int done = 0;
			IStringInstance input_data_instance = (IStringInstance) Input_data.Instance;
			IStringInstance output_data_instance = (IStringInstance) Output_data.Instance;
			IIntegerInstance termination_flag = (IIntegerInstance) Termination_flag.Instance;

			string setE = input_data_instance.Value;

			string setV = "1 c 0" + System.Environment.NewLine;

			string setVsetE = setV + setE;

			IDictionary<int,int> vertices = new Dictionary<int,int>();
			foreach (string edge in setE.Split(System.Environment.NewLine.ToCharArray())) {
				if (edge.Length > 0) {
					int vertex = edge [0];
					if (!vertices.ContainsKey (vertex)) {
						setV += edge [0] + " d " + int.MaxValue + System.Environment.NewLine;
						vertices.Add (vertex, vertex);
					}
				}
			}

			input_data_instance.Value = setV + System.Environment.NewLine + setE;

			int count = 0;
			while (count++< iteracoes)//done == 0) 
			{
				////////Console.WriteLine (Rank + ": --- BEGIN ITERATION PATH_FLOW.GO ! - " + (++count)  + System.Environment.NewLine + setV);
				////////Console.WriteLine (Rank + ": iteration = " + count);
				long t0 = (long)(DateTime.UtcNow - (new DateTime (1970, 1, 1, 0, 0, 0, DateTimeKind.Utc))).TotalMilliseconds;
				this.Path_bsp.go ();
				long t1 = (long)(DateTime.UtcNow - (new DateTime (1970, 1, 1, 0, 0, 0, DateTimeKind.Utc))).TotalMilliseconds;
				writeFile ("./outPathBspApp-"+Rank, "" + (t1 - t0));// + getDateTime (), "" + (t1 - t0));
				Console.WriteLine ("Time: "+(t1 - t0)+" ms");

				//writeFile ("./outPathBspApp-IT"+count, output_data_instance.Value);// + getDateTime (), "" + (t1 - t0));

				//setV = output_data_instance.Value;
				////////Trace.WriteLine (Rank + ": --- setV = " + setV);

				//done = setV.EndsWith ("True") ? 1 : 0;
				//termination_flag.Value = done;
				//Set_termination_flag.go ();

				//setV = setV.Remove (setV.IndexOf (done == 1 ? "True" : "False") - 2);

				////////Trace.WriteLine (Rank + ": --- END ITERATION PATH_FLOW.GO ! - " + count);

				input_data_instance.Value = setVsetE;//setV;
			}
			////////Console.WriteLine (Rank + ": --- FINISH PATH_FLOW.GO !");
		}
		string readInput(string PATH)
		{
			return System.IO.File.ReadAllText(PATH);
		}
		public static void writeFile(string PATH, string saida)
		{
			using (System.IO.StreamWriter file = new System.IO.StreamWriter(@PATH, true)){
				file.WriteLine(saida);
			}
		}

	}

}
