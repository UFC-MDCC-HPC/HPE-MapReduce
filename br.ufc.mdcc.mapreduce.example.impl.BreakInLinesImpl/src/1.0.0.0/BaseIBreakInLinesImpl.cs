/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.example.BreakInLines;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.String;

namespace br.ufc.mdcc.mapreduce.example.impl.BreakInLinesImpl { 

	public abstract class BaseIBreakInLinesImpl: Computation, BaseIBreakInLines
{

private IIterator<IKVPair<IInteger,IString>> output_data = null;

	public IIterator<IKVPair<IInteger,IString>> Output_data {
	get {
		if (this.output_data == null)
				this.output_data = (IIterator<IKVPair<IInteger,IString>>) Services.getPort("output_data");
		return this.output_data;
	}
}

	private IString input_data = null;

	public IString Input_data {
	get {
		if (this.input_data == null)
				this.input_data = (IString) Services.getPort("input_data");
		return this.input_data;
	}
}



}

}
