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
        public IProfile profile
        {
            get
            {
                switch (this.profileName)
                {
                    case "order":
                        return new OrderProfile(DataString);

                    default:
                        return null;
                }
            }
        }
        //public IProfileRequest Records
        //{
        //    get
        //    {
        //        switch (this.profileName)
        //        {
        //            case "order":
        //                return new OrderProfileRequest(DataString);

        //            case "ticket":
        //                return new TicketProfileRequest(DataString);

        //            default:
        //                return null;
        //        }
        //    }
        //}
    }
}
