using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.example.graph.sssp.PathFlowApp;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Iterator;
using System.Threading;
using System.Collections.Generic;
using System.Diagnostics;

namespace br.ufc.mdcc.mapreduce.example.graph.sssp.impl.PathFlowAppImpl { 

	public class IMasterProcessImpl<PLATFORM> : BaseIMasterProcessImpl<PLATFORM>, IMasterProcess<PLATFORM>
		where PLATFORM:IPlatform{
		public IMasterProcessImpl() { } 

		private const string PATH = "/home/cenez/path.txt";
		public override void main() 
		{ 
			IStringInstance input = (IStringInstance)Input_data.Instance;

			string setE = readInput (PATH);

			input.Value =  setE;

			Console.WriteLine (Rank + ": SSSP APP - GO START !!!");
			Path_flow.go ();
			Console.WriteLine (Rank + ": SSSP APP - GO END JOIN !!!");

			IStringInstance output = (IStringInstance) Output_data.Instance;
			Console.WriteLine (Rank + " END SSSP (output = " + output.Value + ")");
		}

		string readInput(string PATH)
		{
			return System.IO.File.ReadAllText(PATH);
		}
}
}