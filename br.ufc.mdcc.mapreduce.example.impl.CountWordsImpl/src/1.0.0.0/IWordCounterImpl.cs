using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.example.CountWords;

namespace br.ufc.mdcc.mapreduce.example.impl.CountWordsImpl { 

	public class IWordCounterImpl<PLATFORM> : BaseIWordCounterImpl<PLATFORM>, IWordCounter<PLATFORM>
	where PLATFORM:IPlatform
	{
		public IWordCounterImpl() { } 

		public override void main() 
		{ 
			Count_words.go();
		}

	}

}
