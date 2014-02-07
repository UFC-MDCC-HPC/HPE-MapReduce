using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.mapreduce.user.CombineFunction 
{ 
	public interface ICombineFunction<ORV, O> : BaseICombineFunction<ORV, O>
		where ORV:IData
		where O:IData
		{


		} // end main interface 

} // end namespace 
