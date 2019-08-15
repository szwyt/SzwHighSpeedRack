using System;
using System.Security.Cryptography;
using System.Text;
using XYQMS.Utility.Utils;

namespace SzwHighSpeedRack
{
    /// <summary>
    /// MD5工具类
    /// </summary>
    public class MD5Util
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="argString"></param>
        /// <returns></returns>
        public static string GenerateMD5(String argString)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] data = Encoding.Default.GetBytes(argString);
            byte[] result = md5.ComputeHash(data);
            String strReturn = String.Empty;
            for (int i = 0; i < result.Length; i++)
                strReturn += result[i].ToString("X").PadLeft(2, '0');
            return strReturn;
        }

        /// <summary>
        /// Md5加密
        /// </summary>
        /// <param name="value"></param>
        /// <param name="encoding"></param>
        /// <param name="startIndex"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string Md5(string value, Encoding encoding, int? startIndex, int? length)
        {
            if (string.IsNullOrWhiteSpace(value))
                return string.Empty;
            var md5 = new MD5CryptoServiceProvider();
            string result;
            try
            {
                var hash = md5.ComputeHash(encoding.GetBytes(value));
                result = startIndex == null ? BitConverter.ToString(hash) : BitConverter.ToString(hash, startIndex.SafeValue(), length.SafeValue());
            }
            finally
            {
                md5.Clear();
            }
            return result.Replace("-", "");
        }
    }
}
