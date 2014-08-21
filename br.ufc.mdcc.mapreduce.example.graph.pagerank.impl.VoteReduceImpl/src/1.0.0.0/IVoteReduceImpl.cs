using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Double;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.VoteReduce;

namespace br.ufc.mdcc.mapreduce.example.graph.pagerank.impl.VoteReduceImpl { 

	public class IVoteReduceImpl: BaseIVoteReduceImpl, IVoteReduce{
		public IVoteReduceImpl() { 

		} 

		public override void main() { 
			IKVPairInstance<IString,IIterator<IDouble>> input = (IKVPairInstance<IString,IIterator<IDouble>>) Input_values.Instance;
			IIteratorInstance<IDouble> doubles = (IIteratorInstance<IDouble>) input.Value;

			double soma = 0.0;
			object o;
			while (doubles.fetch_next(out o))						
				soma += ((IDoubleInstance) o).Value;

			IKVPairInstance<IString,IDouble> kvpair = (IKVPairInstance<IString,IDouble>) Output_value.newInstance();

			((IStringInstance)kvpair.Key).Value = ((IStringInstance)input.Key).Value;
			((IDoubleInstance)kvpair.Value).Value = soma;

			//using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"/home/cenez/workspace/java/hash-programming-environment-read-only/HPE_BackEnd/logReduce", true)){
			//	file.WriteLine("key="+((IStringInstance)kvpair.Key).Value+" : value="+((IDoubleInstance)kvpair.Value).Value);
			//}
		}
	}
}
