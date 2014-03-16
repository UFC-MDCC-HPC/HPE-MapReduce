using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.example.Tallier;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.Integer;

namespace br.ufc.mdcc.mapreduce.example.impl.TallierImpl { 

	public class ITallierImpl : BaseITallierImpl, ITallier
	{

		public ITallierImpl() { } 

		public override void main() 
		{ 
			int total_count = 0;
			while (!Input_values.Value.HasFinished)						
				total_count += Input_values.Value.fetch_next().Value;

			Output_value.Key = Input_values.Key;
			Output_value.Value.Value = total_count;
		}

	}

}
