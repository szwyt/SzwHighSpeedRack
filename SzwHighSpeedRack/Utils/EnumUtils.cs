using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace SzwHighSpeedRack
{
    /// <summary>
    /// 枚举工具类
    /// 作者：史字威 
    /// 时间：20190429
    /// </summary>
    public static class EnumUtils
    {
        /// <summary>
        /// 获取属性描述值
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetEnumDescriptionValue(this object obj)
        {
            FieldInfo fieldinfo = obj.GetType().GetField(obj.ToString());
            if (fieldinfo != null)
            {
                var attribute = fieldinfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attribute != null && attribute.Length > 0)
                {
                    DescriptionAttribute da = (DescriptionAttribute)attribute[0];
                    return da.Description;
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// 获取枚举类型
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Type GetEnumTypeValue(this object obj)
        {
            FieldInfo fieldinfo = obj.GetType().GetField(obj.ToString());
            if (fieldinfo != null)
            {
                var attribute = fieldinfo.GetCustomAttributes(typeof(EnumTypeAttribute), false).FirstOrDefault();
                if (attribute != null)
                {
                    return (attribute as IAttribute<Type>).Value;
                }
            }
            return null;
        }

        /// <summary>
        /// 获取枚举类型数组
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Dictionary<int, string> GetEnumValueList(this object obj)
        {
            Dictionary<int, string> resultList = new Dictionary<int, string>();
            FieldInfo fieldinfo = obj.GetType().GetField(obj.ToString());
            if (fieldinfo != null)
            {
                var attribute = fieldinfo.GetCustomAttributes(typeof(EnumTypeAttribute), false).FirstOrDefault();
                if (attribute != null)
                {
                    var arr = Enum.GetValues((attribute as IAttribute<Type>).Value);
                    foreach (var item in arr)
                    {
                        resultList.Add((int)item, item.GetEnumDescriptionValue());
                    }
                    return resultList;
                }
            }
            return null;
        }

        /// <summary>
        /// 根据描述获取枚举值
        /// </summary>
        /// <param name="str"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int GetEnumValue(this string str, Type obj)
        {
            int returnStr = -1;
            foreach (var p in Enum.GetValues(obj))
            {
                if (p.GetEnumDescriptionValue() == str)
                {
                    returnStr = Convert.ToInt32(p);
                    break;
                }
            }
            return returnStr;
        }

        /// <summary>
        /// 获取枚举对应数组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Dictionary<int, string> ToDictionaryWithDescriptionEnum<T>()
        {
            Dictionary<int, string> resultList = new Dictionary<int, string>();
            Type type = typeof(T);
            var arr = Enum.GetValues(type);
            foreach (var item in arr)
            {
                resultList.Add((int)item, item.GetEnumDescriptionValue());
            }
            return resultList;
        }
    }
}
