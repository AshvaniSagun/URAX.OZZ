#region NameSpace
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using EF = UraxUIServiceWebApi.EF;
using UraxUIServiceWebApi.Repository;
using UraxUIServiceWebApi.ResourceFiles;

#endregion

namespace UraxUIServiceWebApi.Models

{
    public class LookupPivot
    {
        public DataTable GetPivotData(List<DynamicLookupList> dynamicData)
        {
            
            List<LookUpdata> lst = new List<LookUpdata>();
            foreach (var item in dynamicData)
            {
                lst.Add(new LookUpdata()
                {
                    Name =item.VariableName,
                    GroupId = item.LookUpGroup,
                    Value = item.Value,
                    LookUpId = (int)item.LookUpId,
                    VariableId= item.VariableId
                   
                }
                );
            }

            
            var pivotTable = lst.ToPivotTable(
                          item => item.Name,
                          item => item.GroupId,
                         
                          items => items.Sum(x=>x.VariableId));
           
            int row = pivotTable.Rows.Count;
            int i = 0;
            var countcol = lst.Select(x => x.Name).Distinct().Count();
            for(int x =0;x <row;x++)
            {
                for(int y= 1; y<=countcol; y++)
                {
                    pivotTable.Rows[x][y] = lst[i].Value;
                    i++;
                }
               
            }
            return pivotTable;
        }
    }
    public class LookUpdata
    {
        #region LookUpdata Property
        [JsonProperty(PropertyName = "lookUpId")]
        public int LookUpId { get; set; }
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "groupId")]
        public int GroupId { get; set; }
        [JsonProperty(PropertyName = "variableId")]
        public long VariableId { get; set; } 
        #endregion
    }
    public static class Extensions
    {
        public static DataTable ToPivotTable<T, TColumn, TRow, TData>
            (this IEnumerable<T> source, Func<T, TColumn> columnSelector, Expression<Func<T, TRow>> rowSelector, Func<IEnumerable<T>, TData> dataSelector)
        {
            DataTable table = new DataTable();
            var rowName = ((MemberExpression)rowSelector.Body).Member.Name;
            table.Columns.Add(new DataColumn(rowName));
            var columns = source.Select(columnSelector).Distinct();

            foreach (var column in columns)
                table.Columns.Add(new DataColumn(column.ToString()));

            var rows = source.GroupBy(rowSelector.Compile())
                             .Select(rowGroup => new
                             {
                                 Key = rowGroup.Key,
                                 Values = columns.GroupJoin(
                                     rowGroup,
                                     c => c,
                                     r => columnSelector(r),
                                     (c, columnGroup) => dataSelector(columnGroup))
                             });

            foreach (var row in rows)
            {
                var dataRow = table.NewRow();
                var items = row.Values.Cast<object>().ToList();
                items.Insert(0, row.Key);
                dataRow.ItemArray = items.ToArray();
                table.Rows.Add(dataRow);
            }

            return table;
        }

        public static List<dynamic> ToDynamicList(this DataTable dt)
        {
            var list = new List<dynamic>();
            foreach (DataRow row in dt.Rows)
            {
                dynamic dyn = new ExpandoObject();
                list.Add(dyn);
                foreach (DataColumn column in dt.Columns)
                {
                    var dic = (IDictionary<string, object>)dyn;
                    dic[column.ColumnName] = row[column];
                }
            }
            return list;
        }
    }
}