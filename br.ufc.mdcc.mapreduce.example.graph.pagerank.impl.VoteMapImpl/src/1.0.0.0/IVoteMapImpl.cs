using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.Double;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PageNode;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PGRank;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.VoteMap;

namespace br.ufc.mdcc.mapreduce.example.graph.pagerank.impl.VoteMapImpl { 
	public class IVoteMapImpl: BaseIVoteMapImpl, IVoteMap{
		public IVoteMapImpl() { 
		} 

		public override void main() { 
			System.Console.WriteLine ("################################################ Starting VoteMapImpl map ###########################################");
			IPageNodeInstance input_value_instance = (IPageNodeInstance)Input_value.Instance;
			IIntegerInstance input_key_instance = (IIntegerInstance)Input_key.Instance;
			IIteratorInstance<IKVPair<IInteger, IDouble>> output_data_instance = (IIteratorInstance<IKVPair<IInteger, IDouble>>)Output_data.Instance;

			//iterator.loadFrom (no.Neighbors.clone ());//neighbors.Reset(); //(IIterator<IInteger>)neighbors.clone();
			IIteratorInstance<IInteger> neighborsInstance = input_value_instance.NeighborsInstance;

			//Finished Iterator of Neighbors
			//neighborsInstance.finish ();
			//

			Double slice = input_value_instance.PgrankInstance.Value;
			object outvalue = null;//IDoubleInstance
			int size = 0;
			object outkey;
			neighborsInstance.fetch_next (out outkey);
			object alternativeIDInstance = outkey;//IIntegerInstance //neighborsInstance.fetch_next();

			while (neighborsInstance.fetch_next (out outkey)) {//IIntegerInstance outkey = (IIntegerInstance)outkey;//neighborsInstance.fetch_next();
				IKVPairInstance<IInteger, IDouble> kvnInstance = (IKVPairInstance<IInteger, IDouble>)Output_data.createItem(); //new IKVPairImpl<IInteger, IDouble>();
				if (size == 0)
					outvalue = kvnInstance.Value;//outvalue=IDoubleInstance
				kvnInstance.Key = outkey;
				kvnInstance.Value = outvalue;
				size++;
				output_data_instance.put (kvnInstance);
			}

			//for (; !neighborsInstance.HasFinished; ) {
			//	IInteger outkey = neighborsInstance.fetch_next();
			//	IKVPair<IInteger, IDouble> kvn = Output_data.createItem(); //new IKVPairImpl<IInteger, IDouble>();
			//	if (size == 0)
			//		outvalue = kvn.Value;
			//	kvn.Key = outkey;
			//	kvn.Value = outvalue;
			//	size++;
			//}
			if (size > 0) {
				((IDoubleInstance)outvalue).Value = slice / size;
			}
			else {
				IKVPairInstance<IInteger, IDouble> kvnInstance = (IKVPairInstance<IInteger, IDouble>)Output_data.createItem(); //new IKVPairImpl<IInteger, IDouble>();
				kvnInstance.Key = alternativeIDInstance;//IIntegerInstance
				((IDoubleInstance)kvnInstance.Value).Value = slice;
				output_data_instance.put (kvnInstance);
			}
			IKVPairInstance<IInteger, IDouble> KV = (IKVPairInstance<IInteger, IDouble>)Output_data.createItem(); //new IKVPairImpl<IInteger, IDouble>();
			KV.Key = input_value_instance.IdInstance;
			((IDoubleInstance)KV.Value).Value = 0.0;
			output_data_instance.put (KV);
		}
	}
}
