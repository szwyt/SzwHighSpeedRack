using System;

namespace SzwHighSpeedRack
{
    /// <summary>
    /// EnumType 枚举类型
    /// 作者：史梓威
    /// 创建时间：2019-05-05
    /// </summary>
    public class EnumTypeAttribute : Attribute, IAttribute<Type>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="approvalStepType"></param>
        public EnumTypeAttribute(Type value)
        {
            Value = value;
        }

        private Type _Value;

        /// <summary>
        /// 枚举类型
        /// </summary>
        public Type Value
        {
            get { return _Value; }
            set { _Value = value; }
        }
    }
}