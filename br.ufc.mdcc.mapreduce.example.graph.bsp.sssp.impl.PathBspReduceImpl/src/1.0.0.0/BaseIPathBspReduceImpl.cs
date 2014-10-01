/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.mapreduce.example.graph.bsp.sssp.PathBspReduce;
//using br.ufc.mdcc.mapreduce.example.graph.bsp.sssp.DataPath;

namespace br.ufc.mdcc.mapreduce.example.graph.bsp.sssp.impl.PathBspReduceImpl { 

	public abstract class BaseIPathBspReduceImpl: Computation, BaseIPathBspReduce{

		private IKVPair<IString, IIterator<IString>> input_values = null;
		public IKVPair<IString, IIterator<IString>> Input_values {
			get {
				if (this.input_values == null)
					this.input_values = (IKVPair<IString, IIterator<IString>>) Services.getPort("input_values");
				return this.input_values;
			}
		}

		private IKVPair<IString, IString> output_value = null;
		public IKVPair<IString, IString> Output_value {
			get {
				if (this.output_value == null)
					this.output_value = (IKVPair<IString, IString>) Services.getPort("output_value");
				return this.output_value;
			}
		}
	}
}
