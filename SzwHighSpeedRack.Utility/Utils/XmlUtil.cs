// <copyright file="XmlModule.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SzwHighSpeedRack
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;

    /// <summary>
    /// XML.
    /// </summary>
    public class XmlModule
    {
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="xml">XML字符串</param>
        /// <returns>object</returns>
        public static object Deserialize(Type type, string xml)
        {
            try
            {
                using (StringReader sr = new StringReader(xml))
                {
                    XmlSerializer xmldes = new XmlSerializer(type);
                    return xmldes.Deserialize(sr);
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="type">type</param>
        /// <param name="stream">stream</param>
        /// <returns>object</returns>
        public static object Deserialize(Type type, Stream stream)
        {
            XmlSerializer xmldes = new XmlSerializer(type);
            return xmldes.Deserialize(stream);
        }

        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns>string</returns>
        public static string Serializer(object obj)
        {
            MemoryStream stream = new MemoryStream();
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);
            XmlSerializer xml = new XmlSerializer(obj.GetType());
            try
            {
                // 序列化对象
                xml.Serialize(stream, obj, ns);
            }
            catch (InvalidOperationException)
            {
                throw;
            }

            stream.Position = 0;
            StreamReader sr = new StreamReader(stream);
            string str = sr.ReadToEnd();
            sr.Dispose();
            stream.Dispose();
            return str;
        }
    }
}
