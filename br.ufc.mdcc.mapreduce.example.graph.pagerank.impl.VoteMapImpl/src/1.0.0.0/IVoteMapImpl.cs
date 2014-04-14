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
			IPageNode<IInteger> no = Input_value;
			IIterator<IInteger> iterator = no.Neighbors;
			Double slice = no.Pgrank.Value;
			IDouble outvalue = null;
			iterator.loadFrom (no.Neighbors.clone ());//neighbors.Reset(); //(IIterator<IInteger>)neighbors.clone();
			int size = 0;
			for (; !iterator.HasFinished; ) {
				IInteger outkey = iterator.fetch_next();
				IKVPair<IInteger, IDouble> kvn = Output_data.createItem(); //new IKVPairImpl<IInteger, IDouble>();
				if (size == 0)
					outvalue = kvn.Value;
				kvn.Key = outkey;
				kvn.Value = outvalue;
				size++;
			}
			if(size>0) outvalue.Value = slice / size;
		}
	}
}
