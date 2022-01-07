using BatchProcessingFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchProcessingFramework.Model
{
    public class BatchInstanceDataSetModel
    {
        public long BatchInstanceDataSetID { get; set; }
        public long BatchInstanceID { get; set; }
        public long NodeID { get; set; }
        public string HintsToProcess { get; set; }
        public string DataSet { get; set; }
        public string Status { get; set; }
        public DateTime LastUpdated { get; set; }

        public BatchInstanceModel BatchInstance { get; set; }

        public BatchInstanceDataSetModel GetBatchInstanceDataSetModel(BatchInstanceDataSet batchInstanceDataSet)
        {
            var returnValue = new BatchInstanceDataSetModel();
            returnValue.BatchInstanceDataSetID = batchInstanceDataSet.BatchInstanceDataSetID;
            returnValue.BatchInstanceID = batchInstanceDataSet.BatchInstanceID;
            returnValue.NodeID = batchInstanceDataSet.NodeID;
            returnValue.HintsToProcess = batchInstanceDataSet.HintsToProcess;
            returnValue.DataSet = batchInstanceDataSet.DataSet;
            returnValue.Status = batchInstanceDataSet.Status;
            returnValue.LastUpdated = batchInstanceDataSet.LastUpdated;
            var BatchInstanceModel = new BatchInstanceModel();
            returnValue.BatchInstance = BatchInstanceModel.GetBatchInstanceModel(batchInstanceDataSet.BatchInstance);
            return returnValue;
        }
    }
}
