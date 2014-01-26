using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.Combiner;

namespace br.ufc.mdcc.mapreduce.impl.CombinerImpl { 

public class ISourceCombinerImpl<ORV> : BaseISourceCombinerImpl<ORV>, ISourceCombiner<ORV>
where ORV:IData
{

public ISourceCombinerImpl() { 

} 

		public override void main() { 

		}

}

}
