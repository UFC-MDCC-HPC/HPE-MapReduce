using System;
using System.IO;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PageRankApp;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.common.Double;
using br.ufc.mdcc.common.Integer;

namespace br.ufc.mdcc.mapreduce.example.graph.pagerank.impl.PageRankAppImpl { 
	public class IMasterProcessImpl<PLATFORM> : BaseIMasterProcessImpl<PLATFORM>, IMasterProcess<PLATFORM>
		where PLATFORM:IPlatform{

		public IMasterProcessImpl() { } 

		public override void main() {
			Input_data.Value = readInput("pathFile");
			Page_rank.go();
			while (!Output_data.HasFinished) {
				IKVPair<IInteger,IDouble> kv = Output_data.fetch_next();
				Console.Out.Write (kv.Key + ":");
				Console.Out.WriteLine (kv.Value);
			}
		}

		string readInput(string path){
			string str = "";
			byte[] dataByte = readFile (path);
			foreach (byte b in dataByte) {
				str = str+Convert.ToChar(b);
			}
			return str;
		}
		byte[] readFile(string path) {
			string PATH = @path;
			byte[] res = null;
			try{
				using (FileStream fileread = new FileStream(PATH, FileMode.Open, FileAccess.Read)){					
					byte[] bytes = new byte[fileread.Length];
					int bytesToRead = (int)fileread.Length-1;
					int bytesRead = 0;
					while (bytesToRead > 0){
						int n = fileread.Read(bytes, bytesRead, bytesToRead);
						if (n == 0)
							break;
						bytesRead += n;
						bytesToRead -= n;
					}
					bytesToRead = bytes.Length;
					res = bytes;
				}
			}
			catch (FileNotFoundException e){
				Console.WriteLine("Exception IMasterProcessImpl readFile method: "+e.Message);
			}
			return res;
		}
	}
}
