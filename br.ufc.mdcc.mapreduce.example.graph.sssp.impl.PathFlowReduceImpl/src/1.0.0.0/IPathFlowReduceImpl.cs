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
		IDictionary<int,IDictionary<int, double>> neighbours = new Dictionary<int, IDictionary<int,double>> ();

		public IPathFlowReduceImpl() { } 

		#region IPathFlowReduce implementation

		public void clearNeighbours ()
		{
			neighbours.Clear ();
		}

		#endregion

		public override void main() 
		{ 
			double di = int.MaxValue;
			double dmin = int.MaxValue;
			int done = 1;

//			var t = Tuple.Create<string,int>("dd",333);

			IKVPairInstance<IString, IIterator<IString>> input = (IKVPairInstance<IString, IIterator<IString>>)Input_values.Instance;
			IStringInstance k = (IStringInstance)input.Key;
			IIteratorInstance<IString> v = (IIteratorInstance<IString>)input.Value;

			int k_int = int.Parse (k.Value);
			if (!neighbours.ContainsKey (k_int))
				neighbours [k_int] = new Dictionary<int,double> ();

			string buffer = "";
			object o;
			while (v.fetch_next (out o)) 
			{
				IStringInstance item = (IStringInstance) o;

				string[] values = item.Value.Split (' ');
				switch (values[0][0])
				{
					case 'c':
						double tmp = double.Parse (values [1]);
						dmin = min (dmin, tmp);
						break;
					case 'd':
						di = double.Parse (values [1]);
						break;
					default:
					//neighbours [k_int] [int.Parse (values [0])] = double.Parse (values [1]);
						IDictionary<int, double> output_neibours = neighbours [k_int];
						int n = int.Parse (values [0]);
						double d = 0.0;
						if (!output_neibours.TryGetValue (n, out d))
							output_neibours [n] = double.Parse (values [1]);
						else if (double.Parse (values [1]) < d) {
							output_neibours.Remove (n);
							output_neibours [n] = double.Parse (values [1]);
						}
						break;
				}

			}

			dmin = min (dmin,di);
			if(dmin != di)
			{
				foreach (KeyValuePair<int, double> kv in neighbours[k_int]) 
						buffer = buffer + kv.Key + " c "+ (kv.Value + dmin) + System.Environment.NewLine;
				done = 0;
			}
			buffer = buffer + k.Value + " d " + dmin + " " + System.Environment.NewLine;

			IKVPairInstance<IString, IString> orv = (IKVPairInstance<IString, IString>) Output_value.newInstance();
			((IStringInstance)orv.Key).Value = done.ToString ();
			((IStringInstance)orv.Value).Value = buffer;
		}

		public double min (double d1, double d2)
		{
			return d1 < d2 ? d1 : d2;
		}
	}
}
