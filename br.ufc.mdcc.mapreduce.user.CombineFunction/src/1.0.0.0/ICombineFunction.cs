using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.mapreduce.user.CombineFunction 
{ 
	public interface ICombineFunction<ORV, Out> : BaseICombineFunction<ORV, Out>
		where ORV:IData
		where Out:IData
		{


		} // end main interface 

} // end namespace 
