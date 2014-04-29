using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.Double;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.VoteReduce;

namespace br.ufc.mdcc.mapreduce.example.graph.pagerank.impl.VoteReduceImpl { 

	public class IVoteReduceImpl: BaseIVoteReduceImpl, IVoteReduce{
		public IVoteReduceImpl() { 

		} 

		public override void main() { 
			Double soma = 0.0;

			while (!Input_values.Value.HasFinished){
				soma = soma + Input_values.Value.fetch_next().Value;
			}
			Output_value.Key = Input_values.Key;
			Output_value.Value.Value = soma;
		}
	}
}
