using BatchProcessingFramework.Entities;
using BatchProcessingFramework.Enums;
using BatchProcessingFramework.Extensions;
using BatchProcessingFramework.Model;
using BatchProcessingFramework.Requests;
using BatchProcessingFramework.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchProcessingFramework
{
    public class BatchRepository
    {
        public long CreateAndGetBatchInstance(string batchprofilename)
        {
            long returnvalue = -1;
            try
            {
                using (var dbContext = new DatabaseContext())
                {
                    var batchInstance = dbContext.BatchInstance.FirstOrDefault(s => s.Name == batchprofilename);
                    var appAP = dbContext.AppAP.FirstOrDefault(s => s.Name == batchprofilename);
                    if (batchInstance != null)
                    {
                        returnvalue = batchInstance.BatchInstanceID;
                    }
                    else
                    {
                        batchInstance = new BatchInstance();
                        batchInstance.AppApID = appAP.ID;
                        batchInstance.Name = batchprofilename;
                        batchInstance.Status = BatchStatus.Open;
                        batchInstance.SortOrder = -1;
                        batchInstance.DataSetsCount = 0;
                        batchInstance.DataSetCloseCount = 0;
                        batchInstance.DataSetErrorCount = 0;
                        batchInstance.IsTaskLogRequired = (appAP != null ? appAP.IsRequired : false);
                        batchInstance.LastUpdated = System.DateTime.Now;
                        batchInstance.ProgressStartDate = null;
                        batchInstance.ProgressEndDate = null;
                        dbContext.BatchInstance.Add(batchInstance);
                        dbContext.SaveChanges();
                        returnvalue = batchInstance.BatchInstanceID;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returnvalue;
        }

        public long CreateAndGetBatchInstanceDataSet(string batchprofilename, object dataset, long? OpenBatchInstanceID, long? existingNodeid)
        {
            long returnvalue = -1;
            try
            {
                var tmpNetZoomMethods = new TempNetZoomMethods();
                // Validate DataSet
                tmpNetZoomMethods.ValidateDataTable(dataset);

                // Prepare Node
                // If(ExistingNodeID = NULL ? NodeID = NZ_AddNewNode(DataSet) : NodeID = ExistingNodeID
                var nodeID = existingNodeid;
                if (nodeID == null)
                {
                    nodeID = tmpNetZoomMethods.NZ_AddNewNode(dataset);
                }

                if (nodeID != null)
                {
                    // Update Node for status
                    tmpNetZoomMethods.NZ_UpdateNodeStatus(nodeID.Value, "Preparing");
                }

                // Prepare Batch 
                // If(OpenBatchID = NULL ? BatchID = AppendBatch(BatchProfile) : BatchID = OpenBatchID
                var batchInstanceID = OpenBatchInstanceID;
                if (batchInstanceID == null)
                {
                    batchInstanceID = this.CreateAndGetBatchInstance(batchprofilename);
                }

                //===========================AppendBatchDataSet====================
                if (nodeID != null && batchInstanceID != null)
                {
                    using (var dbContext = new DatabaseContext())
                    {
                        // Append record to Table: BatchDataSet  for (BatchInstanceID = BatchID, DataSet, NodeID)
                        // Return BatchID
                        var batchInstanceDataSet = dbContext.BatchInstanceDataSet.FirstOrDefault(s => s.BatchInstanceID == batchInstanceID && s.NodeID == nodeID);
                        if (batchInstanceDataSet == null)
                        {
                            batchInstanceDataSet = new BatchInstanceDataSet();
                            batchInstanceDataSet.BatchInstanceID = batchInstanceID.Value;
                            batchInstanceDataSet.NodeID = nodeID.Value;
                            batchInstanceDataSet.DataSet = JsonConvert.SerializeObject(dataset);
                            batchInstanceDataSet.LastUpdated = System.DateTime.Now;
                            dbContext.BatchInstanceDataSet.Add(batchInstanceDataSet);
                            dbContext.SaveChanges();
                            returnvalue = batchInstanceID.Value;
                        }
                    }
                }
                else
                {
                    var exception = new Exception("NodeID or batchInstanceID is null");
                    throw exception;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returnvalue;
        }

        public bool UpdateBatchInstance(BatchInstanceModel batchInstanceModel)
        {
            var returnValue = false;
            try
            {
                using (var dbContext = new DatabaseContext())
                {
                    var batchInstance = dbContext.BatchInstance.FirstOrDefault(s => s.BatchInstanceID == batchInstanceModel.BatchInstanceID);
                    if (batchInstance != null)
                    {
                        batchInstance.Name = batchInstanceModel.Name;
                        batchInstance.SortOrder = batchInstanceModel.BatchInstanceID;
                        batchInstance.DataSetsCount = batchInstanceModel.DataSetsCount;
                        batchInstance.DataSetCloseCount = batchInstanceModel.DataSetCloseCount;
                        batchInstance.DataSetErrorCount = batchInstanceModel.DataSetErrorCount;
                        batchInstance.IsTaskLogRequired = batchInstanceModel.IsTaskLogRequired;
                        batchInstance.LastUpdated = batchInstanceModel.LastUpdated;
                        dbContext.SaveChanges();
                        returnValue = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return returnValue;
        }

        public bool CloseBatchInstance(long batchInstanceID, int datasetCount)
        {
            var returnValue = false;
            try
            {
                using (var dbContext = new DatabaseContext())
                {
                    var batchInstance = dbContext.BatchInstance.FirstOrDefault(s => s.BatchInstanceID == batchInstanceID);
                    if (batchInstance != null)
                    {
                        batchInstance.SortOrder = batchInstance.BatchInstanceID;
                        batchInstance.DataSetsCount = datasetCount;
                        batchInstance.Status = BatchStatus.Closed;
                        batchInstance.LastUpdated = System.DateTime.Now;
                        dbContext.SaveChanges();
                        returnValue = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returnValue;
        }

        public bool DeleteBatchInstance(long batchInstanceID)
        {
            var returnValue = false;
            try
            {
                using (var dbContext = new DatabaseContext())
                {
                    var batchInstance = dbContext.BatchInstance.FirstOrDefault(s => s.BatchInstanceID == batchInstanceID);
                    if (batchInstance != null)
                    {
                        dbContext.BatchInstance.Remove(batchInstance);
                        dbContext.SaveChanges();
                        returnValue = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returnValue;
        }

        public BatchInstance GetBatchInstance(long batchInstanceID)
        {
            BatchInstance returnValue = null;
            try
            {
                using (var dbContext = new DatabaseContext())
                {
                    var batchInstance = dbContext.BatchInstance.FirstOrDefault(s => s.BatchInstanceID == batchInstanceID);
                    if (batchInstance != null)
                    {
                        returnValue = batchInstance;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returnValue;
        }

        public List<BatchInstanceDataSet> GetBatchInstanceDataSet(long batchInstanceID)
        {
            List<BatchInstanceDataSet> returnValue = new List<BatchInstanceDataSet>();
            try
            {
                using (var dbContext = new DatabaseContext())
                {
                    var batchInstance = dbContext.BatchInstanceDataSet.Where(s => s.BatchInstanceID == batchInstanceID).ToList();
                    if (batchInstance != null && batchInstance.Count() > 0)
                    {
                        returnValue = batchInstance;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returnValue;
        }

        public bool HasBatchIsProcessing()
        {
            var returnValue = false;
            try
            {
                using (var dbContext = new DatabaseContext())
                {
                    var batchInstance = dbContext.BatchInstance.OrderBy(s => s.BatchInstanceID).Where(s => s.Status == BatchStatus.Processing).ToList();
                    if (batchInstance != null && batchInstance.Count() > 0)
                    {
                        returnValue = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returnValue;
        }

        public BatchInstance GetTopClosedBatch()
        {
            BatchInstance returnValue = null;
            try
            {
                using (var dbContext = new DatabaseContext())
                {
                    var batchInstance = dbContext.BatchInstance.OrderBy(s =>s.SortOrder).FirstOrDefault(s => s.SortOrder > -1 && s.Status == BatchStatus.Closed);
                    if (batchInstance != null)
                    {
                        returnValue = batchInstance;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returnValue;
        }


        public bool ResetBatchTables()
        {
            var returnValue = false;
            try
            {
                using (var dbContext = new DatabaseContext())
                {
                    var batchInstances = dbContext.Database.SqlQuery<BatchInstance>("exec ResetBatchTables").ToList();
                    if (batchInstances != null && batchInstances.Count() == 0)
                    {
                        returnValue = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returnValue;
        }

        public bool UpdateBatchInstanceSortOrder(long batchInstanceID)
        {
            var returnValue = false;
            try
            {
                using (var dbContext = new DatabaseContext())
                {
                    var batchInstance = dbContext.BatchInstance.FirstOrDefault(s => s.BatchInstanceID == batchInstanceID);
                    if (batchInstance != null)
                    {
                        batchInstance.SortOrder = batchInstance.BatchInstanceID;
                        dbContext.SaveChanges();
                        returnValue = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return returnValue;
        }
    }
}
