/* Automatically Generated Code */
using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.mapreduce.Combiner;
using br.ufc.mdcc.mapreduce.user.CombineFunction;

using environment.MPIDirect;

namespace br.ufc.mdcc.mapreduce.impl.CombinerImpl {
    public abstract class BaseITargetCombinerImpl<ORV, O> : Synchronizer, BaseITargetCombiner<ORV, O>
        where ORV : IData
        where O : IData {

        private O target_data = default(O);
        public O Target_data {
            get {
                if (this.target_data == null)
                    this.target_data = (O)Services.getPort("target_data");
                return this.target_data;
            }
        }

        private IIterator<ORV> combine_input_data = null;
        protected IIterator<ORV> Combine_input_data {
            get {
                if (this.combine_input_data == null)
                    this.combine_input_data = (IIterator<ORV>)Services.getPort("combine_input_data");
                return this.combine_input_data;
            }
        }

        ?private ICombineFunction<ORV, O> combine_function = default(ICombineFunction<ORV, O>);
        ?protected ICombineFunction<ORV, O> Combine_function {
        ?    get {
        ?        if (this.combine_function == null)
        ?            this.combine_function = (ICombineFunction<ORV, O>)Services.getPort("combine_function");
        ?        return this.combine_function;
        ?    }
        ?}

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
