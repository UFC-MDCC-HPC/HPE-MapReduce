using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using MPI;

namespace graph {
	public class Program {
		public ITableMapReduce<string, string> KVPair_OMK_OMV;
		IDictionary<int,IDictionary<int, double>> neighbours = new Dictionary<int, IDictionary<int,double>> ();
		public static string chaveORV = "";
		public static string valorORV = "";
		protected MPI.Environment mpi = null;
		protected Intracommunicator worldcomm = null;
		public int Size = 0;
		public int Rank = 0;
		public IDictionary<int, string> saidas;
		protected MPI.RequestList rlist = new RequestList();
		public static string Buffer = "";

		private const string INPUT_FILE_PATH = "/home/hpe/path.txt";
		private const string TEMP_FILE_PATH = INPUT_FILE_PATH+".parallel";
		private const string OUTPUT_FILE_PATH = "./output";

		public static void Main(string[] args) {
			Program P = new Program();
			P.enviroment (args);

			long t0 = (long)(DateTime.UtcNow - (new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc))).TotalMilliseconds; 
			P.go_parallel ();
			long t1 = (long)(DateTime.UtcNow - (new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc))).TotalMilliseconds;
			long time1 = t1 - t0;

			if (P.Rank == 0) {
				System.Console.WriteLine ("TIME Parallel: " + (time1) + " ms.");
			}

			P.close_enviroment ();
		}
		public void breaking(){
			Randomize.clearFile (TEMP_FILE_PATH+Rank);
			string s = "";
			s = "1 c 0" + System.Environment.NewLine + readInput (INPUT_FILE_PATH);
			string[] lines = s.Split(new char[] {System.Environment.NewLine[0]});
			foreach (string line in lines) {
				if (!line.Trim ().Equals ("")) {
					string[] words = line.Split (' ');
					int task_id = Math.Abs ((words [0]).GetHashCode ()) % Size;
					if (task_id == Rank) {
						string saida = words [0] + " " + words [1] + " " + words [2];
						Randomize.writeFile (TEMP_FILE_PATH+Rank, saida);
					}
				}
			}
		}

		public void enviroment(string[] args){
			mpi = new MPI.Environment(ref args);
			worldcomm = Communicator.world;
			Size = worldcomm.Size;
			Rank = worldcomm.Rank;
		}
		public void close_enviroment(){
			worldcomm.Barrier();
			mpi.Dispose();
		}
		public void go_parallel(){
			breaking ();

			string input = readInput (TEMP_FILE_PATH+Rank); //(PATH);

			bool sair = false;
			while (!sair) {
				splitMap (input);
				input = "";
				saidas = new Dictionary<int, string> ();
				sair = true;
				IEnumerator<string> I = KVPair_OMK_OMV.getIteratorKeys ();
				while (I.MoveNext ()) {
					string key = I.Current;
					reduce (key, KVPair_OMK_OMV.getList (key));
					string[] words = valorORV.Split (' ');

					int task_id = Math.Abs ((words[0]).GetHashCode ()) % Size;
					if (task_id == Rank)
						input = input + valorORV;
					else {
						if (!saidas.ContainsKey (task_id))
							saidas [task_id] = "";
						saidas [task_id] = saidas [task_id] + valorORV;
					}
					if (sair && chaveORV.Equals ("0"))
						sair = false;
				}
				for (int i = 0; i< Size; i++){
					if (i != Rank) {
						if (!saidas.ContainsKey (i))
							saidas [i] = "";
						rlist.Add (worldcomm.ImmediateSend<string> (saidas [i], i, 0));
					}
				}
				for (int i =0;i<Size;i++) {
					if(i!=Rank)
						input = input + worldcomm.Receive<string> (i, 0);
				}
				rlist.WaitAll ();
				int exit = worldcomm.Allreduce<int> (sair ? 1 : 0, MPI.Operation<int>.Min);
				sair = exit == 1;
			}
			Randomize.clearFile (OUTPUT_FILE_PATH+Rank);
			using (System.IO.StreamWriter file = new System.IO.StreamWriter(@OUTPUT_FILE_PATH+Rank, true)){
				file.WriteLine(input);
			}
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
		public static void writeFile(string PATH, string saida){
			using (System.IO.StreamWriter file = new System.IO.StreamWriter(@PATH, true)){
				file.WriteLine(saida);
			}
		}
		public double min (double d1, double d2){
			return d1 < d2 ? d1 : d2;
		}
	}
}
