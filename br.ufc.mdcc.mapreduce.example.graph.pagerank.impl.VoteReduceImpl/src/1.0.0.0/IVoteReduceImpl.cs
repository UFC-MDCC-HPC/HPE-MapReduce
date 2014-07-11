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
			System.Console.WriteLine ("################################################ Starting VoteReduceImpl reduce ###########################################");
			IKVPairInstance<IInteger,IIterator<IDouble>> input_values_instance = (IKVPairInstance<IInteger,IIterator<IDouble>>)Input_values.Instance;
			IIntegerInstance integer_instance = (IIntegerInstance) input_values_instance.Key;
			IIteratorInstance<IDouble> doubles_iterator_instance = (IIteratorInstance<IDouble>) input_values_instance.Value;
			IKVPairInstance<IInteger, IDouble> output_value_instance = (IKVPairInstance<IInteger, IDouble>)Output_value.Instance;

			Double soma = 0.0;

			object double_object;
			while (doubles_iterator_instance.fetch_next(out double_object))	
				soma = soma + ((IDoubleInstance) double_object).Value;
			output_value_instance.Key = integer_instance;
			((IDoubleInstance)output_value_instance.Value).Value = soma;
			//while (!Input_values.Value.HasFinished){
			//	soma = soma + Input_values.Value.fetch_next().Value;
			//}
			//Output_value.Key = Input_values.Key;
			//Output_value.Value.Value = soma;
		}
	}
}
