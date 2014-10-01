using System;

namespace graph{
	public class Randomize{
		public Randomize (){
		}
		public static string readInput(string PATH){
			return System.IO.File.ReadAllText(PATH);
		}
		public static void writeFile(string PATH, string saida){
			using (System.IO.StreamWriter file = new System.IO.StreamWriter(@PATH, true)){
				file.WriteLine(saida);
			}
		}
		public static void clearFile(string PATH){
			using (System.IO.StreamWriter file = new System.IO.StreamWriter(@PATH, false)){
				file.Write("");
			}
		}
		public void randomize(){
			string input = readInput ("/home/cenez/path.txt-131072E-32768V-4NoZero");
			Random R = new Random ();
			string s = input;

			string[] lines = s.Split(new char[] {System.Environment.NewLine[0]});
			foreach (string line in lines) {
				if (!line.Trim().Equals ("")) {
					string[] words = line.Split (' ');
					string saida = words [0]+" "+words [1] + " " + (R.Next(0,10));
					writeFile ("/home/cenez/path.txt-131072E-32768V-4NoZero-Random", saida);
				}
			}
		}
	}
}

