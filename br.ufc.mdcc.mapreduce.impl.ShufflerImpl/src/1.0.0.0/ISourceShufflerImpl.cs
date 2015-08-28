using System;
using System.Threading;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.Shuffler;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.Integer;
using System.Collections.Generic;

namespace br.ufc.mdcc.mapreduce.impl.ShufflerImpl {
    public class ISourceShufflerImpl<OMK>: BaseISourceShufflerImpl<OMK>, ISourceShuffler<OMK>
    where OMK: IData {

        private MPI.Intracommunicator comm;
		static private int TAG_SHUFFLER_OMV = 445;
		static private int TAG_SHUFFLER_OMV_FINISH = 446;
        private int gerente = 0;
        
        public ISourceShufflerImpl() {   }

		override public void after_initialize()
		{
			// Inicializar o comunicador MPI. 
			comm = this.Communicator;
		}

        public override void main() 
		{
        }

    }
}
