using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.mapreduce.example.graph.clique.CliqueNode;
using br.ufc.mdcc.mapreduce.example.graph.clique.CliqueMap;

namespace br.ufc.mdcc.mapreduce.example.graph.clique.impl.CliqueMapImpl { 

	public class ICliqueMapImpl: BaseICliqueMapImpl, ICliqueMap{
		public ICliqueMapImpl() { 
		} 

		public override void main() { 
			IIteratorInstance<IKVPair<IInteger, IKVPair<IInteger, IIterator<IInteger>>>> output_data_instance = (IIteratorInstance<IKVPair<IInteger, IKVPair<IInteger, IIterator<IInteger>>>>)Output_data.Instance;
			IIntegerInstance input_key_instance = (IIntegerInstance)Input_key.Instance;
			ICliqueNodeInstance<IInteger> input_value_instance = (ICliqueNodeInstance<IInteger>) Input_value.Instance;
			IKVPairInstance<IInteger, IIterator<IInteger>> VALUE = null;
			
			input_value_instance.NeighborsInstance.finish();
			
			object KEY;//IIntegerInstance
			while (input_value_instance.NeighborsInstance.fetch_next (out KEY)) {
				IKVPairInstance<IInteger, IKVPair<IInteger, IIterator<IInteger>>> KV = (IKVPairInstance<IInteger, IKVPair<IInteger, IIterator<IInteger>>>)Output_data.createItem ();
				output_data_instance.put (KV);
				KV.Key = KEY;
				if (VALUE == null)
					VALUE = (IKVPairInstance<IInteger, IIterator<IInteger>>)KV.Value;
				KV.Value = VALUE;
				((IIteratorInstance<IInteger>)VALUE.Value).put (KEY);
			}
			if (VALUE != null) {
				((IKVPairInstance<IInteger, IIterator<IInteger>>)VALUE).Key = Input_key.Instance;
				((IIteratorInstance<IInteger>)VALUE.Value).finish ();
			}

			//for (; !Input_value.Neighbors.HasFinished; ) {
			//	IInteger KEY = Input_value.Neighbors.fetch_next();
			//	IKVPair<IInteger, IKVPair<IInteger, IIterator<IInteger>>> KV = Output_data.createItem ();
			//	KV.Key = KEY;
			//	if (VALUE == null)
			//		VALUE = new IKVPairImpl<IInteger, IIterator<IInteger>> ();
			//	KV.Value = VALUE;
			//}
			//if (VALUE != null) {
			//	VALUE.Key = Input_key;
			//	VALUE.Value = (IIterator<IInteger>)Input_value.Neighbors.clone ();
			//}
		}
	}
}
