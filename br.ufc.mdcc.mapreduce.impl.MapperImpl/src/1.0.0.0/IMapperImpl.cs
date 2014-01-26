using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.user.MapFunction;
using br.ufc.mdcc.mapreduce.Mapper;

namespace br.ufc.mdcc.mapreduce.impl.MapperImpl { 

public class IMapperImpl<IMK, IMV, OMK, OMV, M> : BaseIMapperImpl<IMK, IMV, OMK, OMV, M>, IMapper<IMK, IMV, OMK, OMV, M>
where IMK:IData
where IMV:IData
where OMK:IData
where OMV:IData
where M:IMapFunction<IMK, IMV, OMK, OMV>
{

	public IMapperImpl() { 

	} 

	public override void main() { 

	}


}

}
