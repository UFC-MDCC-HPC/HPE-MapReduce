using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;
using System;

namespace br.ufc.mdcc.mapreduce.example.graph.sssp.fast.PathInfo 
{ 
	public interface IPathInfo : BaseIPathInfo, IData
	{
		//IPathInfoEdgeInstance newInstance (EdgeInfo edge_info);
		//IPathInfoDistanceInstance newInstance (DistanceInfo distance_info);
	} // end main interface 


	[Serializable]
	public class Info
	{
		public const int PATH_INFO_TYPE_EDGE = 1;
		public const int PATH_INFO_TYPE_DISTANCE_TRIAL = 2;      // 'c'
		public const int PATH_INFO_TYPE_DISTANCE_PARTIAL = 3;    // 'd'
		public int info_type;
		public int vertex;
	}

	[Serializable]
	public class EdgeInfo : Info
	{
		public int vertex_other;
		public int weight;
		public override string ToString() { return "EDGE_" + info_type + "(vertex=" + this.vertex + ",vertex_other=" + this.vertex_other + ",weight=" + this.weight + ")"; }
	}

	[Serializable]
	public class DistanceInfo : Info
	{
		public int distance;
		public override string ToString() { return "DISTANCE_" + info_type + "(vertex=" + this.vertex + ",distance=" + this.distance + ")"; }
	}

	public interface IPathInfoInstance : ICloneable
	{
		Info Value { set; get; }
	}


} // end namespace 
