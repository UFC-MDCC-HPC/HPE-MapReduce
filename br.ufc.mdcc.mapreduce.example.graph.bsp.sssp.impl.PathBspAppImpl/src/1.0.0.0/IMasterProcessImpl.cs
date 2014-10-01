using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.example.graph.bsp.sssp.PathBspApp;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Iterator;
using System.Threading;
using System.Collections.Generic;
using System.Diagnostics;

namespace br.ufc.mdcc.mapreduce.example.graph.bsp.sssp.impl.PathBspAppImpl { 

	public class IMasterProcessImpl<PLATFORM> : BaseIMasterProcessImpl<PLATFORM>, IMasterProcess<PLATFORM>
		where PLATFORM:IPlatform{
		public IMasterProcessImpl() { } 

		private const string PATH = "/home/cenez/path.txt";
		public override void main() 
		{ 
			IStringInstance input = (IStringInstance)Input_data.Instance;

			string setE = readInput (PATH);

			input.Value =  setE;

			////Console.WriteLine (Rank + ": SSSP APP - GO START !!!");
			long t0 = (long)(DateTime.UtcNow - (new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc))).TotalMilliseconds; 
			Path_bsp.go ();
			long t1 = (long)(DateTime.UtcNow - (new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc))).TotalMilliseconds;
			////Console.WriteLine (Rank + ": SSSP APP - GO END JOIN !!!");

			IStringInstance output = (IStringInstance) Output_data.Instance;
			////Console.WriteLine (Rank + " END SSSP (output = " + output.Value + ")");
			clearWriteFile ("./outPathBspApp",output.Value+System.Environment.NewLine+"TIME: "+(t1 - t0)+"ms");
		}
		public static void clearWriteFile(string PATH, string saida)
		{
			using (System.IO.StreamWriter file = new System.IO.StreamWriter(@PATH, false)){
				file.WriteLine(saida);
			}
		}

		string readInput(string PATH)
		{
			return System.IO.File.ReadAllText(PATH);
		}
}
}