using System;
using System.Collections.Generic;
using System.Text;

namespace SzwHighSpeedRack
{
    public static class ToolsEx
    {
        public static string ToXml(this object obj)
        {
            return XmlModule.Serializer(obj);
        }

        public static T X2Entity<T>(this string obj)
            where T : class
        {
            return XmlModule.Deserialize(typeof(T), obj) as T;
        }

        public static string ToJson(this object obj)
        {
            if (obj == null)
            {
                return string.Empty;
            }

            return JsonModule.Serialize(obj);
        }

        public static T J2Entity<T>(this string obj)
        {
            return JsonModule.Deserialize<T>(obj);
        }
    }
}
