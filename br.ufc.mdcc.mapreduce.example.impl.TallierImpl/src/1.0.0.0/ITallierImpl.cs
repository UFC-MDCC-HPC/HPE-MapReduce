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
			IKVPairInstance<IString,IIterator<IInteger>> input_values_instance = (IKVPairInstance<IString,IIterator<IInteger>>) Input_values.Instance;
			IIteratorInstance<IInteger> counts_iterator = (IIteratorInstance<IInteger>) input_values_instance.Value;

			int total_count = 0;
			while (!counts_iterator.HasFinished)						
				total_count += ((IIntegerInstance) counts_iterator.fetch_next()).Value;

			IKVPairInstance<IString,IInteger> output_value_instance = (IKVPairInstance<IString,IInteger>) Output_value.Instance;
			                                                          			
			((IStringInstance)output_value_instance.Key).Value = ((IStringInstance)input_values_instance.Key).Value;
			((IIntegerInstance)output_value_instance.Value).Value = total_count;
		}

	}

}
