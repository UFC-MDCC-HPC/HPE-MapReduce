using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.user.ReduceFunction;
using br.ufc.mdcc.mapreduce.Reducer;

namespace br.ufc.mdcc.mapreduce.impl.ReducerImpl { 

	public class IWorkReducerImpl<OMK, OMV, ORV, R> : 
	BaseIWorkReducerImpl<OMK, OMV, ORV, R>, IReducer<OMK, OMV, ORV, R>
where OMK:IData
where OMV:IData
where ORV:IData
where R:IReduceFunction<ORV, OMK, OMV>
{

public IWorkReducerImpl() { 

} 

public override void main() 
{ 
			/* 1. Ler pares chave (OMK) e valores (OMV) de Input.
			 * 2. Para cada par, atribuir a Key e Values e chamar Reduce_function.go();
			 * 3. Pegar o resultado de Reduction_function.go() de Output_reduce (ORV) 
			 *    e colocar no iterator Output.
			 */
}

}

}
