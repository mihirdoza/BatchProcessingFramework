using BatchProcessingFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchProcessingFramework.Model
{
    public class BatchInstanceModel
    {
        public long BatchInstanceID { get; set; }
        public long SortOrder { get; set; }
        public int AppApID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Progress { get; set; }
        public string Status { get; set; }
        public bool IsTaskLogRequired { get; set; }
        public int DataSetsCount { get; set; }
        public int DataSetCloseCount { get; set; }
        public int DataSetErrorCount { get; set; }
        public DateTime LastUpdated { get; set; }

        public ServiceModel AppAp { get; set; }

        public BatchInstanceModel GetBatchInstanceModel(BatchInstance BatchInstance)
        {
            var returnValue = new BatchInstanceModel();
            returnValue.BatchInstanceID = BatchInstance.BatchInstanceID;
            returnValue.IsTaskLogRequired = BatchInstance.IsTaskLogRequired;
            returnValue.Name = BatchInstance.Name;
            returnValue.Description = BatchInstance.Description;
            returnValue.Status = BatchInstance.Status;
            returnValue.LastUpdated = BatchInstance.LastUpdated;
            returnValue.Progress = BatchInstance.Progress;
            returnValue.DataSetsCount = BatchInstance.DataSetsCount;
            returnValue.SortOrder = BatchInstance.SortOrder;
            returnValue.DataSetCloseCount= BatchInstance.DataSetCloseCount;
            returnValue.DataSetErrorCount = BatchInstance.DataSetErrorCount;
            returnValue.AppApID = BatchInstance.AppApID;
            var serviceModel = new ServiceModel();
            returnValue.AppAp = serviceModel.GetServiceModel(BatchInstance.AppAp);

            return returnValue;
        }
    }
}
