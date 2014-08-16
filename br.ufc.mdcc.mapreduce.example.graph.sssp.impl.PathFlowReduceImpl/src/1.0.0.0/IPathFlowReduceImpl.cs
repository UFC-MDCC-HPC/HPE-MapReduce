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

	public class IPathFlowReduceImpl : BaseIPathFlowReduceImpl, IPathFlowReduce{
		public IPathFlowReduceImpl() { } 

		public override void main() { 
			IList<double> c = new List<double>();
			IDictionary<int, double> neibours = new Dictionary<int, double> ();
			double di = int.MaxValue;
			double dmin = 0.0;
			int done = 1;

			IKVPairInstance<IString, IIterator<IString>> input = (IKVPairInstance<IString, IIterator<IString>>)Input_values.Instance;
			IStringInstance k = (IStringInstance)input.Key;
			IIteratorInstance<IString> v = (IIteratorInstance<IString>)input.Value;

			string buffer = "";
			object o;
			while (v.fetch_next (out o)) {
				IStringInstance item = (IStringInstance)o;

				string[] values = item.Value.Split (' ');
				if (values [0].Equals ("c"))
					c.Add (double.Parse (values [1]));
				else if (values [0].Equals ("d")) {
					di = double.Parse (values [1]);
				}
				else 
					neibours[int.Parse(values[0])]=double.Parse(values[1]);
			}
			dmin = min (c,di);
			if(dmin!=di){
				di = dmin;
				IList<string> lista = new List<string> ();
				foreach (KeyValuePair<int, double> kv in neibours) {
					buffer = buffer + kv.Key+" c "+ (kv.Value+dmin) + System.Environment.NewLine;
				}
				done = 0;
			}
			buffer = buffer + k.Value + " d " + di + " " + System.Environment.NewLine;

			IKVPairInstance<IString, IString> orv = (IKVPairInstance<IString, IString>) Output_value.newInstance();
			((IStringInstance)orv.Key).Value = done.ToString ();
			((IStringInstance)orv.Value).Value = buffer;
		}
		public double min (IList<double> c, double di){
			double min = double.MaxValue;
			foreach (double d in c) {
				min = d < min ? d : min;
			}
			return min<di?min:di;
		}
	}
}
