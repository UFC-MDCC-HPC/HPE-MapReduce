using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.example.BreakInLines;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.common.Iterator;
using System.Diagnostics;

namespace br.ufc.mdcc.mapreduce.example.impl.BreakInLinesImpl { 

	public class IBreakInLinesImpl : BaseIBreakInLinesImpl, IBreakInLines
	{
		public override void main() 
		{
			Trace.WriteLine(WorldComm.Rank + ": STARTING BREAK IN LINE  (SPLIT FUNCTION)");
			IStringInstance input_data_instance =  (IStringInstance) Input_data.Instance;
			IIteratorInstance<IKVPair<IInteger,IString>> output_data_instance = (IIteratorInstance<IKVPair<IInteger,IString>>) Output_data.Instance;

			string s = input_data_instance.Value;

			string[] lines = s.Split(new char[] {System.Environment.NewLine[0]});
			int line_counter = 0;
			foreach (string line in lines) 
			{
				if (!line.Trim().Equals ("")) {
					Trace.WriteLine(WorldComm.Rank + ": LINE = " + line);
					IKVPairInstance<IInteger,IString> line_pair = (IKVPairInstance<IInteger,IString>)Output_data.createItem ();
					((IIntegerInstance)line_pair.Key).Value = line_counter++;
					((IStringInstance)line_pair.Value).Value = line;
					output_data_instance.put (line_pair);
				}
			}

			Trace.WriteLine(WorldComm.Rank + ": FINISH BREAK IN LINES #1 !!! " + output_data_instance.GetHashCode());
			output_data_instance.finish();
			Trace.WriteLine(WorldComm.Rank + ": FINISH BREAK IN LINES #2 !!!");
		}

	}

}
