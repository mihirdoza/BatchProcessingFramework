using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchProcessingFramework
{
    public class ApplicationRepository
    {
        public bool IsProfileExists(string batchprofilename)
        {
            var returnvalue = false;
            try
            {
                using (var dbContext = new DatabaseContext())
                {
                    var appAP = dbContext.AppAP.FirstOrDefault(s => s.Name == batchprofilename);
                    if (appAP != null)
                    {
                        returnvalue = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returnvalue;
        }
    }
}
