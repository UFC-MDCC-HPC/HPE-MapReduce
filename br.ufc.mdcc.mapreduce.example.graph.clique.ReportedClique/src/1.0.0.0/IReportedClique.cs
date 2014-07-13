using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.KVPair;

namespace br.ufc.mdcc.mapreduce.example.graph.clique.ReportedClique { 
	public interface IReportedClique : BaseIReportedClique, IData{
	} // end main interface 
	public interface IReportedCliqueInstance{
		IKVPairInstance<IInteger, IIterator<IInteger>> CreatePutNewItem { get; }
		IIteratorInstance<IKVPair<IInteger, IIterator<IInteger>>> CliqueDataIteratorInstance { get; }
	}
} // end namespace 
