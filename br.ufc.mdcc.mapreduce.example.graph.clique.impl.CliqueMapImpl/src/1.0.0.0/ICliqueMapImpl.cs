using System;
using System.Collections.Generic;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.mapreduce.example.graph.clique.CliqueNode;
using br.ufc.mdcc.mapreduce.example.graph.clique.CliqueMap;

namespace br.ufc.mdcc.mapreduce.example.graph.clique.impl.CliqueMapImpl { 

	public class ICliqueMapImpl: BaseICliqueMapImpl, ICliqueMap{
		public ICliqueMapImpl() { 
		} 

		public override void main() { 
			IIteratorInstance<IKVPair<IString, ICliqueNode>> output = (IIteratorInstance<IKVPair<IString, ICliqueNode>>)Output_data.Instance;
			IIntegerInstance input_key = (IIntegerInstance)Input_key.Instance;
			ICliqueNodeInstance input_value = (ICliqueNodeInstance)Input_value.Instance;


			//Debug Start
			string[] data_tempo = System.IO.File.ReadAllText("/home/cenez/data.txt").Split(' ');
			string saida = "";
			IIntegerInstance I = input_key;
			ICliqueNodeInstance N = input_value;
			saida = "TaskRank="+this.Rank+" <" + I.Value + ", [";
			IEnumerator<int> neighbor = N.NeighborsInstance.GetEnumerator ();
			while (neighbor.MoveNext ()) {
				saida = saida + neighbor.Current + " ";
			}
			saida = saida + "]>";
			using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"/home/cenez/logInputCliqueMap"+data_tempo[0], true)){
				file.WriteLine(saida);
			}
			//Debug End


			IEnumerator<int> iterator = input_value.NeighborsInstance.GetEnumerator();
			while (iterator.MoveNext()) {
				IKVPairInstance<IString, ICliqueNode> KV = (IKVPairInstance<IString, ICliqueNode>)Output_data.createItem ();
				((IStringInstance)KV.Key).Value = iterator.Current.ToString ();
				((ICliqueNodeInstance)KV.Value).IdInstance = input_value.IdInstance;
				((ICliqueNodeInstance)KV.Value).NeighborsInstance = input_value.NeighborsInstance;
				output.put (KV);
			}
		}
	}
}
