using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.splitter.ScatterSplitData;

namespace br.ufc.mdcc.mapreduce.splitter.impl.ScatterSplitDataImpl { 

public class ISourceScatterSplitDataImpl<IMK, IMV> : BaseISourceScatterSplitDataImpl<IMK, IMV>, ISourceScatterSplitData<IMK, IMV>
where IMK:IData
where IMV:IData
{

public ISourceScatterSplitDataImpl() { 

} 

public override void main() 
{ 

	
}

}

}
