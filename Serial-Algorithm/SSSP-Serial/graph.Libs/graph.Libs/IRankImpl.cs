using System;
using System.Collections.Generic;

namespace graph {
    public class IRankImpl: IRank {
        IDouble rank = new IDoubleImpl();
        IDouble error = new IDoubleImpl();
        public IRankImpl() {
            rank.Value = 1.0;
            error.Value = 0;
        }
        public IDouble Rank {
            get { return rank; }
            set {
                error.Value = (value.Value - rank.Value);
                rank = value;
            }
        }
        public IDouble Error { get { return error; } }

        public void loadFrom(IData o) {
            IRank i = (IRank)o;
            this.Rank = i.Rank;
        }
        public IData newInstance() {
            return new IRankImpl();
        }
        public IData clone() {
            IData instance = newInstance();
            instance.loadFrom(this);
            return instance;
        }
    }
}
