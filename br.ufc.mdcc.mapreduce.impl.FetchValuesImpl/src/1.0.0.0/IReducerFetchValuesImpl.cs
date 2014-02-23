using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.mapreduce.FetchValues;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.KVPair;

namespace br.ufc.mdcc.mapreduce.impl.FetchValuesImpl { 

	public class IReducerFetchValuesImpl<OMK,OMV> : BaseIReducerFetchValuesImpl<OMK,OMV>, IFetchValuesReducer<OMK,OMV>
		where OMK:IData
		where OMV:IData
		{

		public IReducerFetchValuesImpl() { 

		} 

		public override void main() 
		{ 

		}
	}
}
