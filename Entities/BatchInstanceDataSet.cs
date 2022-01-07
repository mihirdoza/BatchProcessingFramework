using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchProcessingFramework.Entities
{
    [Table("[App.BatchInstanceDataSet]")]
    public class BatchInstanceDataSet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long BatchInstanceDataSetID { get; set; }
        public long BatchInstanceID { get; set; }
        public long NodeID { get; set; }
        public string HintsToProcess { get; set; }
        public string DataSet { get; set; }
        public string Status { get; set; }
        public DateTime LastUpdated { get; set; }
        public BatchInstance BatchInstance { get; set; }
    }
}
