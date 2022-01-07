using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchProcessingFramework.Entities
{
    [Table("[App.BatchInstance]")]
    public class BatchInstance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        public AppAp AppAp { get; set; }
    }
}
