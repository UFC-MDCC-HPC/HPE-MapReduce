using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.example.BreakInLines;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.String;

namespace br.ufc.mdcc.mapreduce.example.impl.BreakInLinesImpl { 

	public class IBreakInLinesImpl : BaseIBreakInLinesImpl, IBreakInLines
	{

		public IBreakInLinesImpl() { } 

		public override void main() 
		{
			string s = Input_data.Value;

			string[] lines = s.Split(new char[] {'\n'});
			int line_counter = 0;
			foreach (string line in lines) 
			{
				IKVPair<IInteger,IString> line_pair = Output_data.createItem();
				line_pair.Key.Value = line_counter;
				line_pair.Value.Value = line;
				line_counter++;
			}
		}

	}

}
