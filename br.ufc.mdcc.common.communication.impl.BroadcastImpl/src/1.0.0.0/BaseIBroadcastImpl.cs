/* Automatically Generated Code */

using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.communication.Broadcast;

namespace br.ufc.mdcc.common.communication.impl.BroadcastImpl { 

public abstract class BaseIBroadcastImpl<T>: Synchronizer, BaseIBroadcast<T>
where T:IData
{

private T data = default(T);

protected T Data {
	get {
		if (this.data == null)
			this.data = (T) Services.getPort("data");
		return this.data;
	}
}



}

}
