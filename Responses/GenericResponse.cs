using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchProcessingFramework.Responses
{
    public class GenericResponse<T> where T : class
    {
        public T Data { get; set; }
        public bool HasError { get; set; }
        public string ErrorMessage { get; set; }
        public Exception Exception { get; set; }
    }
}
