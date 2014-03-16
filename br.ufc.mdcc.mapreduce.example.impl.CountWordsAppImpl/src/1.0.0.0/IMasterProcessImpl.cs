using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.example.CountWordsApp;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.common.Integer;

namespace br.ufc.mdcc.mapreduce.example.impl.CountWordsAppImpl { 

	public class IMasterProcessImpl<PLATFORM> : BaseIMasterProcessImpl<PLATFORM>, IMasterProcess<PLATFORM>
	where PLATFORM:IPlatform
	{

		public IMasterProcessImpl() { } 

		public override void main() 
		{			 
			Input_data.Value = readInput();

			Count_words.go();

			while (!Output_data.HasFinished) 
			{
				IKVPair<IString,IInteger> word = Output_data.fetch_next();
				Console.Out.Write (word.Key + ":");
				Console.Out.WriteLine (word.Value);
			}

		}

		string readInput ()
		{
			throw new NotImplementedException ();
		}
	}

}
