using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.mapreduce.example.graph.clique.ReportedClique;

namespace br.ufc.mdcc.mapreduce.example.graph.clique.impl.ReportedCliqueImpl { 
	public class IReportedCliqueImpl : BaseIReportedCliqueImpl, IData{
		public IReportedCliqueImpl() { } 
		override public void initialize(){
			newInstance(); 
		}
		public object newInstance (){
			IReportedCliqueInstance report_clique_instance = new IReportedCliqueInstanceImpl (Items);
			return this.Instance = report_clique_instance;
		}
		private IReportedCliqueInstance instance;
		public object Instance {
			get { return instance;	}
			set { this.instance = (IReportedCliqueInstance) value;	}
		}
	}

	[Serializable]
	public class IReportedCliqueInstanceImpl : IReportedCliqueInstance {
		public IReportedCliqueInstanceImpl(IIterator<IKVPair<IInteger, IIterator<IInteger>>> items){
			this.Items = items;
		}
		#region IReportedCliqueInstance implementation
		private IIterator<IKVPair<IInteger, IIterator<IInteger>>> Items;
		public IIteratorInstance<IKVPair<IInteger, IIterator<IInteger>>> CliqueDataIteratorInstance {
			get { return (IIteratorInstance<IKVPair<IInteger, IIterator<IInteger>>>)Items.Instance; }
		}
		public IKVPairInstance<IInteger, IIterator<IInteger>> CreatePutNewItem {
			get { 
				object o = Items.createItem ();
				((IIteratorInstance<IKVPair<IInteger, IIterator<IInteger>>>)Items.Instance).put(o);
				return (IKVPairInstance<IInteger, IIterator<IInteger>>) o;
			}
		}
		#endregion
	}
}
