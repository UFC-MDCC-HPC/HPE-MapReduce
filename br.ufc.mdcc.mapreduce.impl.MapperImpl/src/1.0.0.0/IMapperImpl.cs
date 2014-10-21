using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.user.MapFunction;
using br.ufc.mdcc.mapreduce.Mapper;
using br.ufc.mdcc.common.KVPair;
using System.Threading.Tasks;
using br.ufc.mdcc.common.Iterator;
using System.Diagnostics;

namespace br.ufc.mdcc.mapreduce.impl.MapperImpl { 

public class IMapperImpl<IMK, IMV, OMK, OMV, M> : BaseIMapperImpl<IMK, IMV, OMK, OMV, M>, IMapper<IMK, IMV, OMK, OMV, M>
	where IMK:IData
    where IMV:IData
    where OMK:IData
    where OMV:IData
	where M:IMapFunction<IMK, IMV, OMK, OMV> 
	{
        public IMapperImpl() { } 

	    public override void main() 
		{ 
			IIteratorInstance<IKVPair<IMK,IMV>> input_instance = (IIteratorInstance<IKVPair<IMK,IMV>>) Input.Instance;
			IIteratorInstance<IKVPair<OMK,OMV>> output_instance = (IIteratorInstance<IKVPair<OMK,OMV>>) Output.Instance;

			object bin_object = null;

			int count=0;
			while (input_instance.fetch_next(out bin_object))
			{
				Trace.WriteLine(Rank + ": LOOP MAPPER !!!" + (count++));
				IKVPairInstance<IMK,IMV> bin = (IKVPairInstance<IMK,IMV>) bin_object;
				Trace.WriteLine (Rank + ": " + (Map_value.Instance == null) + " $$$$ " +  bin.Value.GetType());

				Map_key.Instance = bin.Key;
				Map_value.Instance = bin.Value;

				Map_function.go ();
			}

			Trace.WriteLine(Rank + ": FINISH MAPPER !!!");

			output_instance.finish();

    	}
    }
}
