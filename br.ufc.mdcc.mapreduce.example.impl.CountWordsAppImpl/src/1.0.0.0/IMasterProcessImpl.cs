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

namespace br.ufc.mdcc.mapreduce.example.impl.CountWordsAppImpl { 

	public class IMasterProcessImpl<PLATFORM> : BaseIMasterProcessImpl<PLATFORM>, IMasterProcess<PLATFORM>
	where PLATFORM:IPlatform
	{

		public IMasterProcessImpl() { } 

		public override void main() 
		{			 
			((IStringInstance)Input_data.Instance).Value = readInput();
			IIteratorInstance<IKVPair<IString,IInteger>> output_data_instance = (IIteratorInstance<IKVPair<IString,IInteger>> ) Output_data.Instance;

			Count_words.go();

			while (!output_data_instance.HasFinished) 
			{
				IKVPairInstance<IString,IInteger> word = (IKVPairInstance<IString,IInteger>) output_data_instance.fetch_next();
				Console.Out.Write (((IStringInstance)word.Key).Value + ":");
				Console.Out.WriteLine (((IIntegerInstance)word.Value).Value);
			}

		}

		string readInput ()
		{
			throw new NotImplementedException ();
		}
	}

}
