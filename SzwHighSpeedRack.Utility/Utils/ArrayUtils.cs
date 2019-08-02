using System;
using System.Collections.Generic;
using System.Linq;

namespace SzwHighSpeedRack.Utility
{
    public static class ArrayUtils
    {
        /// <summary>
        /// 判断数组是否为空
        /// </summary>
        public static bool IsEmpty<T>(IEnumerable<T> list)
        {
            return list == null || list.Count() <= 0;
        }

        #region 01.字符串转换为List，去除重复项
        /// <summary>
        /// 字符串转换为List，去除重复项
        /// 使用：list = ToList(str);
        /// </summary>
        /// <param name="str">当前字符串对象</param>
        /// <returns>传入前str="a,b,a";返回结果str="a,b"</returns>
        public static List<string> ToList(string str)
        {
            return ToList(str, new char[] { ',' });
        }

        /// <summary>
        /// 字符串转换为List，去除重复项
        /// 使用：list = ToList(str, new char[] {','});
        /// </summary>
        /// <param name="str">当前字符串对象</param>
        /// <param name="splits">根据</param>
        /// <returns>传入前str="a,b,a";返回结果str="a,b"</returns>
        public static List<string> ToList(string str, char[] splits)
        {
            var list = GetList(str, splits);
            return list == null ? null : list.ToList();
        }
        #endregion

        #region 02.字符串转换为数组，去除重复项
        /// <summary>
        /// 字符串转换为数组，去除重复项
        /// 使用：list = ToArray(str);
        /// </summary>
        /// <param name="str">当前字符串对象</param>
        /// <returns>传入前str="a,b,a";返回结果str="a,b"</returns>
        public static string[] ToArray(string str)
        {
            return ToArray(str, new char[] { ',' });
        }

        /// <summary>
        /// 字符串转换为List，去除重复项
        /// 使用：list = ToArray(str, new char[] {','});
        /// </summary>
        /// <param name="str">当前字符串对象</param>
        /// <param name="splits">根据</param>
        /// <returns>传入前str="a,b,a";返回结果str="a,b"</returns>
        public static string[] ToArray(string str, char[] splits)
        {
            var list = GetList(str, splits);
            return list == null ? null : list.ToArray();
        }
        #endregion

        #region 03.排除字符串内的重复项
        /// <summary>
        /// 排除字符串内的重复项
        /// <example>
        /// <code>
        /// array[1] = FilterRepeatItem(array[1]);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string FilterEmpty(string str)
        {
            return FilterEmpty(str, new char[] { ',' });
        }

        /// <summary>
        /// 排除字符串内的重复项
        /// <example>
        /// <code>
        /// array[1] = FilterRepeatItem(array[1], new char[] {','});
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="str">当前字符串对象</param>
        /// <param name="splits">根据</param>
        /// <returns>传入前str="a,b,a";返回结果str="a,b"</returns>
        public static string FilterEmpty(string str, char[] splits)
        {
            var list = GetList(str, splits);
            if (list == null)
            {
                return str;
            }
            str = string.Join(",", list);
            return str;
        }
        #endregion

        #region 04.返回去重去空后的结果集
        /// <summary>
        /// 返回去重去空后的结果集
        /// </summary>
        /// <param name="str">当前字符串对象</param>
        /// <param name="splits">根据</param>
        /// <returns></returns>
        private static IEnumerable<string> GetList(string str, char[] splits)
        {
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }
            if (splits == null || splits.Length == 0)
            {
                return null;
            }
            return str.Split(splits, StringSplitOptions.RemoveEmptyEntries).Distinct();
        }
        #endregion

        #region 05.去除数组里面的空值
        /// <summary>
        /// 去除数组里面的空值
        /// </summary>
        /// <typeparam name="T">指定类型</typeparam>
        /// <param name="args">数组</param>
        /// <returns>去除空值后的数组</returns>
        public static T[] RemoveNull<T>(T[] args)
        {
            if (args == null || args.Length == 0)
                return new T[0];

            // 用list来保存
            var list = args.Where(t => t != null && !"".Equals(t)).ToList();
            return list.ToArray<T>();
        }
        #endregion

        #region 06.去除数组里面的重复值
        /// <summary>
        /// 去除数组里面的重复值
        /// </summary>
        /// <typeparam name="T">指定类型</typeparam>
        /// <param name="args">数组</param>
        /// <returns>去除重复值后的数组</returns>
        public static T[] RemoveDuplicate<T>(T[] args)
        {
            if (args == null || args.Length == 0)
                return new T[0];
            // 用list来保存
            var list = new List<T>();
            foreach (T t in args)
            {
                // 保证没有重复
                if (!list.Contains(t))
                {
                    list.Add(t);
                }
            }
            return list.ToArray<T>();
        }
        #endregion

        #region 07.去除数组里面的空值和重复值
        /// <summary>
        /// 去除数组里面的空值和重复值
        /// </summary>
        /// <typeparam name="T">指定类型</typeparam>
        /// <param name="args">数组</param>
        /// <returns>去除空值和重复值后的数组</returns>
        public static T[] RemoveNullAndDuplicate<T>(T[] args)
        {
            if (args == null || args.Length == 0)
                return new T[0];

            // 用list来保存
            var list = new List<T>();
            foreach (T t in args)
            {
                // 保证没有重复
                if (t != null && !"".Equals(t) && !list.Contains(t))
                {
                    list.Add(t);
                }
            }
            return list.ToArray<T>();
        }
        #endregion

        #region 08.克隆List
        public static List<T> Clone<T>(List<T> list)
        {
            if (list == null || list.Count <= 0) return null;
            return new List<T>(list.ToArray());
        }
        public static T[] Clone<T>(T[] list)
        {
            if (list == null || list.Length <= 0) return null;
            T[] array2 = new T[list.Length];
            Array.Copy(list, 0, array2, 0, list.Length);
            return array2;
        }
        #endregion

        #region 10.空集合
        public static List<T> EmptyList<T>()
        {
            return Enumerable.Empty<T>().ToList();
        }
        public static IEnumerable<T> IEmptyList<T>()
        {
            return Enumerable.Empty<T>();
        }
        #endregion

        #region 11.获取字典
        public static string Get(this Dictionary<string, string> dic, string key)
        {
            return dic.ContainsKey(key) ? dic[key] : string.Empty;
        }
        #endregion

        #region 12.转换为字符
        public static string ToString<T>(this IEnumerable<string> list, string separator)
        {
            return string.Join(separator, list);
        }
        #endregion
    }
}
