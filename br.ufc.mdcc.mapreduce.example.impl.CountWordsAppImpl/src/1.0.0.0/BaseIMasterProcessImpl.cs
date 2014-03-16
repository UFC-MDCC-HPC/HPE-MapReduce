/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.example.CountWords;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.example.CountWordsApp;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Integer;

namespace br.ufc.mdcc.mapreduce.example.impl.CountWordsAppImpl { 

	public abstract class BaseIMasterProcessImpl<PLATFORM>: Application, BaseIMasterProcess<PLATFORM>
	where PLATFORM:IPlatform
	{

		private IString input_data = null;

		public IString Input_data {
			get {
				if (this.input_data == null)
					this.input_data = (IString) Services.getPort("input_data");
				return this.input_data;
			}
		}

		private IIterator<IKVPair<IString,IInteger>> output_data = null;

		public IIterator<IKVPair<IString,IInteger>> Output_data {
			get {
				if (this.output_data == null)
					this.output_data = (IIterator<IKVPair<IString,IInteger>>) Services.getPort("output_data");
				return this.output_data;
			}
		}

		private IMaster<PLATFORM> count_words = null;

		protected IMaster<PLATFORM> Count_words {
			get {
				if (this.count_words == null)
					this.count_words = (IMaster<PLATFORM>) Services.getPort("count_words");
				return this.count_words;
			}
		}



	}

}
