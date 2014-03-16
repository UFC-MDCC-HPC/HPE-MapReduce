using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.example.CountWordsApp;

namespace br.ufc.mdcc.mapreduce.example.impl.CountWordsAppImpl { 

	public class IWordCounterProcessImpl<PLATFORM> : BaseIWordCounterProcessImpl<PLATFORM>, IWordCounterProcess<PLATFORM>
	where PLATFORM:IPlatform
	{

		public IWordCounterProcessImpl() { } 

		public override void main() 
		{ 
			Count_words.go();
		}

	}

}
