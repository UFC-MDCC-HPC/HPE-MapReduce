using System;
using System.Collections.Generic;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PageNode;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.BreakInPageNodes;

namespace br.ufc.mdcc.mapreduce.example.graph.pagerank.impl.BreakInPageNodesImpl { 
	public class IBreakInPageNodesImpl: BaseIBreakInPageNodesImpl, IBreakInPageNodes{
		public IBreakInPageNodesImpl() { 

		} 

		public override void main() { 
			while (!Input_data.HasFinished) {
				IKVPair<IInteger,IPageNode<IInteger>> pair = (IKVPair<IInteger, IPageNode<IInteger>>)Output_data.createItem ();
				IPageNode<IInteger> v = Input_data.fetch_next ();
				pair.Key = v.Id;
				pair.Value = v;
			}

			/*
			IDictionary<int, IDictionary<int,IPageNode<IInteger>>> dictionary = new Dictionary<int, IDictionary<int,IPageNode<IInteger>>>();
			IInteger alternativeID = null;

			string[] lines = Input_data.Value.Split(new char[] {'\n'});
			foreach (string line in lines){

				IPageNode<IInteger> v, n, temp = null;
				IDictionary<int,IPageNode<IInteger>> dicRef0, dicRef1 = null;
				string[] spl = line.Split(' ');

				int[] Ids = new int[spl.Length];
				int j = 0;
				foreach(string i in spl){
					Ids[j] = int.Parse(i);
					j++;
				}
				if (!dictionary.TryGetValue (Ids [0], out dicRef0)) {
					IKVPair<IInteger,IPageNode<IInteger>> pair = (IKVPair<IInteger, IPageNode<IInteger>>)Output_data.createItem ();
					pair.Key = pair.Value.Id;
					pair.Key.Value = Ids [0];

					dicRef0 = new Dictionary<int,IPageNode<IInteger>> ();
					dictionary [Ids [0]] = dicRef0;
					dicRef0 [Ids [0]] = pair.Value;

					if (alternativeID == null)
						alternativeID = (IInteger)pair.Key.clone ();
					pair.Value.Neighbors.put (alternativeID);
				}
				if (!dictionary.TryGetValue (Ids [1], out dicRef1)) {
					IKVPair<IInteger,IPageNode<IInteger>> pair = (IKVPair<IInteger, IPageNode<IInteger>>)Output_data.createItem();
					pair.Key = pair.Value.Id;
					pair.Key.Value = Ids[1];

					dicRef1 = new Dictionary<int,IPageNode<IInteger>> ();
					dictionary [Ids [1]] = dicRef1;
					dicRef1 [Ids [1]] = pair.Value;

					if (alternativeID == null)
						alternativeID = (IInteger)pair.Key.clone ();
					pair.Value.Neighbors.put (alternativeID);
				}
				v = dicRef0[Ids[0]];
				n = dicRef1[Ids[1]];
				if (!dicRef0.TryGetValue (Ids [1], out temp)) {
					dicRef0 [Ids [1]] = n;
					v.Neighbors.put (n.Id);
				}
			}
			alternativeID.Value = dictionary.Count * -1;
			*/
		}
	}
}
