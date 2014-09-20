/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.example.graph.sssp.PathFlow;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.example.graph.sssp.PathFlowApp;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
//using br.ufc.mdcc.mapreduce.example.graph.sssp.DataPath;

namespace br.ufc.mdcc.mapreduce.example.graph.sssp.impl.PathFlowAppImpl { 

	public abstract class BaseIMasterProcessImpl<PLATFORM>: Application, BaseIMasterProcess<PLATFORM>
		where PLATFORM:IPlatform{

		private IString input_data = null;
		protected IString Input_data {
			get {
				if (this.input_data == null)
					this.input_data = (IString) Services.getPort("input_data");
				return this.input_data;
			}
		}

		private IString output_data = null;
		protected IString Output_data {
			get {
				if (this.output_data == null)
					this.output_data = (IString) Services.getPort("output_data");
				return this.output_data;
			}
		}

		private IMaster<PLATFORM> path_flow = null;
		protected IMaster<PLATFORM> Path_flow {
			get {
				if (this.path_flow == null)
					this.path_flow = (IMaster<PLATFORM>) Services.getPort("path_flow");
				return this.path_flow;
			}
		}
	}
}
