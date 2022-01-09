using System;
using System.Json;

namespace BatchProcessingFramework.Profiles
{
    public class EvenNumber
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