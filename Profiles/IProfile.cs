using BatchProcessingFramework.Requests;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchProcessingFramework.Profiles
{
    public abstract class IProfile
    {
        public void ProcessProfile(BaseRequest request)
        {
            var applicationRepository = new ApplicationRepository();
            if (applicationRepository.IsProfileExists(request.profileName) && dataTable.Count() > 0)
            {
                var tmpNetZoomMethods = new TempNetZoomMethods();
                // Validate DataSet
                if (tmpNetZoomMethods.ValidateDataTable(dataTable))
                {
                    long? batchId = null;
                    long? nodeId = null;
                    var batchRepository = new BatchRepository();
                    foreach (var row in dataTable)
                    {
                        // call the prebatch processing method here
                        if (profilename == "order")
                        {
                            TicketProfile
                            }

                        //==============Add DataSet for Batch====================
                        batchId = batchRepository.CreateAndGetBatchInstanceDataSet(profileName, row, batchId, nodeId);
                    }

                    //====================CloseBatch(BatchID)====================
                    //Set DataSetTotalCount; //Update count first
                    var batchInstanceModel = new BatchInstanceModel();
                    //BatchID.Order = BatchInstanceID
                    //UpdateBatchStatus = Closed
                    //If(DataSetTotalCount <= 0); if no records in batch then delete the batch
                    //      DeleteRecord from Table: Batch for BatchID for (BatchID)

                }
            }
        }
        public abstract int NZ_PreBatchNodeFor(string profileName, DataTable dataset);
        public abstract int NZ_FinalizeNodeFor(string profileName, DataTable dataset);
        public abstract int BatchOperation(int batchInstanceID, string action, int neworder);
    }
}
