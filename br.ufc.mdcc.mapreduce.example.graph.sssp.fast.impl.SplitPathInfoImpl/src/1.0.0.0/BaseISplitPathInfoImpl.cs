/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.mapreduce.example.graph.sssp.fast.PathInfo;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.mapreduce.example.graph.sssp.fast.SplitPathInfo;
using br.ufc.mdcc.mapreduce.user.SplitFunction;

namespace br.ufc.mdcc.mapreduce.example.graph.sssp.fast.impl.SplitPathInfoImpl { 

public abstract class BaseISplitPathInfoImpl: Computation, BaseISplitPathInfo
{

		private IIterator<IPathInfo> input_data = null;

public IIterator<IPathInfo> Input_data {
	get {
		if (this.input_data == null)
					this.input_data = (IIterator<IPathInfo>) Services.getPort("input_data");
		return this.input_data;
	}
}

private IIterator<IKVPair<IInteger, IPathInfo>> output_data = null;

		public IIterator<IKVPair<IInteger, IPathInfo>> Output_data {
	get {
		if (this.output_data == null)
					this.output_data = (IIterator<IKVPair<IInteger, IPathInfo>>) Services.getPort("output_data");
		return this.output_data;
	}
}



}

}
