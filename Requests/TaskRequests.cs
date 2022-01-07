using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchProcessingFramework.Requests
{
    public class ServiceRequests
    {
        public string Action { get; set; }
        public string ServiceName { get; set; }
        public string TimeGranularity { get; set; }
    }
}
