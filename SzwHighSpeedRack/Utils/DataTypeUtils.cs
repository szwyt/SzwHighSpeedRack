using System;

namespace XYQMS.Utility.Utils
{
    /// <summary>
    /// 数据类型转换工具
    /// 作者：陶望青
    /// 时间：20190429
    /// </summary>
    public static class DataTypeUtils
    {
        #region 01.字符串转换为Int型

        public static int? ToInt(this string str)
        {
            int ret;
            if (int.TryParse(str, out ret))
                return ret;
            return null;
        }

        #endregion 01.字符串转换为Int型

        #region 02.字符串转换为bool型

        public static bool? ToBoolean(this string str)
        {
            bool ret;
            if (bool.TryParse(str, out ret))
                return ret;
            return null;
        }

        #endregion 02.字符串转换为bool型

        #region 03.字符串转换为Guid型

        public static Guid? ToGuid(this string str)
        {
            if (string.IsNullOrEmpty(str)) return null;
            Guid g = Guid.Empty;
            if (Guid.TryParse(str, out g))
                return g;
            return null;
        }

        #endregion 03.字符串转换为Guid型

        #region 04.字符串转换为Decimal型

        public static decimal? ToDecimal(this string str)
        {
            if (string.IsNullOrEmpty(str)) return null;
            decimal d;
            if (decimal.TryParse(str, out d))
                return d;
            return null;
        }

        #endregion 04.字符串转换为Decimal型

        #region 05.字符串转换为Double型

        public static double? ToDouble(this string str)
        {
            if (string.IsNullOrEmpty(str)) return null;
            double d;
            if (double.TryParse(str, out d))
                return d;
            return null;
        }

        /// <summary>
        /// 转换为64位可空浮点型,并按指定小数位舍入，温馨提示：4舍6入5成双
        /// </summary>
        /// <param name="input">输入值</param>
        /// <param name="digits">小数位数</param>
        public static double? ToDoubleOrNull(this object input, int? digits = null)
        {
            double result;
            var success = double.TryParse(input.ToString().Trim(), out result);
            if (!success)
                return null;
            if (digits == null)
                return result;
            return Math.Round(result, digits.Value, MidpointRounding.AwayFromZero);
        }

        #endregion 05.字符串转换为Double型

        #region 06.将value的值转换成另外一种类型

        /// <summary>
        /// 将value的值转换成另外一种类型
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <returns>转换后的值</returns>
        public static object ToChangeType(this object value, Type type)
        {
            if (value == null && type.IsGenericType) return Activator.CreateInstance(type);
            if (value == null) return null;
            if (type == value.GetType()) return value;
            if (type.IsEnum)
            {
                if (value is string)
                    return Enum.Parse(type, value as string);
                else
                    return Enum.ToObject(type, value);
            }
            if (!type.IsInterface && type.IsGenericType)
            {
                if (value == null) return null;
                if (string.IsNullOrEmpty(value as string)) return null;
                System.ComponentModel.NullableConverter nullableConverter
                    = new System.ComponentModel.NullableConverter(type);

                type = nullableConverter.UnderlyingType;
                return value.ToChangeType(type);
            }
            try
            {
                if (value is string && type == typeof(Guid))
                {
                    if (string.IsNullOrEmpty(value as string)) return Guid.Empty;
                    return new Guid(value as string);
                }
                if (value is string && type == typeof(DateTime))
                {
                    if (string.IsNullOrEmpty(value as string)) return null;
                    DateTime dt;
                    if (DateTime.TryParse(value as string, out dt))
                    {
                        return dt;
                    }
                    throw new Exception("Can not convert " + value.ToString() + " to datetime format!"); ;
                }
                if (value is string && type == typeof(Version)) return new Version(value as string);

                if (!(value is IConvertible)) return value;
                return Convert.ChangeType(value, type);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 类型转换
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="obj">待转换的数据</param>
        /// <param name="defaultValue">转换默认值</param>
        /// <returns>转换后的数据</returns>
        public static T ToConvert<T>(this object obj, T defaultValue)
        {
            object getValue = defaultValue;
            Type t = typeof(T);
            if (obj != null)
            {
                getValue = obj;
                if (t == typeof(string) || t == typeof(char))
                {
                    if (getValue.ToString() == string.Empty)
                    {
                        getValue = defaultValue;
                    }
                }
                if (t == typeof(bool))
                {
                    bool temp;
                    if (bool.TryParse(getValue.ToString(), out temp))
                    {
                        getValue = temp;
                    }
                    else
                    {
                        getValue = defaultValue;
                    }
                }
                if (t == typeof(DateTime))
                {
                    DateTime temp;
                    if (DateTime.TryParse(getValue.ToString(), out temp))
                    {
                        getValue = temp;
                    }
                    else
                    {
                        getValue = defaultValue;
                    }
                }
                //  小数(可为负数)
                if (t == typeof(double) || t == typeof(decimal) || t == typeof(float))
                {
                    double temp;
                    if (double.TryParse(getValue.ToString(), out temp))
                    {
                        getValue = temp;
                    }
                    else
                    {
                        getValue = defaultValue;
                    }
                }
                //  无符号整数(不可为负数)
                if (t == typeof(ulong) || t == typeof(uint) || t == typeof(ushort) || t == typeof(byte))
                {
                    ulong temp;
                    if (ulong.TryParse(getValue.ToString(), out temp))
                    {
                        getValue = temp;
                    }
                    else
                    {
                        getValue = defaultValue;
                    }
                }
                //  有符号整数(可为负数)
                if (t == typeof(long) || t == typeof(int) || t == typeof(short) || t == typeof(sbyte))
                {
                    long temp;
                    if (long.TryParse(getValue.ToString(), out temp))
                    {
                        getValue = temp;
                    }
                    else
                    {
                        getValue = defaultValue;
                    }
                }
            }
            return (T)Convert.ChangeType(getValue, t);
        }

        #endregion 06.将value的值转换成另外一种类型

        #region 07.数据精度

        /// <summary>
        /// 根据指定精度截断数值
        /// </summary>
        /// <param name="value">需要截断的值</param>
        /// <param name="decimals">小数点后位数。若2.15，则位数为2。位数的范围为0-9</param>
        /// <returns>截断后的数值</returns>
        /// <remarks>
        /// 只舍去，不进位
        /// 如Truncate( 2.135,2) 应返回 2.13
        /// </remarks>
        public static decimal TruncateByPrecision(this decimal value, int decimals)
        {
            if (value == decimal.MaxValue)
            {
                return value;
            }

            if (decimals < 0)
            {
                throw new ArgumentException("精确度不能为负值。");
            }
            if (decimals > 9)
            {
                throw new ArgumentException("不支持超过9位的精确度。");
            }
            int item = (int)Math.Pow(10, decimals);
            return decimal.Truncate(value * item) / item;
        }

        #endregion 07.数据精度

        #region 08.字符串转换为DateTime型

        public static DateTime? ToDateTime(this string str)
        {
            if (string.IsNullOrEmpty(str)) return null;
            DateTime d;
            if (DateTime.TryParse(str, out d))
                return d;
            return null;
        }

        #endregion 08.字符串转换为DateTime型
    }
}