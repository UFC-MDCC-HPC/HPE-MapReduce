using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.Shuffler;

namespace br.ufc.mdcc.mapreduce.impl.ShufflerImpl { 

public class ISourceShufflerImpl<OMK> : BaseISourceShufflerImpl<OMK>, ISourceShuffler<OMK>
where OMK:IData
{

public ISourceShufflerImpl() { 

} 

public override void main()
{
			/* 1. Ler os pares de chaves (OMK, OPK) de Source_data
			 * 2. Enviar cada chave OMK para o reducer (unidade target)
			 *    determinada pela chave OPK.
			 */

}

}

}
