using System;
using System.Collections.Generic;

namespace graph {
    public interface IRank:IData {
        IDouble Rank { get; set; }
        IDouble Error { get; }
    }
}
