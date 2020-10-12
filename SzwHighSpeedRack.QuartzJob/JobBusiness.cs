using Quartz;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace SzwHighSpeedRack.QuartzJob
{
    public abstract class JobBusiness : IJob
    {
        private static Type jobDoWorkType;
        private static object jobDoWorkObj;

        public virtual void TaskRunBusiness(JobManager job)
        {
            //由于是分布类，如果用typeof()获取类型,方法会调用不到
            jobDoWorkType = Type.GetType("SzwHighSpeedRack.QuartzJob.JobDoWork");
            //动态创建对象
            jobDoWorkObj = Activator.CreateInstance(jobDoWorkType);
            MethodInfo mi = jobDoWorkType.GetMethod(job.TriggerName);
            if (mi == null)
            {
                Console.WriteLine("不存在:" + job.TriggerName + "触发器,来调度任务");
                return;
            }
            //通过反射动态调用方法
            mi.Invoke(jobDoWorkObj, new object[] { job });
        }

        public Task Execute(IJobExecutionContext context)
        {
            ExecuteJobBusiness(context);
            return Task.CompletedTask;
        }

        public abstract void ExecuteJobBusiness(IJobExecutionContext jobContext);
    }
}