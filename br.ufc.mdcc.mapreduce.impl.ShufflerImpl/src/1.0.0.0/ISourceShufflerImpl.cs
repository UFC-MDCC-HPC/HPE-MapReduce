using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.Shuffler;

namespace br.ufc.mdcc.mapreduce.impl.ShufflerImpl { 

public class ISourceShufflerImpl<OMK, OPK> : BaseISourceShufflerImpl<OMK, OPK>, ISourceShuffler<OMK, OPK>
where OMK:IData
where OPK:IData
{

public ISourceShufflerImpl() { 

} 

public override void main()
{
}

}

}
