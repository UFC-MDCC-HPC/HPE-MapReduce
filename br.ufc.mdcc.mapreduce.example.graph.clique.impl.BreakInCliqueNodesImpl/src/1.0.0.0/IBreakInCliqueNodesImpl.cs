using System;
using System.Collections.Generic;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.mapreduce.example.graph.clique.CliqueNode;
using br.ufc.mdcc.mapreduce.example.graph.clique.BreakInCliqueNodes;

namespace br.ufc.mdcc.mapreduce.example.graph.clique.impl.BreakInCliqueNodesImpl { 
	public class IBreakInCliqueNodesImpl: BaseIBreakInCliqueNodesImpl, IBreakInCliqueNodes{
		public IBreakInCliqueNodesImpl() { 

		} 

		public override void main() { 
			while (!Input_data.HasFinished) {
				IKVPair<IInteger,ICliqueNode<IInteger>> pair = (IKVPair<IInteger, ICliqueNode<IInteger>>)Output_data.createItem ();
				ICliqueNode<IInteger> v = Input_data.fetch_next ();
				pair.Key = v.Id;
				pair.Value = v;
			}
		}
	}
}
