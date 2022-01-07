using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace BatchProcessingFramework.Extensions
{
    public static class DataTableExtensions
    {
        public static string GetJSON(this DataTable dt)
        {
            var serializer = new JavaScriptSerializer();
            ArrayList root = new ArrayList();
            List<Dictionary<string, object>> table;
            Dictionary<string, object> data;

            table = new List<Dictionary<string, object>>();
            foreach (DataRow dr in dt.Rows)
            {
                data = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    data.Add(col.ColumnName, dr[col]);
                }
                table.Add(data);
            }
            root.Add(table);

            return serializer.Serialize(root);
        }

        public static DataTable jsonToDataTable(string jsonString)
        {
            var jsonLinq = JObject.Parse(jsonString);

            // Find the first array using Linq  
            var srcArray = jsonLinq.Descendants().Where(d => d is JArray).First();
            var trgArray = new JArray();
            foreach (JObject row in srcArray.Children<JObject>())
            {
                var cleanRow = new JObject();
                foreach (JProperty column in row.Properties())
                {
                    // Only include JValue types  
                    if (column.Value is JValue)
                    {
                        cleanRow.Add(column.Name, column.Value);
                    }
                }
                trgArray.Add(cleanRow);
            }

            return JsonConvert.DeserializeObject<DataTable>(trgArray.ToString());
        }
    }
}
