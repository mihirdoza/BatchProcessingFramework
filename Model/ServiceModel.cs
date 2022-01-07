using BatchProcessingFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchProcessingFramework.Model
{
    public class ServiceModel
    {
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

        public ServiceModel GetServiceModel(AppAp appAp)
        {
            var returnValue = new ServiceModel();
            returnValue.ID = appAp.ID;
            returnValue.Type = appAp.Type;
            returnValue.Name = appAp.Name;
            returnValue.NameDesc = appAp.NameDesc;
            returnValue.Category = appAp.Category;
            returnValue.CategoryDesc = appAp.CategoryDesc;
            returnValue.SubCategory = appAp.SubCategory;
            returnValue.SubCategoryDesc = appAp.SubCategoryDesc;
            returnValue.Value = appAp.Value;
            returnValue.ValueDesc = appAp.ValueDesc;
            returnValue.Extra = appAp.Extra;
            returnValue.DisplayControl = appAp.DisplayControl;
            returnValue.ChangeEvent = appAp.ChangeEvent;
            returnValue.IsRequired = appAp.IsRequired;

            return returnValue;
        }
    }
}
