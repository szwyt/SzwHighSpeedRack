using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SzwHighSpeedRack.Utility
{
    public static class ASMIX
    {
        // ASCII Dec(十进制)起始位置
        private static int startindex = 32;

        // ASCII Dec(十进制)结束位置
        private static int endindex = 126;

        private static string defaultkey = "Xiaoyu2018long&liu&chen999";

        /// <summary>
        /// 字符串转Char[]
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>char[]</returns>
        private static char[] StringToChar(this string str)
        {
            return str.ToCharArray();
        }

        /// <summary>
        /// int[]转 string
        /// </summary>
        /// <param name="intArray">字符串</param>
        /// <returns>char[]</returns>
        private static string IntArrayToString(this int[] intArray)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in intArray)
            {
                sb.AppendFormat("{0}", ((char)item).ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// String 转 int[]
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>int[]</returns>
        private static int[] StringToIntArray(this string str)
        {
            var intArray = new List<int>();
            var charArray = str.StringToChar();
            foreach (var item in charArray)
            {
                intArray.Add((int)item);
            }

            return intArray.ToArray();
        }

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="str">要加密的字符串</param>
        /// <param name="key">秘钥</param>
        /// <returns>string</returns>
        public static string Encrypt(this string str, string key = "")
        {
            if (string.IsNullOrEmpty(key))
            {
                key = defaultkey;
            }

            var oldStrToIntArray = str.StringToIntArray();
            var keyStrToArray = key.StringToIntArray();
            var oldCount = oldStrToIntArray.Count();

            var newIntAarray = new List<int>();

            // 秘钥的长度
            var keyCount = keyStrToArray.Count();

            // 循环数组进行加密
            for (int i = 0; i < oldCount; i++)
            {
                // 取余数
                var remainder = i % keyCount;
                if (remainder == 0 && i == 0)
                {
                    // 如果刚好整除就代表是秘钥最后一位
                    remainder = 0;
                }

                // 需要移动的位数
                var keyNum = keyStrToArray[remainder];
                var oldNum = oldStrToIntArray[i];
                var sumNum = oldNum + keyNum;
                var newNum = 0;

                if (sumNum <= endindex)
                {
                    newNum = sumNum;
                }
                else
                {
                    var subtract = sumNum - endindex;
                    var remainderNew = subtract % (endindex - startindex);
                    if (remainderNew == 0)
                    {
                        newNum = endindex;
                    }
                    else
                    {
                        newNum = startindex + remainderNew;
                    }

                }

                newIntAarray.Add(newNum);
            }

            return newIntAarray.ToArray().IntArrayToString();
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="str">要解密的字符串</param>
        /// <param name="key">秘钥</param>
        /// <returns>string</returns>
        public static string Decrypt(this string str, string key = "")
        {
            if (string.IsNullOrEmpty(key))
            {
                key = defaultkey;
            }

            var oldIntAarray = new List<int>();

            var newStrToIntArray = str.StringToIntArray();
            var keyStrToArray = key.StringToIntArray();

            // 要解密的字符串长度
            var newCount = newStrToIntArray.Count();

            // 秘钥的长度
            var keyCount = keyStrToArray.Count();
            for (int i = 0; i < newCount; i++)
            {
                // 取余数
                var remainder = i % keyCount;
                if (remainder == 0 && i == 0)
                {
                    // 如果刚好整除就代表是秘钥最后一位
                    remainder = 0;
                }

                // 需要移动的位数
                var keyNum = keyStrToArray[remainder];
                var newNum = newStrToIntArray[i];
                var sumNum = newNum - keyNum;
                var oldNum = 0;
                if (sumNum >= startindex)
                {
                    oldNum = sumNum;
                }
                else
                {
                    var subtract = startindex - sumNum;
                    var remainderNew = subtract % (endindex - startindex);
                    if (remainderNew == 0)
                    {
                        oldNum = startindex;
                    }
                    else
                    {
                        oldNum = endindex - remainderNew;
                    }

                }

                oldIntAarray.Add(oldNum);
            }

            return oldIntAarray.ToArray().IntArrayToString();
        }
    }
}
