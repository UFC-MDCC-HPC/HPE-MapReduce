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
		private bool done = false;
		public override void main() { 
			string fileContent = readInput (PATH);
			((IStringInstance)Input_data.Instance).Value = "1 c 0" + System.Environment.NewLine + fileContent;

			while (!done) {
				this.Path_flow.go ();

				IIteratorInstance<IKVPair<IString,IString>> output = (IIteratorInstance<IKVPair<IString, IString>>)Output_data.Instance;

				string buffer = "";
				done = true;
				object o;
				while (output.fetch_next (out o)) {
					IKVPairInstance<IString,IString> kv = (IKVPairInstance<IString, IString>)o;
					IStringInstance k = (IStringInstance)kv.Key;
					IStringInstance v = (IStringInstance)kv.Value;
					Console.WriteLine ("done:"+k.Value+" {"+System.Environment.NewLine+v.Value+"}");
					buffer = buffer + v.Value;// + System.Environment.NewLine;

				    if (done && k.Value.Equals ("0"))
						done = false;
				}
				((IStringInstance)Input_data.Instance).Value = buffer + fileContent;

				//Start Debug
				done = true;
				//End Debug

			}
		}
		string readInput(string PATH){
			return System.IO.File.ReadAllText(PATH);
		}
	}
}