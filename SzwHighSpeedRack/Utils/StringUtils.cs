using System;
using System.Collections.Generic;
using System.Text;

namespace SzwHighSpeedRack
{
    /// <summary>
    ///
    /// </summary>
    public static class StringUtils
    {
        /// <summary>
        /// 使用特定字符串拼接list实体
        /// </summary>
        /// <typeparam name="T">实体泛型</typeparam>
        /// <param name="source">源实体列表</param>
        /// <param name="toString">定义实体中的属性为需要拼接的内容</param>
        /// <param name="splitter">分割符号</param>
        /// <returns>拼接后的字符串</returns>
        public static string Implode<T>(this IEnumerable<T> source, Func<T, string> toString, string splitter)
        {
            StringBuilder result = new StringBuilder();
            splitter = splitter ?? string.Empty;
            foreach (T item in source)
            {
                result.Append(toString(item));
                result.Append(splitter);
            }
            string resultStr = result.ToString();
            if (resultStr.EndsWith(splitter))
            {
                resultStr = resultStr.Remove(resultStr.Length - splitter.Length, splitter.Length);
            }
            return resultStr;
        }
    }
}