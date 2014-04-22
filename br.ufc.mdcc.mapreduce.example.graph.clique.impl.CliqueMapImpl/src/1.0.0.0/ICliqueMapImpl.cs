using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.impl.KVPairImpl;
using br.ufc.mdcc.mapreduce.example.graph.clique.CliqueNode;
using br.ufc.mdcc.mapreduce.example.graph.clique.CliqueMap;

namespace br.ufc.mdcc.mapreduce.example.graph.clique.impl.CliqueMapImpl { 

	public class ICliqueMapImpl: BaseICliqueMapImpl, ICliqueMap{
		public ICliqueMapImpl() { 
		} 

		public override void main() { 

			IKVPair<IInteger, IIterator<IInteger>> VALUE = null;

			for (; !Input_value.Neighbors.HasFinished; ) {
				IInteger KEY = Input_value.Neighbors.fetch_next();
				IKVPair<IInteger, IKVPair<IInteger, IIterator<IInteger>>> KV = Output_data.createItem ();
				KV.Key = KEY;
				if (VALUE == null)
					VALUE = new IKVPairImpl<IInteger, IIterator<IInteger>> ();
				KV.Value = VALUE;
			}
			if (VALUE != null) {
				VALUE.Key = Input_key;
				VALUE.Value = (IIterator<IInteger>)Input_value.Neighbors.clone ();
			}

		}
	}
}
