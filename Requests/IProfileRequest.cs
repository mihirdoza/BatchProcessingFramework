using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchProcessingFramework.Requests
{
    ////public interface IProfileRequest<T> where T : class
    ////{
    ////    List<T> Data { get; set; }
    ////}
    public interface IProfileRequest<T> where T : class
    {
        List<T> Data { get; set; }
    }
}
