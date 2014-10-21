using System;
using br.ufc.pargo.hpe.backend.DGAC;
using br.ufc.pargo.hpe.basic;
using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using br.ufc.mdcc.mapreduce.example.graph.sssp.fast.PathInfo;
using System.Diagnostics;

namespace br.ufc.mdcc.mapreduce.example.graph.sssp.fast.impl.PathInfoImpl { 

	public class IPathInfoImpl : BaseIPathInfoImpl, IPathInfo
	{
		private IPathInfoImplInstance instance;

		override public void initialize()
		{
			newInstance(); 
			Trace.WriteLine ("********* INITIALIZE PATH INFO IMPL : " + (this.Instance == null) + " --- "+ this.CID);
		}

		#region IData implementation
		public object newInstance ()
		{
			this.instance = new IPathInfoImplInstance ();
			return this.instance;
		}

		public object Instance {
			get { return this.instance; }
			set { this.instance = (IPathInfoImplInstance) value; }
		}
		#endregion

	}


	[Serializable]
	public class IPathInfoImplInstance : IPathInfoInstance
	{
		private Info info;

		public IPathInfoImplInstance()
		{

		}

		#region IPathInfoInstance implementation

		public Info Value {
			get { return info;	}
			set { this.info = value; }
		}

		#endregion

		#region ICloneable implementation

		public object Clone ()
		{
			IPathInfoInstance clone = new IPathInfoImplInstance();
			clone.Value = this.Value;
			return clone;
		}

		#endregion
	}



	/*[Serializable]
	public class IPathInxxxfoImplInstance : IPathInfoInstance
	{
		#region IPathInfoInstance implementation


		public override int GetHashCode ()
		{
			return Value.GetHashCode();	
		}

		public override string ToString ()
		{
			return Value.ToString();
		}

		public override bool Equals (object obj)
		{
			if (obj is IPathInfoInstance)
				return Value==(((IPathInfoInstance) obj).Value);
			else if (obj is int)
				return Value==(int)obj;
			else
				return false;
		}

		#endregion
	}*/
}
