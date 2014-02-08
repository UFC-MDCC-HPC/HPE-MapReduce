/* Automatically Generated Code */
using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Integer;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.mapreduce.Shuffler;
using environment.MPIDirect;

namespace br.ufc.mdcc.mapreduce.impl.ShufflerImpl {
    public abstract class BaseISourceShufflerImpl<OMK>: Synchronizer, BaseISourceShuffler<OMK> where OMK: IData {

        private IIterator<IKVPair<OMK, IInteger>> source_data = null;
        public IIterator<IKVPair<OMK, IInteger>> Source_data {
            get {
                if (this.source_data == null)
                    this.source_data = (IIterator<IKVPair<OMK, IInteger>>)Services.getPort("source_data");
                return this.source_data;
            }
        }

        private IMPIDirect mpi_comm = null;
        protected IMPIDirect Mpi_comm {
            get {
                if (this.mpi_comm == null) {
                    this.mpi_comm = (IMPIDirect)Services.getPort("mpi_comm");
                }
                return this.mpi_comm;
            }
        }
    }
}
