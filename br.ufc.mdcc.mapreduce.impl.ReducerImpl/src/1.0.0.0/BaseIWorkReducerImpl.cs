/* Automatically Generated Code */
using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Iterator;
using br.ufc.mdcc.common.KVPair;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.user.ReduceFunction;
using br.ufc.mdcc.mapreduce.Reducer;

namespace br.ufc.mdcc.mapreduce.impl.ReducerImpl {
    public abstract class BaseIWorkReducerImpl<OMK, OMV, ORV, R> : Computation, BaseIReducer<OMK, OMV, ORV, R>
        where OMK : IData
        where OMV : IData
        where ORV : IData
        where R : IReduceFunction<OMK, OMV, ORV> {

        private IIterator<IKVPair<OMK, IIterator<OMV>>> input = null;
        public IIterator<IKVPair<OMK, IIterator<OMV>>> Input {
            get {
                if (this.input == null)
                    this.input = (IIterator<IKVPair<OMK, IIterator<OMV>>>)Services.getPort("input");
                return this.input;
            }
        }

   
        private IIterator<ORV> output = null;
        public IIterator<ORV> Output {
            get {
                if (this.output == null)
                    this.output = (IIterator<ORV>)Services.getPort("output");
                return this.output;
            }
        }

        private R reduce_function = default(R);
        protected R Reduce_function {
            get {
                if (this.reduce_function == null)
                    this.reduce_function = (R)Services.getPort("reduce_function");
                return this.reduce_function;
            }
        }

		private IKVPair<OMK, IIterator<OMV>> input_reduce = null;
		protected IKVPair<OMK, IIterator<OMV>> Input_reduce {
			get {
				if (this.input_reduce == null)
					this.input_reduce = (IKVPair<OMK, IIterator<OMV>>)Services.getPort("input_reduce");
				return this.input_reduce;
			}
		}

		private ORV output_reduce = default(ORV);
		protected ORV Output_reduce {
            get {
				if (this.output_reduce == null)
					this.output_reduce = (ORV)Services.getPort("output_reduce");
				return this.output_reduce;
            }
        }

   
    }
}
