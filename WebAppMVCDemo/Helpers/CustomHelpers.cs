using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace WebAppMVCDemo.Helpers
{
    public static class CustomHelpers
    {
        public static IHtmlContent File(this IHtmlHelper html, string id, string name)
        {
            string input = $"<input type='file' id=]'{id}' name='{name}'>";

            return new HtmlString(input);
        }



        public static IHtmlContent DataGrid<T>(this IHtmlHelper html, Dictionary<T, List<T>> data, string className)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append($"<table class='{className}'>");
            sb.Append("<thead>");
            sb.Append("<tr>");

            foreach (var item in data.Keys)
            {
                Type myType = item.GetType();
                IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

                foreach (PropertyInfo prop in props)
                {
                    object propValue = prop.GetValue(item, null);

                    sb.Append($" <th>{prop.Name}</th>");
                }

            }
            sb.Append("</tr>");
            sb.Append("</thead>");
            sb.Append("<tbody>");

            foreach (var item in data.Values)
            {
                foreach (var val in item)
                {
                    sb.Append("<tr>");
                    Type myType = val.GetType();
                    IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

                    foreach (PropertyInfo prop in props)
                    {
                        object propValue = prop.GetValue(val, null);

                        //sb.Append($" <th>{prop.Name}</th>");

                        sb.Append($"<td>{propValue}</td>");

                    }
                    sb.Append("</tr>");
                }
            }

            sb.Append("</tbody>");
            sb.Append("</table>");


            return new HtmlString(sb.ToString());
        }
    }
}
