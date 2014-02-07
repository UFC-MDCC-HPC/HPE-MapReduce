using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.Combiner;

namespace br.ufc.mdcc.mapreduce.impl.CombinerImpl { 

	public class ITargetCombinerImpl<ORV,O> : BaseITargetCombinerImpl<ORV,O>, ITargetCombiner<ORV,O>
		where O:IData
		where ORV:IData
{

public ITargetCombinerImpl() { 

} 

public override void main() { 

}

}

}
