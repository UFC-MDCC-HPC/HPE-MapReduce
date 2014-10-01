using System;
using System.Collections.Generic;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.example.graph.bsp.sssp.PathBspReduce;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Iterator;

namespace br.ufc.mdcc.mapreduce.example.graph.bsp.sssp.impl.PathBspReduceImpl { 

	public class IPathBspReduceImpl : BaseIPathBspReduceImpl, IPathBspReduce
	{
		IDictionary<int,IDictionary<int, double>> neighbours = new Dictionary<int, IDictionary<int,double>> ();
		IDictionary<int, double> Dmin = new Dictionary<int,double>();

		private IDictionary<int, string> candidates_buffer = null;
		public IDictionary<int, string> CandidatesBuffer{
			get {
				if (this.candidates_buffer == null) {
					this.candidates_buffer = new Dictionary<int, string> ();
					for(int i=0;i<this.Communicator.Size;i++)
						CandidatesBuffer [i] = "";
				}
				return this.candidates_buffer;
			}
		}
		private IList<int> vertexs = null;
		public IList<int> Vertexs {
			get {
				if (this.vertexs == null)
					this.vertexs = new List<int> ();
				return this.vertexs;
			}
		}
		private int active = 0;
		public int Active {
			get { return this.active; }
			set { this.active = value; }
		}

		private IDictionary<int, double> _di = new Dictionary<int, double>();
		public IDictionary<int, double> Di {
			get { return this._di; }
			set { this._di = value; }
		}
		public void clearCandidatesBuffer(){
			for(int i=0;i<this.Communicator.Size;i++)
			CandidatesBuffer[i] = "";
		}

		public IPathBspReduceImpl() { } 

		#region IPathBspReduce implementation

		public void clearNeighbours ()
		{
			neighbours.Clear ();
		}

		#endregion

		public override void main() 
		{ 
			IKVPairInstance<IString, IIterator<IString>> input = (IKVPairInstance<IString, IIterator<IString>>)Input_values.Instance;
			IStringInstance k = (IStringInstance)input.Key;
			IIteratorInstance<IString> v = (IIteratorInstance<IString>)input.Value;

			int k_int = int.Parse (k.Value);
			if (!neighbours.ContainsKey (k_int)) {
				neighbours [k_int] = new Dictionary<int,double> ();
				Di[k_int] = int.MaxValue;
				Dmin[k_int] = int.MaxValue;
				Vertexs.Add (k_int);
			}

			double di = Di[k_int];
			double dmin = Dmin[k_int];
			int done = 1;

			object o;
			while (v.fetch_next (out o)) {
				IStringInstance item = (IStringInstance) o;

				string[] values = item.Value.Split (' ');
				switch (values[0][0]){
				case 'c':
					double tmp = double.Parse (values [1]);
					dmin = min (dmin, tmp);
					break;
				case 'i':
					break;
				case 'd':
					di = double.Parse (values [1]);
					break;
				default:
					IDictionary<int, double> output_neibours = neighbours [k_int];
					int n = int.Parse (values [0]);
					double d = 0.0;
					if (!output_neibours.TryGetValue (n, out d)) {
						output_neibours [n] = double.Parse (values [1]);
					}
					else 
						if (double.Parse (values [1]) < d) {
							output_neibours[n] = double.Parse (values [1]);
						}
					break;
				}
			}

			dmin = min (dmin,di);
			if(dmin != di){
				di = dmin;
				foreach (KeyValuePair<int, double> kv in neighbours[k_int]) {
					int dest = Math.Abs ((kv.Key+"").GetHashCode ()) % this.Communicator.Size;
					CandidatesBuffer[dest] = CandidatesBuffer[dest] + kv.Key + " " + (kv.Value + dmin) + System.Environment.NewLine;
				}
				done = 0;
			}
			Active = done;

			Di[k_int] = di;
			Dmin [k_int]=dmin;
		}

		public void step(int k_int, double valor){
			double di = Di[k_int];
			double dmin = Dmin[k_int];

			dmin = min (dmin, valor);
			int done = 1;

			dmin = min (dmin,di);
			if(dmin != di){
				di = dmin;
				foreach (KeyValuePair<int, double> kv in neighbours[k_int]) {
					int dest = Math.Abs ((kv.Key+"").GetHashCode ()) % this.Communicator.Size;
					CandidatesBuffer[dest] = CandidatesBuffer[dest] + kv.Key + " " + (kv.Value + dmin) + System.Environment.NewLine;
				}
				done = 0;
			}
			Active = done;

			Di[k_int] = di;
			Dmin [k_int]=dmin;
		}
		public void apply(){
			string buffer = "";

			foreach (KeyValuePair<int, double> kv in Di)
				buffer = buffer + kv.Key + " d " + kv.Value + System.Environment.NewLine;

			IKVPairInstance<IString, IString> orv = (IKVPairInstance<IString, IString>) Output_value.newInstance();
			((IStringInstance)orv.Key).Value = "1";
			((IStringInstance)orv.Value).Value = buffer;
		}

		public double min (double d1, double d2)
		{
			return d1 < d2 ? d1 : d2;
		}
	}
}
