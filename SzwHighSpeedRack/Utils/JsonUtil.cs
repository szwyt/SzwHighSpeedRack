// <copyright file="JsonModule.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SzwHighSpeedRack
{
    using Newtonsoft.Json;
    using System;

    /// <summary>
    /// 序列化,反序列化.
    /// </summary>
    public class JsonModule
    {
        /// <summary>
        /// 序列化.
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns>字符串</returns>
        public static string Serialize(object obj)
        {
            JsonSerializerSettings jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore, DateFormatString = "yyyy-MM-dd hh:mm:ss" };
            return JsonConvert.SerializeObject(obj, jsonSetting);
        }

        /// <summary>
        /// 反序列化.
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="json">字符串</param>
        /// <returns>T</returns>
        public static T Deserialize<T>(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                throw new Exception("无效的JSON串:" + ex.Message);
            }
        }
    }
}