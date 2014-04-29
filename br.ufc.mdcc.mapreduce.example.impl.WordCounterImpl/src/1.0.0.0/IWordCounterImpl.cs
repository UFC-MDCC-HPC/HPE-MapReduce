using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.example.WordCounter;
using System.Collections.Generic;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.Iterator;

namespace br.ufc.mdcc.mapreduce.example.impl.WordCounterImpl { 

	public class IWordCounterImpl : BaseIWordCounterImpl, IWordCounter
	{

		public IWordCounterImpl() { } 

		public override void main() 
		{ 
			IStringInstance input_value_instance = (IStringInstance) Input_value.Instance;
			IIteratorInstance<IKVPair<IString,IInteger>> output_value_instance = (IIteratorInstance<IKVPair<IString,IInteger>>) Output_data.Instance;

			string input_string = input_value_instance.Value;
			string[] words = input_string.Split(new char[] {' '});

			IDictionary<string, int> index = new Dictionary<string,int>();
			foreach (string word in words) 
			{
				int counter;
				if (index.TryGetValue(word, out counter))
					index.Remove(word);
				else 
					counter = 0;
				index.Add(word, counter+1);
			}

			foreach (KeyValuePair<string,int> occurrences in index)
			{
				IKVPairInstance<IString,IInteger> item = (IKVPairInstance<IString,IInteger>) Output_data.createItem();
				((IStringInstance)item.Key).Value = occurrences.Key;
				((IIntegerInstance)item.Value).Value = occurrences.Value;
				output_value_instance.put(item);
			}
		}

	}

}
