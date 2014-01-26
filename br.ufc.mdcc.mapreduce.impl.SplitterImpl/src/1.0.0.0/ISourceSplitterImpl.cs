using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.user.SplitFunction;
using br.ufc.mdcc.mapreduce.Splitter;

namespace br.ufc.mdcc.mapreduce.impl.SplitterImpl { 

public class ISourceSplitterImpl<I, IMK, IMV, Sf> : 
	BaseISourceSplitterImpl<I, IMK, IMV, Sf>, ISourceSplitter<I, IMK, IMV, Sf>
where I:IData
where IMK:IData
where IMV:IData
where Sf:ISplitFunction<I, IMK, IMV>
{

public ISourceSplitterImpl() { 

} 

public override void main() { 

}

}

}
