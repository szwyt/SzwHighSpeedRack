﻿namespace SzwHighSpeedRack.Utility
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 类型转换
    /// </summary>
    public static class Convert
    {
        /// <summary>
        /// 转换为32位整型
        /// </summary>
        /// <param name="input">输入值</param>
        /// <returns>int</returns>
        public static int ToInt(object input)
        {
            return ToIntOrNull(input) ?? 0;
        }

        /// <summary>
        /// 转换为32位可空整型
        /// </summary>
        /// <param name="input">输入值</param>
        /// <returns>int</returns>
        public static int? ToIntOrNull(object input)
        {
            int result;
            var success = int.TryParse(input.SafeString(), out result);
            if (success)
            {
                return result;
            }

            try
            {
                var temp = ToDoubleOrNull(input, 0);
                if (temp == null)
                {
                    return null;
                }

                return System.Convert.ToInt32(temp);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 转换为64位整型
        /// </summary>
        /// <param name="input">输入值</param>
        /// <returns>long</returns>
        public static long ToLong(object input)
        {
            return ToLongOrNull(input) ?? 0;
        }

        /// <summary>
        /// 转换为64位可空整型
        /// </summary>
        /// <param name="input">输入值</param>
        /// <returns>long</returns>
        public static long? ToLongOrNull(object input)
        {
            long result;
            var success = long.TryParse(input.SafeString(), out result);
            if (success)
            {
                return result;
            }

            try
            {
                var temp = ToDecimalOrNull(input, 0);
                if (temp == null)
                {
                    return null;
                }

                return System.Convert.ToInt64(temp);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 转换为32位浮点型,并按指定小数位舍入
        /// </summary>
        /// <param name="input">输入值</param>
        /// <param name="digits">小数位数</param>
        /// <returns>float</returns>
        public static float ToFloat(object input, int? digits = null)
        {
            return ToFloatOrNull(input, digits) ?? 0;
        }

        /// <summary>
        /// 转换为32位可空浮点型,并按指定小数位舍入
        /// </summary>
        /// <param name="input">输入值</param>
        /// <param name="digits">小数位数</param>
        /// <returns>float</returns>
        public static float? ToFloatOrNull(object input, int? digits = null)
        {
            float result;
            var success = float.TryParse(input.SafeString(), out result);
            if (!success)
            {
                return null;
            }

            if (digits == null)
            {
                return result;
            }

            return (float)Math.Round(result, digits.Value);
        }

        /// <summary>
        /// 转换为64位浮点型,并按指定小数位舍入，温馨提示：4舍6入5成双
        /// </summary>
        /// <param name="input">输入值</param>
        /// <param name="digits">小数位数</param>
        /// <returns>double</returns>
        public static double ToDouble(object input, int? digits = null)
        {
            return ToDoubleOrNull(input, digits) ?? 0;
        }

        /// <summary>
        /// 转换为64位可空浮点型,并按指定小数位舍入，温馨提示：4舍6入5成双
        /// </summary>
        /// <param name="input">输入值</param>
        /// <param name="digits">小数位数</param>
        /// <returns>double</returns>
        public static double? ToDoubleOrNull(object input, int? digits = null)
        {
            double result;
            var success = double.TryParse(input.SafeString(), out result);
            if (!success)
            {
                return null;
            }

            if (digits == null)
            {
                return result;
            }

            return Math.Round(result, digits.Value, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// 转换为128位浮点型,并按指定小数位舍入，温馨提示：4舍6入5成双
        /// </summary>
        /// <param name="input">输入值</param>
        /// <param name="digits">小数位数</param>
        /// <returns>decimal</returns>
        public static decimal ToDecimal(object input, int? digits = null)
        {
            return ToDecimalOrNull(input, digits) ?? 0;
        }

        /// <summary>
        /// 转换为128位可空浮点型,并按指定小数位舍入，温馨提示：4舍6入5成双
        /// </summary>
        /// <param name="input">输入值</param>
        /// <param name="digits">小数位数</param>
        /// <returns>decimal</returns>
        public static decimal? ToDecimalOrNull(object input, int? digits = null)
        {
            decimal result;
            var success = decimal.TryParse(input.SafeString(), out result);
            if (!success)
            {
                return null;
            }

            if (digits == null)
            {
                return result;
            }

            return Math.Round(result, digits.Value);
        }

        /// <summary>
        /// 转换为布尔值
        /// </summary>
        /// <param name="input">输入值</param>
        /// <returns>bool</returns>
        public static bool ToBool(object input)
        {
            return ToBoolOrNull(input) ?? false;
        }

        /// <summary>
        /// 转换为可空布尔值
        /// </summary>
        /// <param name="input">输入值</param>
        /// <returns>bool</returns>
        public static bool? ToBoolOrNull(object input)
        {
            bool? value = GetBool(input);
            if (value != null)
            {
                return value.Value;
            }

            bool result;
            return bool.TryParse(input.SafeString(), out result) ? (bool?)result : null;
        }

        /// <summary>
        /// 转换为日期
        /// </summary>
        /// <param name="input">输入值</param>
        /// <returns>DateTime</returns>
        public static DateTime ToDate(object input)
        {
            return ToDateOrNull(input) ?? DateTime.MinValue;
        }

        /// <summary>
        /// 转换为可空日期
        /// </summary>
        /// <param name="input">输入值</param>
        /// <returns>DateTime</returns>
        public static DateTime? ToDateOrNull(object input)
        {
            DateTime result;
            return DateTime.TryParse(input.SafeString(), out result) ? (DateTime?)result : null;
        }

        /// <summary>
        /// 转换为Guid
        /// </summary>
        /// <param name="input">输入值</param>
        /// <returns>Guid</returns>
        public static Guid ToGuid(object input)
        {
            return ToGuidOrNull(input) ?? Guid.Empty;
        }

        /// <summary>
        /// 转换为可空Guid
        /// </summary>
        /// <param name="input">输入值</param>
        /// <returns>Guid</returns>
        public static Guid? ToGuidOrNull(object input)
        {
            Guid result;
            return Guid.TryParse(input.SafeString(), out result) ? (Guid?)result : null;
        }

        /// <summary>
        /// 布尔
        /// </summary>
        /// <param name="input">input</param>
        /// <returns>bool</returns>
        private static bool? GetBool(object input)
        {
            switch (input.SafeString().ToLower())
            {
                case "0":
                    return false;
                case "否":
                    return false;
                case "不":
                    return false;
                case "no":
                    return false;
                case "fail":
                    return false;
                case "1":
                    return true;
                case "是":
                    return true;
                case "ok":
                    return true;
                case "yes":
                    return true;
                default:
                    return null;
            }
        }
    }
}
