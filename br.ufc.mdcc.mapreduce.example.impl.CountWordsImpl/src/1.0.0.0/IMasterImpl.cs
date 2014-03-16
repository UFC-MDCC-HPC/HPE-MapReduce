using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.example.CountWords;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.common.Integer;

namespace br.ufc.mdcc.mapreduce.example.impl.CountWordsImpl { 

public class IMasterImpl<PLATFORM> : BaseIMasterImpl<PLATFORM>, IMaster<PLATFORM>
where PLATFORM:IPlatform
{

	public IMasterImpl() { } 

	public override void main() 
	{ 
			Count_words.go();
	}

}

}
