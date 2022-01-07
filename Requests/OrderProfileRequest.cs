using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//{ profilename: "order",
//  data:[ { orderName:"order", orderValue="243"},
//     { orderName: "order", orderValue= "243"}
//        ]}

namespace BatchProcessingFramework.Requests
{
    public class OrderProfileRequest : BaseRequest, IProfileRequest<OrderRequest>
    {
        public OrderProfileRequest(string data)
        {
            this.Data = JsonConvert.DeserializeObject<List<OrderRequest>>(data);
        }

        public List<OrderRequest> Data { get; set; }
    }

    public class OrderRequest
    {
        public string OrderName { get; set; }
        public int OrderValue { get; set; }
    }
}
