using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.example.graph.pagerank.PGRank;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.mapreduce.example.graph.pagerank.impl.PGRankImpl { 

public class IPGRankImpl : BaseIPGRankImpl, IData
{
private double pgrank;
private double error;

public IPGRankImpl() { 
			pgrank = 1.0;
			error = 0.0;
} 
        public double Value {
        	get { return pgrank; }
            set {
				error = (value - pgrank);
				pgrank = value;
            }
        }
        public double Error { get { return error; } }
        
        public void loadFrom(IData o) {
            IPGRank i = (IPGRank)o;
			this.Value = i.Value;
			error = i.Error;
        }
        public IData newInstance() {
            return new IPGRankImpl();
        }
        public IData clone() {
            IData instance = newInstance();
            instance.loadFrom(this);
            return instance;
        }


}

}
