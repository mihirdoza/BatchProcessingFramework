using System;
using System.Collections.Generic;
using System.Data;
using System.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchProcessingFramework
{
    public class TempNetZoomMethods
    {
        public bool ValidateDataTable(object dataset)
        {
            return true;
        }

        public long NZ_AddNewNode(object dataset)
        {
            return new Random().Next(1,10000);
        }
        public bool NZ_UpdateNodeStatus(long nodeID, string status)
        {
            return true;
        }
        public bool NZ_PreBatchNodeFor(string profilename,object rowDataSet)
        {
            return true;
        }

        public bool NZ_FinalizeNodeFor(long nodeID)
        {
            return true;
        }
        public bool NZ_ValidateDataSets(JsonArray datasets)
        {
            return true;
        }
    }
}
