using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.mapreduce.user.SplitFunction 
{ 
	public interface ISplitFunction<IMAP, IMK, IMV> : BaseISplitFunction<IMAP, IMK, IMV>
		where IMAP:IData
		where IMK:IData
		where IMV:IData
		{


		} // end main interface 

} // end namespace 
