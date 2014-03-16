using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.example.WordCounter;
using System.Collections.Generic;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.common.Integer;

namespace br.ufc.mdcc.mapreduce.example.impl.WordCounterImpl { 

	public class IWordCounterImpl : BaseIWordCounterImpl, IWordCounter
	{

		public IWordCounterImpl() { } 

		public override void main() 
		{ 
			string input_string = Input_value.Value;
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
				IKVPair<IString,IInteger> item = Output_data.createItem();
				item.Key.Value = occurrences.Key;
				item.Value.Value = occurrences.Value;
			}
		}

	}

}
