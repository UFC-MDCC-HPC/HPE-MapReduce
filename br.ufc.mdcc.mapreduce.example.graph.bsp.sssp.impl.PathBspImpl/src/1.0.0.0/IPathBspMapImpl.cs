using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.example.graph.bsp.sssp.PathBsp;
using br.ufc.mdcc.common.Integer;
using System.Diagnostics;

namespace br.ufc.mdcc.mapreduce.example.graph.bsp.sssp.impl.PathBspImpl { 

	public class IPathBspMapImpl<PLATFORM> : BaseIPathBspMapImpl<PLATFORM>, IPathBspMap<PLATFORM>
	where PLATFORM:IPlatform
	{

		public override void main() 
		{ 
			string[] string_iteracoes = readInput ("/home/hpe/iteracoes").Split(new char[] {System.Environment.NewLine[0]});
			int iteracoes = int.Parse (string_iteracoes [0]);

			int done = 0;
			int count = 0;

			while (count++< iteracoes)//(done == 0) 
			{
				this.Path_bsp.go ();
				//this.Set_termination_flag.go ();
				//IIntegerInstance termination_flag = (IIntegerInstance) Termination_flag.Instance;
				//done = termination_flag.Value;

				////////Trace.WriteLine (Rank + "AFTER PATH ROW MAP LOOP " + done + " --- " + Termination_flag.Instance.GetHashCode());
			}
		}
		string readInput(string PATH)
		{
			return System.IO.File.ReadAllText(PATH);
		}

	}

}
