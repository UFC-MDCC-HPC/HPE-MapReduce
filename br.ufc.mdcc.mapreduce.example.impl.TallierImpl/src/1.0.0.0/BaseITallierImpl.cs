/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.mapreduce.example.Tallier;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.Iterator;

namespace br.ufc.mdcc.mapreduce.example.impl.TallierImpl { 

	public abstract class BaseITallierImpl: Computation, BaseITallier
{

private IKVPair<IString,IInteger> output_value = null;

public IKVPair<IString,IInteger> Output_value {
	get {
		if (this.output_value == null)
					this.output_value = (IKVPair<IString,IInteger>) Services.getPort("output_value");
		return this.output_value;
	}
}

private IKVPair<IString,IIterator<IInteger>> input_values = null;

public IKVPair<IString,IIterator<IInteger>> Input_values {
	get {
		if (this.input_values == null)
					this.input_values = (IKVPair<IString,IIterator<IInteger>>) Services.getPort("input_values");
		return this.input_values;
	}
}



}

}
