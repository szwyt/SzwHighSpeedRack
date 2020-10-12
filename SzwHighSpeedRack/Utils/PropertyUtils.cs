using System.Reflection;

namespace SzwHighSpeedRack
{
    /// <summary>
    /// 作者：史梓W威
    /// 创建时间：2019-05-08
    /// </summary>
    public static class PropertyUtils
    {
        /// <summary>
        /// 获取对象的属性值
        /// </summary>
        /// <param name="obj">待获取值的对象</param>
        /// <param name="propertyName">属性名称</param>
        /// <returns>属性的值</returns>
        public static object GetValue(this object obj, string propertyName)
        {
            PropertyInfo pi = obj.GetType().GetProperty(propertyName);
            if (pi != null)
            {
                return PropertyHelper.FastGetValue(pi, obj);
            }
            return null;
        }

        /// <summary>
        /// 获取对象的属性值
        /// </summary>
        /// <param name="obj">待获取值的对象</param>
        /// <param name="pi">属性</param>
        /// <returns>属性的值</returns>
        public static object GetValue(this object obj, PropertyInfo pi)
        {
            return PropertyHelper.FastGetValue(pi, obj);
        }
    }
}