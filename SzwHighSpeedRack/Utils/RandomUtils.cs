using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SzwHighSpeedRack
{
    /// <summary>
    /// 随机数操作
    /// 作者：史梓威
    /// 时间：20190429
    /// </summary>
    public class RandomUtils
    {
        /// <summary>
        /// 随机数
        /// </summary>
        private readonly Random _random;

        /// <summary>
        /// 初始化随机数
        /// </summary>
        public RandomUtils()
        {
            _random = new System.Random();
        }

        /// <summary>
        /// 获取指定范围的随机整数
        /// </summary>
        /// <param name="max">最大值</param>
        public int Next(int max)
        {
            return _random.Next(max);
        }

        /// <summary>
        /// 获取指定范围的随机整数，该范围包括最小值，但不包括最大值
        /// </summary>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        public int Next(int min, int max)
        {
            return _random.Next(min, max);
        }

        /// <summary>
        /// 对集合随机排序
        /// </summary>
        /// <typeparam name="T">集合元素类型</typeparam>
        /// <param name="array">集合</param>
        public static List<T> Sort<T>(IEnumerable<T> array)
        {
            if (array == null)
                return null;
            var random = new System.Random();
            var list = array.ToList();
            for (int i = 0; i < list.Count; i++)
            {
                int index1 = random.Next(0, list.Count);
                int index2 = random.Next(0, list.Count);
                T temp = list[index1];
                list[index1] = list[index2];
                list[index2] = temp;
            }
            return list;
        }

        /// <summary>
        /// 生成四位数校验码
        /// </summary>
        /// <returns>校验码</returns>
        public static string GenerateRandomCode()
        {
            StringBuilder codebuilder = new StringBuilder();

            long tick = DateTime.Now.Ticks;
            Random ran = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));

            for (int i = 0; i < 4; i++)
            {
                int r = ran.Next(0, 10);
                codebuilder.Append(r);
            }

            return codebuilder.ToString();
        }
    }
}