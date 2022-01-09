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
    public class OddNumber
    {
        public int BatchOperation(int batchInstanceID, string action, int neworder)
        {
            return 101;
        }

        public int NZ_FinalizeNodeFor(long nodeID)
        {
            return 101;
        }

        public int NZ_PreBatchNodeFor(string profileName, JsonValue dataset)
        {
            return 101;
        }
    }
}
