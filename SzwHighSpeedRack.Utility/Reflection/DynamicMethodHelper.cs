// <copyright file="DynamicMethodHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SzwHighSpeedRack.Utility
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Text;

    /// <summary>
    /// 动态方法助手
    /// 作者：史梓威
    /// 创建时间：2019-05-08
    public class DynamicMethodHelper
    {
        private Func<object, object[], object> m_execute;

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicMethodHelper"/> class.
        /// 构造函数.
        /// </summary>
        /// <param name="methodInfo">方法</param>
        public DynamicMethodHelper(MethodInfo methodInfo)
        {
            this.m_execute = this.GetExecuteDelegate(methodInfo);
        }

        /// <summary>
        /// 执行方法.
        /// </summary>
        /// <param name="instance">对象.</param>
        /// <param name="parameters">参数.</param>
        /// <returns>object.</returns>
        public object Execute(object instance, object[] parameters)
        {
            return this.m_execute(instance, parameters);
        }

        /// <summary>
        /// 反射执行方法为委托.
        /// </summary>
        /// <param name="methodInfo">methodInfo.</param>
        /// <returns>unc<object, object[], object>.</returns>
        private Func<object, object[], object> GetExecuteDelegate(MethodInfo methodInfo)
        {
            // parameters to execute
            ParameterExpression instanceParameter =
                Expression.Parameter(typeof(object), "instance");
            ParameterExpression parametersParameter =
                Expression.Parameter(typeof(object[]), "parameters");

            // build parameter list
            List<Expression> parameterExpressions = new List<Expression>();
            ParameterInfo[] paramInfos = methodInfo.GetParameters();
            for (int i = 0; i < paramInfos.Length; i++)
            {
                // (Ti)parameters[i]
                BinaryExpression valueObj = Expression.ArrayIndex(
                    parametersParameter, Expression.Constant(i));
                UnaryExpression valueCast = Expression.Convert(
                    valueObj, paramInfos[i].ParameterType);

                parameterExpressions.Add(valueCast);
            }

            // non-instance for static method, or ((TInstance)instance)
            Expression instanceCast = methodInfo.IsStatic ? null :
                Expression.Convert(instanceParameter, methodInfo.ReflectedType);

            // static invoke or ((TInstance)instance).Method
            MethodCallExpression methodCall = Expression.Call(
                instanceCast, methodInfo, parameterExpressions);

            // ((TInstance)instance).Method((T0)parameters[0], (T1)parameters[1], ...)
            if (methodCall.Type == typeof(void))
            {
                Expression<Action<object, object[]>> lambda =
                    Expression.Lambda<Action<object, object[]>>(
                        methodCall, instanceParameter, parametersParameter);

                Action<object, object[]> execute = lambda.Compile();
                return (instance, parameters) =>
                {
                    execute(instance, parameters);
                    return null;
                };
            }
            else
            {
                UnaryExpression castMethodCall = Expression.Convert(
                    methodCall, typeof(object));
                Expression<Func<object, object[], object>> lambda =
                    Expression.Lambda<Func<object, object[], object>>(
                        castMethodCall, instanceParameter, parametersParameter);

                return lambda.Compile();
            }
        }
    }
}
