using BatchProcessingFramework.Requests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchProcessingFramework.Profiles
{
    public class OrderProfile : IProfile
    {
        public List<OrderRequest> Data { get; set; }

        public OrderProfile(string data)
        {
            this.Data = JsonConvert.DeserializeObject<List<OrderRequest>>(data);
        }

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
