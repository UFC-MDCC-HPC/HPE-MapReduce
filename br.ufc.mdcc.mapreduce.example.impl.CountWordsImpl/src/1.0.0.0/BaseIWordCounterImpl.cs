/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.MapReduce;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.example.CountWords;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.mapreduce.user.PartitionFunction;
using br.ufc.mdcc.mapreduce.example.WordCounter;

namespace br.ufc.mdcc.mapreduce.example.impl.CountWordsImpl { 

public abstract class BaseIWordCounterImpl<PLATFORM>: Computation, BaseIWordCounter<PLATFORM>
where PLATFORM:IPlatform
{

	private IMapWorker<IInteger, IString, IString, IInteger, IPartitionFunction<IString>, IWordCounter, PLATFORM> count_words = null;

	protected IMapWorker<IInteger, IString, IString, IInteger, IPartitionFunction<IString>, IWordCounter, PLATFORM> Count_words {
	get {
		if (this.count_words == null)
				this.count_words = (IMapWorker<IInteger, IString, IString, IInteger, IPartitionFunction<IString>, IWordCounter, PLATFORM>) Services.getPort("count_words");
		return this.count_words;
	}

}



}

}
