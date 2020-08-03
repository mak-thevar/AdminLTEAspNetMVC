using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace AspMVCAdminLTE.Utils.Helpers
{
    public class AdminHtmlHelper
    {
        public class TableHeader
        {
            public Dictionary<string, string> TableHeaderInfo { get; set; } = new Dictionary<string, string>();
        }

        public class TableHelper
        {
            public static MvcHtmlString BuildTableHeader(TableHeader tableHeaders, bool enableActionColumn = false)
            {
                var tableHeader = new StringBuilder();
                tableHeader.Append("<thead><tr>");
                foreach (var item in tableHeaders.TableHeaderInfo)
                {
                    tableHeader.Append($"<th {item.Value}>{item.Key}</th>");
                }
                if (enableActionColumn)
                    tableHeader.Append("<th>Action</th>");
                tableHeader.Append("</tr></thead>");

                return new MvcHtmlString(tableHeader.ToString());
            }

            private static string BuildTableHeader(Type type)
            {
                var sb = new StringBuilder();
                var props = type.GetProperties().ToDictionary(x => x.Name, x => "");
                sb.Append(BuildTableHeader(new TableHeader { TableHeaderInfo = props }));
                return sb.ToString();
            }

            public static MvcHtmlString BuildBasicTable<T>(List<T> modelObject, string attributes = "", string[] excludeColumns = null, string editButton = "", bool deleteButton = false)
            {
                var sb = new StringBuilder();
                var props = typeof(T).GetProperties();
                if (excludeColumns != null)
                {
                    props = props.Where(p => !excludeColumns.Contains(p.Name)).ToArray();
                }

                sb.Append($"<table {attributes}>");

                //Build the header
                sb.Append(BuildTableHeader(new TableHeader { TableHeaderInfo = props.ToDictionary(x => x.Name, x => "") }, !string.IsNullOrEmpty(editButton) || deleteButton));

                //Build Data
                sb.Append("<tbody>");
                foreach (var item in modelObject)
                {
                    sb.Append("<tr>");
                    foreach (var p in props)
                    {
                        var value = typeof(T).GetProperty(p.Name).GetValue(item);
                        if (p.Name.ToLower() == "id")
                        {
                            sb.Append($"<td class='itemId'>{value}</td>");
                        }
                        else
                        {
                            sb.Append($"<td>{value}</td>");
                        }
                    }
                    if (!string.IsNullOrEmpty(editButton) || deleteButton)
                    {
                        sb.Append("<td>");
                        if (!string.IsNullOrEmpty(editButton))
                        {
                            sb.Append($@"<a class='btn btn-info btn-sm' href='{editButton + item.GetType().GetProperty("Id").GetValue(item).ToString()}'>
                               <i class='fas fa-pencil-alt'>
                               </i>
                               Edit
                           </a>");
                        }
                        if (deleteButton)
                        {
                            sb.Append($@"&nbsp;<button class='btn btn-danger btn-sm btnDelete'>
                               <i class='fas fa-trash'>
                               </i>
                               Delete
                           </button>");
                        }
                        sb.Append("</td>");
                    }
                    sb.Append("</tr>");
                }
                if (modelObject.Count == 0)
                {
                    sb.Append($"<tr><td align='center' colspan={props.Length}>No Data Available !</td></tr>");
                }
                sb.Append("</tbody></table>");

                return new MvcHtmlString(sb.ToString());
            }
        }
    }

    public static class HtmlExtension
    {
        private static string BootstrapControlTemplate(string labelHtml, string controlHtml)
        {
            return $@"<div class='form-group'>
                          {labelHtml}
                         {controlHtml}
                       </div>";
        }

        public static MvcHtmlString BootStrapTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string labelString, string placeHolder = "", string type = "text")
        {
            var htmlAttributes = new { @class = "form-control", @placeholder = placeHolder, type = type };
            var htmlString = BootstrapControlTemplate(htmlHelper.LabelFor(expression, labelString).ToHtmlString(), htmlHelper.TextBoxFor(expression, htmlAttributes).ToHtmlString());
            return new MvcHtmlString(htmlString);
        }

        public static MvcHtmlString BootStrapTextBox(this HtmlHelper htmlHelper, string name, string labelString, string placeHolder = "", string type = "text")
        {
            var htmlAttributes = new { @class = "form-control", @placeholder = placeHolder, type = type };
            var htmlString = BootstrapControlTemplate(htmlHelper.Label(labelString).ToHtmlString(), htmlHelper.TextBox(name, null, htmlAttributes).ToHtmlString());
            return new MvcHtmlString(htmlString);
        }

        public static MvcHtmlString BootStrapTextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string labelString, string placeHolder = "", object htmlAttributes = null)
        {
            var htmlString = BootstrapControlTemplate(htmlHelper.LabelFor(expression, labelString).ToHtmlString(), htmlHelper.TextAreaFor(expression, new { @class = "form-control", @placeholder = placeHolder }).ToHtmlString());
            return new MvcHtmlString(htmlString);
        }

        public static JObject GetNavMenu(this HtmlHelper htmlHelper)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<JObject>(File.ReadAllText(HttpContext.Current.Server.MapPath("~/Views/Shared/navMenu.json")));
        }
    }
}