using BatchProcessingFramework.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchProcessingFramework.Requests
{
    public class BaseRequest
    {
        public string profileName { get; set; }
        public string DataString { get; set; }
    }
}
