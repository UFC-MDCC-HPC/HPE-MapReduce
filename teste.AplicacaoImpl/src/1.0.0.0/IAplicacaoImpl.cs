using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using teste.Aplicacao;
using br.ufc.mdcc.common.Double;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PageNode;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PGRank;


namespace teste.AplicacaoImpl { 

public class IAplicacaoImpl : BaseIAplicacaoImpl, IAplicacao
{

public IAplicacaoImpl() { 

} 

public override void main() { 
			Console.WriteLine ("################################*IAplicacaoImpl Start ###############################");
			IDoubleInstance tDouble = (IDoubleInstance) T_double.Instance;
			IKVPairInstance<IString, IDouble> tKVPair = (IKVPairInstance<IString, IDouble>)T_kvpair.Instance;//.newInstance ();
			IIntegerInstance tInteger = (IIntegerInstance) T_integer.Instance;
			IIteratorInstance<IInteger> tIterator = (IIteratorInstance<IInteger>)T_iterator.Instance;//.newInstance ();
			IStringInstance tString = (IStringInstance) T_string.Instance;

			tDouble.Value = 0.8;
			tInteger.Value = 8;
			tString.Value = "Tipo String";

			((IStringInstance)tKVPair.Key).Value = tString.Value;
			((IDoubleInstance)tKVPair.Value).Value = tDouble.Value;

			tIterator.put (tInteger); 
			tIterator.finish ();

			object o; int count = 0;
			while (tIterator.fetch_next (out o)) {
				IIntegerInstance oI = (IIntegerInstance) o;
				Console.WriteLine ("Item Iterator "+ (count++) + ": " +oI.Value);
			}
			Console.WriteLine ("tDouble.Value="+tDouble.Value+" : "+"tInteger.Value="+tInteger.Value+" : "+"tString.Value="+tString.Value);
			Console.WriteLine ("tKVPair.Key="+((IStringInstance)tKVPair.Key).Value+" : "+"tKVPair.Value="+((IDoubleInstance)tKVPair.Value).Value);

			IPageNodeInstance instance = (IPageNodeInstance) T_aplicacao_node.Instance;
			((IIntegerInstance)instance.IdInstance).Value = 8;
			IIntegerInstance item = (IIntegerInstance) T_aplicacao_node.Edge_node.createItem ();
			item.Value = 7;

			instance.NeighborsInstance.put (item);
			instance.NeighborsInstance.put (((IIntegerInstance)instance.IdInstance));
			instance.NeighborsInstance.finish ();
			while (instance.NeighborsInstance.fetch_next (out o)) {
				IIntegerInstance II = (IIntegerInstance)o;
				Console.WriteLine ("%%%%%%%%%%%%%%%%%%%%%%%%%%%% Valor no Iterator="+II.Value);
			}
			Console.WriteLine ("%%%%%%%%%%%%%%%%%%%%%%%%%%%% Resultado Id_node=" + ((IIntegerInstance)instance.IdInstance).Value+" PGRank="+instance.PgrankInstance.Value);

			Console.WriteLine ("################################ IAplicacaoImpl End ###############################");

}

}

}
