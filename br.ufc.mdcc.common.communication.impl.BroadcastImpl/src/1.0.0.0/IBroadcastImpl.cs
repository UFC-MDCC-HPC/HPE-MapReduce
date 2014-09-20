using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.common.communication.Broadcast;

namespace br.ufc.mdcc.common.communication.impl.BroadcastImpl 
{ 

	public class IBroadcastImpl<T> : BaseIBroadcastImpl<T>, IBroadcast<T>
	where T:IData
	{
		private int root = 0;
		private MPI.Intracommunicator comm = null;

		override public void initialize()
		{
			// Inicializar o comunicador MPI. 
			comm = this.Communicator;
		}

		public override void main() 
		{ 
			object value = Data.Instance;

			Console.WriteLine (Rank + ": BEGIN BROADCAST RECV");
			comm.Broadcast(ref value, root);
			Console.WriteLine (Rank + ": END BROADCAST RECV - " + value + " --- "+ Data.Instance.GetHashCode());

			Data.Instance = value;
		}

		public int Root { set { this.root = value; } }
	}

}
