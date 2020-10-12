namespace SzwHighSpeedRack
{
    /// <summary>
    /// 枚举特性标签
    /// 作者：史梓威
    /// 创建时间：2019-05-05
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAttribute<T>
    {
        /// <summary>
        /// 值
        /// </summary>
        T Value { get; set; }
    }
}