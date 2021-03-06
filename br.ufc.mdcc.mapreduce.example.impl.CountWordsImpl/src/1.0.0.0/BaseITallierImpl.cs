/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.MapReduce;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.example.CountWords;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.mapreduce.example.Tallier;

namespace br.ufc.mdcc.mapreduce.example.impl.CountWordsImpl { 

public abstract class BaseITallierImpl<PLATFORM>: Computation, BaseITallier<PLATFORM>
where PLATFORM:IPlatform
{

	private IReduceWorker<IString, IInteger, IKVPair<IString,IInteger>, ITallier, PLATFORM> count_words = null;

	protected IReduceWorker<IString, IInteger, IKVPair<IString,IInteger>, ITallier, PLATFORM> Count_words {
	get {
		if (this.count_words == null)
					this.count_words = (IReduceWorker<IString, IInteger, IKVPair<IString,IInteger>, ITallier, PLATFORM>) Services.getPort("count_words");
		return this.count_words;
	}

}



}

}
