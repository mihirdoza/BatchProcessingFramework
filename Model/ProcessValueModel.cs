using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchProcessingFramework.Model
{
    public class ProcessValueModel
    {
        public bool IsLogRequired { get; set; }
        public string DataSetName { get; set; }
        public string PreProcessingMethodName { get; set; }
        public string PostProcessingMethodName { get; set; }
        public string CallBackFunctionName { get; set; }
    }
}
