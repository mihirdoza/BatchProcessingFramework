using BatchProcessingFramework.Requests;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Json;
using BatchProcessingFramework.Enums;

namespace BatchProcessingFramework.Profiles
{
    public class BaseProfile
    {

        public void ProcessProfile(BaseRequest request)
        {
            try
            {
                var jsonArray = new JsonArray(request.DataString);
                long? batchId = null;
                long? nodeId = null;
                var batchRepository = new BatchRepository();
                if (jsonArray.Count > 0)
                {
                    var tmpNetZoomMethods = new TempNetZoomMethods();

                    // Validate DataSet
                    if (tmpNetZoomMethods.ValidateDataTable(jsonArray))
                    {
                        foreach (var row in jsonArray)
                        {
                            // call the prebatch processing method here
                            if (request.profileName == "order")
                            {
                                var orderProfile = new OrderProfile();
                                nodeId = orderProfile.NZ_PreBatchNodeFor(request.profileName, row);
                            }
                            else if (request.profileName == "ticket")
                            {
                                var ticketProfile = new TicketProfile();
                                nodeId = ticketProfile.NZ_PreBatchNodeFor(request.profileName, row);
                            }
                            else if (request.profileName == "odd")
                            {
                                var oddNumber = new OddNumber();
                                oddNumber.NZ_PreBatchNodeFor(request.profileName, row);
                            }
                            else if (request.profileName == "even")
                            {
                                var evenNumber = new EvenNumber();
                                evenNumber.NZ_PreBatchNodeFor(request.profileName, row);
                            }
                            else if (request.profileName == "capalpha")
                            {
                                var capitalAlpha = new CapitalAlpha();
                                capitalAlpha.NZ_PreBatchNodeFor(request.profileName, row);
                            }

                            //==============Add DataSet for Batch====================
                            batchId = batchRepository.CreateAndGetBatchInstanceDataSet(request.profileName, row, batchId, nodeId);
                        }

                        //====================CloseBatch(BatchID)====================
                        if (batchId != null)
                        {
                            batchRepository.CloseBatchInstance(batchId.Value, jsonArray.Count);
                        }

                        this.TriggerBatchProcessing();
                    }
                    else
                    {
                        var invalidDataSetError = new Exception("The given dataset is invalid");
                        if (batchId != null)
                        {
                            //  batchRepository.DeleteBatchInstance(batchId.Value);
                        }
                        throw invalidDataSetError;
                    }
                }
                else
                {
                    var emptyArrayErrorException = new Exception("The given array is empty cannot processed the batch.");
                    if (batchId != null)
                    {
                        // batchRepository.DeleteBatchInstance(batchId.Value);
                    }
                    throw emptyArrayErrorException;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void StartBatchProcessing(long batchID)
        {
            try
            {
                var batchInstanceRepository = new BatchRepository();
                var batchInstance = batchInstanceRepository.GetBatchInstance(batchID);
                // Need to confirm about the BatchStatus value to validate that Batch is pending
                if (batchInstance != null && batchInstance.Status != BatchStatus.Finished)
                {
                    using (var dbContext = new DatabaseContext())
                    {
                        batchInstance.Status = BatchStatus.Processing;
                        batchInstance.ProgressStartDate = DateTime.Now;
                        batchInstance.LastUpdated = DateTime.Now;
                        dbContext.SaveChanges();
                        var batchDataSets = batchInstanceRepository.GetBatchInstanceDataSet(batchID);
                        foreach (var item in batchDataSets)
                        {
                            if (batchInstance.Name == "order")
                            {
                                var orderProfile = new OrderProfile();
                                orderProfile.NZ_FinalizeNodeFor(item.NodeID);
                            }
                            else if (batchInstance.Name == "ticket")
                            {
                                var ticketProfile = new TicketProfile();
                                ticketProfile.NZ_FinalizeNodeFor(item.NodeID);
                            }
                            else if (batchInstance.Name == "odd")
                            {
                                var oddNumber = new OddNumber();
                                oddNumber.NZ_FinalizeNodeFor(item.NodeID);
                            }
                            else if (batchInstance.Name == "even")
                            {
                                var evenNumber = new EvenNumber();
                                evenNumber.NZ_FinalizeNodeFor(item.NodeID);
                            }
                            else if (batchInstance.Name == "capalpha")
                            {
                                var capitalAlpha = new CapitalAlpha();
                                capitalAlpha.NZ_FinalizeNodeFor(item.NodeID);
                            }
                        }
                        batchInstance.Status = BatchStatus.Finished;
                        batchInstance.ProgressEndDate = DateTime.Now;
                        batchInstance.DataSetCloseCount = batchDataSets.Where(d => d.Status == BatchDataSetStatus.Closed).Count();
                        batchInstance.DataSetErrorCount = batchDataSets.Where(d => d.Status == BatchDataSetStatus.Error).Count();
                        batchInstance.LastUpdated = DateTime.Now;
                        batchInstance.SortOrder = batchID;
                        dbContext.SaveChanges();
                    }
                    this.TriggerBatchProcessing();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void TriggerBatchProcessing()
        {
            var batchRepository = new BatchRepository();
            var hasAnyActiveBatch = batchRepository.HasBatchIsProcessing();
            if (!hasAnyActiveBatch)
            {
                var batchInstance = batchRepository.GetTopClosedBatch();
                if (batchInstance != null)
                {
                  //  batchRepository.UpdateBatchInstanceSortOrder(batchInstance.BatchInstanceID);
                    this.StartBatchProcessing(batchInstance.BatchInstanceID);
                }
            }
        }
    }
}

