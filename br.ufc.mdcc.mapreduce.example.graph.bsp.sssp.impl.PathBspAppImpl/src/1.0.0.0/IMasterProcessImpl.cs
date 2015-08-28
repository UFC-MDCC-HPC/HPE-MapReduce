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

		private const string PATH = "/tmp/path.txt";
		public override void main() 
		{ 
			IStringInstance input = (IStringInstance)Input_data.Instance;

			string setE = readInput (PATH);

			input.Value =  setE;

			long t0 = (long)(DateTime.UtcNow - (new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc))).TotalMilliseconds; 
			Path_bsp.go ();
			long t1 = (long)(DateTime.UtcNow - (new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc))).TotalMilliseconds;

			IStringInstance output = (IStringInstance) Output_data.Instance;//output.Value
			//clearWriteFile ("./outPathBspApp-"+getDateTime(),""+(t1 - t0));
			clearWriteFile ("./outPathBspApp", "TIME: " + (t1 - t0) + " ms."+System.Environment.NewLine+output.Value);
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
		string getDateTime()
		{
			string dia = DateTime.Now.Day.ToString();
			string mes = DateTime.Now.Month.ToString();
			string ano = DateTime.Now.Year.ToString();

			string hours = ""+((DateTime.Now - (new DateTime (1970, 1, 1, 0, 0, 0, DateTimeKind.Local))).Hours);
			string minutes = ""+((DateTime.Now - (new DateTime (1970, 1, 1, 0, 0, 0, DateTimeKind.Local))).Minutes);
			string seconds = ""+((DateTime.Now - (new DateTime (1970, 1, 1, 0, 0, 0, DateTimeKind.Local))).Seconds);
			return (dia+"-"+mes+"-"+ano+"."+hours+"."+minutes+"."+seconds); 
		}
}
}
