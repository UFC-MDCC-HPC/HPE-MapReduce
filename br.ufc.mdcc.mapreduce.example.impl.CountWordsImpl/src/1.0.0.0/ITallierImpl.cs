using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.example.CountWords;

namespace br.ufc.mdcc.mapreduce.example.impl.CountWordsImpl { 

public class ITallierImpl<PLATFORM> : BaseITallierImpl<PLATFORM>, ITallier<PLATFORM>
where PLATFORM:IPlatform
{

	public ITallierImpl() { } 

	public override void main() 
	{ 
			this.Count_words.go();

	}

}

}
