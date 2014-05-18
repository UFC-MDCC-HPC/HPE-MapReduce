using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.example.CountWordsApp;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.Iterator;
using System.Collections.Generic;

namespace br.ufc.mdcc.mapreduce.example.impl.CountWordsAppImpl { 

	public class IMasterProcessImpl<PLATFORM> : BaseIMasterProcessImpl<PLATFORM>, IMasterProcess<PLATFORM>
	where PLATFORM:IPlatform
	{

		public IMasterProcessImpl() { } 

		public override void main() 
		{			 
			
			((IStringInstance)Input_data.Instance).Value = readInput();
			IIteratorInstance<IKVPair<IString,IInteger>> output_data_instance = (IIteratorInstance<IKVPair<IString,IInteger>> ) Output_data.Instance;

			Console.WriteLine ("APP BEFORE GO !!!");
			Count_words.go();
			Console.WriteLine ("APP AFTER GO !!!");

			SortedDictionary<int,IList<string>> result_pairs = new SortedDictionary<int,IList<string>>();

			int count=0;
			object word_object;
			while (output_data_instance.fetch_next(out word_object)) 
			{
				IKVPairInstance<IString,IInteger> word = (IKVPairInstance<IString,IInteger>) word_object;
				int value = ((IIntegerInstance)word.Value).Value;
				string key = ((IStringInstance)word.Key).Value;
				IList<string> list_words;
				if (!result_pairs.TryGetValue(value, out list_words))
				{
					list_words = new List<string>();
					result_pairs.Add(value, list_words);
				}
				list_words.Add(key);
			}

			
			foreach (int count_word in result_pairs.Keys)
			{
				foreach (string word in result_pairs[count_word])
				{
			    	Console.WriteLine("RESULT - {0}: {1}", count_word, word);
				}
			}

			//	Console.WriteLine ("RESULT - " + ((IStringInstance)word.Key).Value + ":" + ((IIntegerInstance)word.Value).Value + " count=" + (count++));

			Console.WriteLine ("APP FINISH !!! " + count);

		}

		string readInput ()
		{
			return System.IO.File.ReadAllText("/home/heron/contents.txt");
			
		}
	}

}
