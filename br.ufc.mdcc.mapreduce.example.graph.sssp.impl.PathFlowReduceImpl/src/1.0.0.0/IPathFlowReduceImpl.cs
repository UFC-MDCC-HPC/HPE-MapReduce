using System;
using System.Collections.Generic;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.example.graph.sssp.PathFlowReduce;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Iterator;

namespace br.ufc.mdcc.mapreduce.example.graph.sssp.impl.PathFlowReduceImpl { 

	public class IPathFlowReduceImpl : BaseIPathFlowReduceImpl, IPathFlowReduce
	{
		public IPathFlowReduceImpl() { } 

		public override void main() 
		{ 
			IDictionary<int, double> neibours = new Dictionary<int, double> ();
			double di = int.MaxValue;
			double dmin = int.MaxValue;
			int done = 1;

			IKVPairInstance<IString, IIterator<IString>> input = (IKVPairInstance<IString, IIterator<IString>>)Input_values.Instance;
			IStringInstance k = (IStringInstance)input.Key;
			IIteratorInstance<IString> v = (IIteratorInstance<IString>)input.Value;

			string buffer = "";
			object o;
			while (v.fetch_next (out o)) 
			{
				IStringInstance item = (IStringInstance)o;

				string[] values = item.Value.Split (' ');
				if (values [0].Equals ("c")) {
					double tmp = double.Parse (values [1]);
					dmin = min (dmin, tmp);
				}
				else if (values [0].Equals ("d")) {
					di = double.Parse (values [1]);
				}
				else 
					neibours[int.Parse(values[0])]=double.Parse(values[1]);
			}
			dmin = min (dmin,di);
			if(dmin!=di){
				IList<string> lista = new List<string> ();
				foreach (KeyValuePair<int, double> kv in neibours) {
					buffer = buffer + kv.Key+" c "+ (kv.Value+dmin) + System.Environment.NewLine;
				}
				done = 0;
			}
			buffer = buffer + k.Value + " d " + dmin + " " + System.Environment.NewLine;

			IKVPairInstance<IString, IString> orv = (IKVPairInstance<IString, IString>) Output_value.newInstance();
			((IStringInstance)orv.Key).Value = done.ToString ();
			((IStringInstance)orv.Value).Value = buffer;
		}
		public double min (double d1, double d2){
			return d1<d2?d1:d2;
		}
	}
}
