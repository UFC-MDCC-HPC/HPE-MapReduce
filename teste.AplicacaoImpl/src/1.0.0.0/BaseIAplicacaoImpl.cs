/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Double;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.String;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PageNode;
using teste.Aplicacao;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PGRank;
//using br.ufc.mdcc.mapreduce.example.graph.pagerank.PageNode;

namespace teste.AplicacaoImpl { 
	public abstract class BaseIAplicacaoImpl: Application, BaseIAplicacao{
		private IDouble t_double = null;
		protected IDouble T_double {
			get {
				if (this.t_double == null)
					this.t_double = (IDouble) Services.getPort("t_double");
				return this.t_double;
			}
		}

		private IKVPair<IString, IDouble> t_kvpair = null;
		protected IKVPair<IString, IDouble> T_kvpair {
			get {
				if (this.t_kvpair == null)
					this.t_kvpair = (IKVPair<IString, IDouble>) Services.getPort("t_kvpair");
				return this.t_kvpair;
			}
		}

		private IInteger t_integer = null;
		protected IInteger T_integer {
			get {
				if (this.t_integer == null)
					this.t_integer = (IInteger) Services.getPort("t_integer");
				return this.t_integer;
			}
		}

		private IIterator<IInteger> t_iterator = null;
		protected IIterator<IInteger> T_iterator {
			get {
				if (this.t_iterator == null)
					this.t_iterator = (IIterator<IInteger>) Services.getPort("t_iterator");
				return this.t_iterator;
			}
		}

		private IPageNode t_aplicacao_node = null;
		protected IPageNode T_aplicacao_node {
			get {
				if (this.t_aplicacao_node == null)
					this.t_aplicacao_node = (IPageNode) Services.getPort("t_aplicacao_node");
				return this.t_aplicacao_node;
			}
		}

//		private IPageNode t_page_node = null;
//		protected IPageNode T_page_node {
//			get {
//				if (this.t_page_node == null)
//					this.t_page_node = (IPageNode) Services.getPort("t_page_node");
//				return this.t_page_node;
//			}
//		}

		private IPGRank t_pgrank = null;
		protected IPGRank T_pgrank {
			get {
				if (this.t_pgrank == null)
					this.t_pgrank = (IPGRank) Services.getPort("t_pgrank");
				return this.t_pgrank;
			}
		}

		private IString t_string = null;
		protected IString T_string {
			get {
				if (this.t_string == null)
					this.t_string = (IString) Services.getPort("t_string");
				return this.t_string;
			}
		}
	}
}
