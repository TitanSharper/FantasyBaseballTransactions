using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace Infrastructure
{
    public static class JsonExtensions
    {
        public static T FromJson<T>(this string data)
        {
            var serializer = new JavaScriptSerializer();
            return serializer.Deserialize<T>(data);
        }
        public static string ToJson<T>(this T data)
        {
            return data.ToJson(1);
        }
        public static string ToJson<T>(this T data, int multiplyMaxJsonLengthBy)
        {
            var serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength *= multiplyMaxJsonLengthBy;
            return serializer.Serialize(data);
        }
    }

    public static class StringExtensions
    {
        public static bool HasValue(this string data)
        {
            string s = data;

            if (s != null)
                s = s.Trim();

            return !string.IsNullOrEmpty(s);
        }
    }
}
