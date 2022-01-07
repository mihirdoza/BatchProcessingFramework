using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchProcessingFramework.Entities
{
    [Table("[App.AP]")]
    public class AppAp
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int Type { get; set; }
        public string Category { get; set; }
        public string CategoryDesc { get; set; }
        public string SubCategory { get; set; }
        public string SubCategoryDesc { get; set; }
        public string Name { get; set; }
        public string NameDesc { get; set; }
        public string Value { get; set; }
        public string ValueDesc { get; set; }
        public string Extra { get; set; }
        public string DisplayControl { get; set; }
        public string ChangeEvent { get; set; }
        public bool IsRequired { get; set; }
    }
}
