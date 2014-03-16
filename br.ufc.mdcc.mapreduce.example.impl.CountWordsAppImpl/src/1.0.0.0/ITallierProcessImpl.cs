using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.example.CountWordsApp;

namespace br.ufc.mdcc.mapreduce.example.impl.CountWordsAppImpl { 

	public class ITallierProcessImpl<PLATFORM> : BaseITallierProcessImpl<PLATFORM>, ITallierProcess<PLATFORM>
	where PLATFORM:IPlatform
	{

		public ITallierProcessImpl() { } 

		public override void main() 
		{ 
			Count_words.go();
		}

	}

}
