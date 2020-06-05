using AspMVCAdminLTE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace AspMVCAdminLTE.Utils.Helpers
{
    public class AdminHtmlHelper
    {
        public class TableHeader
        {
            public Dictionary<string,string> TableHeaderInfo { get; set; }
        }
        public class TableHelper
        {
            public static MvcHtmlString BuildTableHeader(TableHeader tableHeaders)
            {
                
                var tableHeader = new StringBuilder();
                tableHeader.Append("<thead><tr>");
                foreach (var item in tableHeaders.TableHeaderInfo)
                {
                    tableHeader.Append($"<th {item.Value}>{item.Key}</th>");
                }
                tableHeader.Append("</tr></thead>");

                return new MvcHtmlString(tableHeader.ToString());
            }


            private static string BuildTableHeader(Type type)
            {
                var sb = new StringBuilder();
                var props = type.GetProperties().ToDictionary(x=> x.Name, x=> "");
                sb.Append(BuildTableHeader(new TableHeader { TableHeaderInfo = props }));
                return sb.ToString();
            }
            public static MvcHtmlString BuildBasicTable<T>(List<T> modelObject, string attributes = "")
            {
               
                var sb = new StringBuilder();
                var props = typeof(T).GetProperties();

                sb.Append($"<table {attributes}");

                //Build the header
                sb.Append(BuildTableHeader(typeof(T)));


                //Build Data
                sb.Append("<tbody>");
                foreach (var item in modelObject)
                {
                    sb.Append("<tr>");
                    foreach (var p in props)
                    {
                        var value =  typeof(T).GetProperty(p.Name).GetValue(item);
                        sb.Append($"<td>{value}</td>");
                    }
                    sb.Append("</tr>");
                }
                sb.Append("</tbody></table>");
                

                return new MvcHtmlString(sb.ToString());
            }
        }
    }
}