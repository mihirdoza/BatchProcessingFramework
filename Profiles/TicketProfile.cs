using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchProcessingFramework.Profiles
{
    public class TicketProfile : IProfile
    {
        public List<TicketProfile> Data { get; set; }

        public override int BatchOperation(int batchInstanceID, string action, int neworder)
        {
            throw new NotImplementedException();
        }

        public override int NZ_FinalizeNodeFor(string profileName, DataTable dataset)
        {
            throw new NotImplementedException();
        }

        public override int NZ_PreBatchNodeFor(string profileName, DataTable dataset)
        {
            throw new NotImplementedException();
        }
    }
}
