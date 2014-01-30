using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.splitter.ScatterSplitData;

namespace br.ufc.mdcc.mapreduce.splitter.impl.ScatterSplitDataImpl { 

public class ITargetScatterSplitDataImpl<IMK, IMV> : BaseITargetScatterSplitDataImpl<IMK, IMV>, ITargetScatterSplitData<IMK, IMV>
where IMK:IData
where IMV:IData
{

public ITargetScatterSplitDataImpl() { 

} 

public override void main() { 

			// 1. recebe os bins enviados pelo gerente (unidade source),
			//    através do MPI, e os insere no Target_data.

}

}

}
