using BatchProcessingFramework.Requests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchProcessingFramework.Profiles
{
    public class OrderProfile
    {
        public int BatchOperation(int batchInstanceID, string action, int neworder)
        {
            throw new NotImplementedException();
        }

        public int NZ_FinalizeNodeFor(long nodeID)
        {
            throw new NotImplementedException();
        }

        public int NZ_PreBatchNodeFor(string profileName, JsonValue dataset)
        {
            throw new NotImplementedException();
        }
    }
}
