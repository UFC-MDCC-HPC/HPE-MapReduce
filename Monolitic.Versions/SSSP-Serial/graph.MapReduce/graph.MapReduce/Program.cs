using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;

namespace graph {
    public class Program {
		public ITableMapReduce<string, string> KVPair_OMK_OMV;
		IDictionary<int,IDictionary<int, double>> neighbours = new Dictionary<int, IDictionary<int,double>> ();
		public static string chaveORV = "";
		public static string valorORV = "";

		private const string PATH = "/home/cenez/path.txt";

		public static void Main(string[] args) {
			long t0 = (long)(DateTime.UtcNow - (new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc))).TotalMilliseconds;            
			Program P = new Program();
			System.Console.WriteLine("******************* Path ****************");
			P.go ();
			System.Console.WriteLine("*******************************************");
			long t1 = (long)(DateTime.UtcNow - (new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc))).TotalMilliseconds;
			System.Console.WriteLine("TIME: " + (t1 - t0) + " ms.");

        }
		public void go(){
			string input = readInput (PATH);
			input = "1 c 0" + System.Environment.NewLine + input;

			bool sair = false;

			while (!sair) {
				splitMap (input);
				input = "";
				sair = true;
				IEnumerator<string> I = KVPair_OMK_OMV.getIteratorKeys ();
				while (I.MoveNext ()) {
					reduce (I.Current, KVPair_OMK_OMV.getList (I.Current));
					input = input + valorORV;
					if (sair && chaveORV.Equals ("0"))
						sair = false;
				}
			}
			Console.WriteLine (input);
		}
		public void splitMap(string input){
			KVPair_OMK_OMV = new ITableMapReduceImpl<string, string>();
			string s = input;

			string[] lines = s.Split(new char[] {System.Environment.NewLine[0]});
			int line_counter = 0;
			foreach (string line in lines) {
				if (!line.Trim().Equals ("")) {
					map(line_counter++, line);
				}
			}
		}
		public void map(int i, string line){
			if (!line.Equals ("")) {
				string[] words = line.Split (' ');
				KVPair_OMK_OMV.emite(words [0], words [1] + " " + words [2]);
			}
		}
		public void reduce(string key, IList<string> value){
			double di = int.MaxValue;
			double dmin = int.MaxValue;
			int done = 1;

			int k_int = int.Parse (key);
			if (!neighbours.ContainsKey (k_int))
				neighbours [k_int] = new Dictionary<int,double> ();

			string buffer = "";
			foreach (string item in value) {
				string[] values = item.Split (' ');
				switch (values[0][0]) {
				case 'c':
					double tmp = double.Parse (values [1]);
					dmin = min (dmin, tmp);
					break;
				case 'd':
					di = double.Parse (values [1]);
					break;
				default:
					IDictionary<int, double> output_neibours = neighbours [k_int];
					int n = int.Parse (values [0]);
					double d = 0.0;
					if (!output_neibours.TryGetValue (n, out d))
						output_neibours [n] = double.Parse (values [1]);
					else 
						if (double.Parse (values [1]) < d) {
							output_neibours.Remove (n);
							output_neibours [n] = double.Parse (values [1]);
						}
					break;
				}
			}
			dmin = min (dmin,di);
			if(dmin != di){
				foreach (KeyValuePair<int, double> kv in neighbours[k_int]) 
					buffer = buffer + kv.Key + " c "+ (kv.Value + dmin) + System.Environment.NewLine;
				done = 0;
			}
			buffer = buffer + key + " d " + dmin + " " + System.Environment.NewLine;

			chaveORV = done.ToString ();
			valorORV = buffer;
		}
		public static string readInput(string PATH){
			return System.IO.File.ReadAllText(PATH);
		}
		public double min (double d1, double d2){
			return d1 < d2 ? d1 : d2;
		}
	}
}
