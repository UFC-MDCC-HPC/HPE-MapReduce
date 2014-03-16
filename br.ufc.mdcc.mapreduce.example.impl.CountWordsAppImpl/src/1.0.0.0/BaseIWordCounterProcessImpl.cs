/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.example.CountWords;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.example.CountWordsApp;

namespace br.ufc.mdcc.mapreduce.example.impl.CountWordsAppImpl { 

public abstract class BaseIWordCounterProcessImpl<PLATFORM>: Application, BaseIWordCounterProcess<PLATFORM>
where PLATFORM:IPlatform
{

private IWordCounter<PLATFORM> count_words = null;

protected IWordCounter<PLATFORM> Count_words {
	get {
		if (this.count_words == null)
			this.count_words = (IWordCounter<PLATFORM>) Services.getPort("count_words");
		return this.count_words;
	}
}



}

}
