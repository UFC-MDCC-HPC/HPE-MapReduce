using br.ufc.pargo.hpe.kinds;
using br.ufc.mdcc.common.Data;

namespace br.ufc.mdcc.mapreduce.partitioner.FeedPartitioning { 

public interface IFeedPartitioning<OMK, OPK, OMV> : BaseIFeedPartitioning<OMK, OPK, OMV>
where OMK:IData
where OPK:IData
where OMV:IData
{

  // prepare the next data key to the partition function.
  void send_data_key();
  
  // read the partition_key calculated by the partition_function
  void recv_partition_key();

  // betweeen send_data_key and recv_partition_key, the partition_function is executed.


} // end main interface 

} // end namespace 
