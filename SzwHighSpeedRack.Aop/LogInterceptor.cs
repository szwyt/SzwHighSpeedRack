using Castle.DynamicProxy;
using System;
using System.Linq;

namespace SzwHighSpeedRack.Aop
{
    public class LogInterceptor : IInterceptor
    {
        /// <summary>
        /// 实例化IInterceptor唯一方法
        /// </summary>
        /// <param name="invocation">包含被拦截方法的信息</param>
        public void Intercept(IInvocation invocation)
        {
            //记录被拦截方法信息的日志信息
            var dataIntercept = $"当前执行方法命名空间：{ invocation.TargetType.Namespace} " +
                $"当前执行方法类名：{ invocation.TargetType.FullName} " +
                $"当前执行方法名：{ invocation.Method.Name} " +
                $"参数是： {string.Join(", ", invocation.Arguments.Select(a => (a ?? string.Empty).ToString()).ToArray())} \r\n";

            try
            {
                //在被拦截的方法执行完毕后 继续执行当前方法，注意是被拦截的是异步的
                invocation.Proceed();
                dataIntercept += ($"方法执行完毕，返回结果：{invocation.ReturnValue.ToJson()}");
                LogModule.LogInfo(dataIntercept);
            }
            catch (Exception ex)
            {
                LogModule.LogError(dataIntercept, ex);
                throw new Exception(ex.Message);
            }
        }
    }
}