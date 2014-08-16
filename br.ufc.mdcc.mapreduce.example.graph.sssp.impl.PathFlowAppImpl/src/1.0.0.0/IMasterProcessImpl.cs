using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Platform;
using br.ufc.mdcc.mapreduce.example.graph.sssp.PathFlowApp;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Iterator;

namespace br.ufc.mdcc.mapreduce.example.graph.sssp.impl.PathFlowAppImpl { 

	public class IMasterProcessImpl<PLATFORM> : BaseIMasterProcessImpl<PLATFORM>, IMasterProcess<PLATFORM>
		where PLATFORM:IPlatform{
		public IMasterProcessImpl() { } 

		private const string PATH = "/home/cenez/path.txt";
		private bool done = true;
		public override void main() { 
			string fileContent = readInput (PATH);
			((IStringInstance)Input_data.Instance).Value = "1 c 0" + System.Environment.NewLine + fileContent;
			while (done) {
				this.Path_flow.go ();
				this.Path_flow.destroySlice ();
				//System.Threading.Thread.Sleep (3000);

				IIteratorInstance<IKVPair<IString,IString>> output = (IIteratorInstance<IKVPair<IString, IString>>)Output_data.Instance;

				string buffer = "";
				done = false;
				object o;
				while (output.fetch_next (out o)) {
					IKVPairInstance<IString,IString> kv = (IKVPairInstance<IString, IString>)o;
					IStringInstance k = (IStringInstance)kv.Key;
					IStringInstance v = (IStringInstance)kv.Value;
					Console.WriteLine (v.Value);
					buffer = buffer + v.Value + System.Environment.NewLine;

				    if (!done && k.Value.Equals ("0"))
						done = true;
				}
				((IStringInstance)Input_data.Instance).Value = buffer + fileContent;
				done = false;
			}
		}
		string readInput(string PATH){
			return System.IO.File.ReadAllText(PATH);
		}
	}
}