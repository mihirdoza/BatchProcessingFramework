using System;
using System.Collections.Generic;
using System.Data;
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
    }
}
