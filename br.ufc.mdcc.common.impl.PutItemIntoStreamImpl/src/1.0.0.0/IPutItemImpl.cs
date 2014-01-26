using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.PutItemIntoStream;

namespace br.ufc.mdcc.common.impl.PutItemIntoStreamImpl { 

public class IPutItemImpl<T> : BaseIPutItemImpl<T>, IPutItemIntoStream<T>
where T:IData
{

public IPutItemImpl() { 

} 

public override void main() { 

}

}

}
