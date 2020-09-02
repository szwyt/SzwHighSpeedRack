using System;
using System.Collections.Generic;
using System.Text;

namespace SzwHighSpeedRack.Aop
{
    /// <summary>
    /// 是否需要开启事务的特性
    /// 作者：史梓威 
    /// 创建时间：2019-05-08
    /// </summary>
    [AttributeUsage(AttributeTargets.Property |
        AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class TransactionAttribute : Attribute
    {
        public TransactionAttribute()
        {
        }

        public bool Enabled { get; set; }
    }
}
