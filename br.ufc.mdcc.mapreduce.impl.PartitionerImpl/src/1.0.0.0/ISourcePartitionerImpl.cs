using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.user.PartitionFunction;
using br.ufc.mdcc.mapreduce.Partitioner;
using environment.MPIDirect;
using br.ufc.mdcc.common.KVPair;
using System.Collections.Generic;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.Iterator;

// Essa é a unidade Mapper. Existem várias.
// Criar uma thread em para ler Source_data elemento a elemento e enviar para o target.
using System.Threading.Tasks;


namespace br.ufc.mdcc.mapreduce.impl.PartitionerImpl 
{ 
	public class ISourcePartitionerImpl<OMK, OMV, P> : BaseISourcePartitionerImpl<OMK, OMV, P>, ISourcePartition<OMK, OMV, P>
    where OMK:IData
    where OMV:IData
	where P:IPartitionFunction<OMK> 
	{
		// Variáveis do Ambiente MPI.
		private MPI.Intracommunicator comm = null;

		public ISourcePartitionerImpl() { } 

		override public void initialize()
		{
			// Inicializar o comunicador MPI. 
			comm = this.Communicator;
		}

		public override void main() 
		{
			Fetch_values.go ();
		}
    }
}
