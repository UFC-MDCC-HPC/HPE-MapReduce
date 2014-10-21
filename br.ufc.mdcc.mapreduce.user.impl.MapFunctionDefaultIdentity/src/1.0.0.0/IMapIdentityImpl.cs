using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.user.MapFunction;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Iterator;
using System.Diagnostics;

namespace br.ufc.mdcc.mapreduce.user.impl.MapFunctionDefaultIdentity 
{ 

	public class IMapIdentityImpl<IMK, IMV, OMK, OMV> : BaseIMapIdentityImpl<IMK, IMV, OMK, OMV>, IMapFunction<IMK, IMV, OMK, OMV>
		where IMK:IData
		where IMV:IData
		where OMV:IData
		where OMK:IData
	{
			
		public override void main() 
		{ 
			Trace.WriteLine (Rank + ": MAP FUNCTION IDENTITY #1 " + Output_data.Instance.GetType());

			IIteratorInstance<IKVPair<OMK, OMV>> output = (IIteratorInstance<IKVPair<OMK, OMV>>)Output_data.Instance;

			object test = Output_data.createItem ();

			Trace.WriteLine (Rank + ": MAP FUNCTION IDENTITY #3" + test.GetType());

			IKVPairInstance<IMK, IMV> kvpair = (IKVPairInstance<IMK, IMV>) Output_data.createItem ();

			Trace.WriteLine (Rank + ": MAP FUNCTION IDENTITY #4" + " - " +  Input_key.Instance.GetType());

			kvpair.Key = Input_key.Instance;
			kvpair.Value = Input_value.Instance;
			output.put (kvpair);
		
		}
	
	}

}
