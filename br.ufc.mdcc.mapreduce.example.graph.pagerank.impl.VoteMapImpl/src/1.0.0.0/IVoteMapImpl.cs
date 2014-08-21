using System;
using System.Collections.Generic;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.Double;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PageNode;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.VoteMap;

namespace br.ufc.mdcc.mapreduce.example.graph.pagerank.impl.VoteMapImpl { 
	public class IVoteMapImpl: BaseIVoteMapImpl, IVoteMap{
		public IVoteMapImpl() { 
		} 

		public override void main() { 
			IIntegerInstance input_key = (IIntegerInstance)Input_key.Instance;
			IPageNodeInstance input_value = (IPageNodeInstance)Input_value.Instance;
			IIteratorInstance<IKVPair<IString, IDouble>> output = (IIteratorInstance<IKVPair<IString, IDouble>>)Output_data.Instance;

			double slice = input_value.PgrankInstance;
			int size = input_value.NeighborsInstance.Count;

			IEnumerator<int> iterator = input_value.NeighborsInstance.GetEnumerator();
			while (iterator.MoveNext()) {
				string n = iterator.Current.ToString();
				IKVPairInstance<IString, IDouble> kvpair = (IKVPairInstance<IString, IDouble>)Output_data.createItem ();
				((IStringInstance)kvpair.Key).Value = n;
				((IDoubleInstance)kvpair.Value).Value = slice/size;
				output.put (kvpair);
			}
			if (size == 0){
				IKVPairInstance<IString, IDouble> kvpair = (IKVPairInstance<IString, IDouble>)Output_data.createItem();
				((IStringInstance)kvpair.Key).Value = "X";
				((IDoubleInstance)kvpair.Value).Value = slice;
				output.put (kvpair);
			}
			IKVPairInstance<IString, IDouble> KV = (IKVPairInstance<IString, IDouble>)Output_data.createItem();
			((IStringInstance)KV.Key).Value = input_key.Value.ToString();
			((IDoubleInstance)KV.Value).Value = 0.0;
			output.put (KV);
		}
	}
}
