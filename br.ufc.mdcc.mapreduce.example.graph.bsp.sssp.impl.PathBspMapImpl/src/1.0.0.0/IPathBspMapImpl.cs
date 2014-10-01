using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.example.graph.bsp.sssp.PathBspMap;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Iterator;

namespace br.ufc.mdcc.mapreduce.example.graph.bsp.sssp.impl.PathBspMapImpl { 

	public class IPathBspMapImpl : BaseIPathBspMapImpl, IPathBspMap {
		public IPathBspMapImpl() { } 

		public override void main() { 
			IStringInstance input = (IStringInstance) Input_value.Instance;
			IIteratorInstance<IKVPair<IString, IString>> output = (IIteratorInstance<IKVPair<IString, IString>>)Output_data.Instance;

			if (!input.Value.Equals ("")) {
				string[] words = input.Value.Split (' ');
				IKVPairInstance<IString, IString> kvpair = (IKVPairInstance<IString, IString>) Output_data.createItem ();
				((IStringInstance)kvpair.Key).Value = words [0];
				((IStringInstance)kvpair.Value).Value = words [1] + " " + words [2];
				output.put (kvpair);
				if (!words [1].Equals ("c") && !words [1].Equals ("d")) {
					IKVPairInstance<IString, IString> kvpair2 = (IKVPairInstance<IString, IString>)Output_data.createItem ();
					((IStringInstance)kvpair2.Key).Value = words [1];
					((IStringInstance)kvpair2.Value).Value = "i" + " " + words [0];
					output.put (kvpair2);
				}
			}
		}
	}
}
