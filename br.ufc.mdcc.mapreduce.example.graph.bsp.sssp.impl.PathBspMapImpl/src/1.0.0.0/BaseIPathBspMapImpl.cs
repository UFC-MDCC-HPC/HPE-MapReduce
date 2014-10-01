/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.mapreduce.example.graph.bsp.sssp.PathBspMap;
//using br.ufc.mdcc.mapreduce.example.graph.bsp.sssp.DataPath;

namespace br.ufc.mdcc.mapreduce.example.graph.bsp.sssp.impl.PathBspMapImpl { 

	public abstract class BaseIPathBspMapImpl: Computation, BaseIPathBspMap{

		private IInteger input_key = null;
		public IInteger Input_key {
			get {
				if (this.input_key == null)
					this.input_key = (IInteger) Services.getPort("input_key");
				return this.input_key;
			}
		}

		private IString input_value = null;
		public IString Input_value {
			get {
				if (this.input_value == null)
					this.input_value = (IString) Services.getPort("input_value");
				return this.input_value;
			}
		}

		private IIterator<IKVPair<IString, IString>> output_data = null;
		public IIterator<IKVPair<IString, IString>> Output_data {
			get {
				if (this.output_data == null)
					this.output_data = (IIterator<IKVPair<IString, IString>>) Services.getPort("output_data");
				return this.output_data;
			}
		}
	}
}
