using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchProcessingFramework.Requests
{
    //public class TicketProfileRequest : BaseRequest, IProfileRequest<TicketProfileRequest>
    public class TicketProfileRequest : BaseRequest
    {
        public TicketProfileRequest(string data)
        {
           
        }
        public string TicketStatus { get; set; }
        public string TicketName { get; set; }
    }
}
