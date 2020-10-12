using System;

namespace SzwHighSpeedRack.QuartzJob
{
    /// <summary>
    /// 业务类
    /// </summary>
    public partial class JobDoWork
    {
        public JobDoWork()
        {
        }

        public void zuoye(JobManager job)
        {
            try
            {
                Console.WriteLine("JobManager:" + job.TriggerName + "开始执行" + DateTime.Now);

                Console.WriteLine("JobManager:" + job.TriggerName + "执行成功" + DateTime.Now);
            }
            catch (Exception ex)
            {
                Console.WriteLine(job.TriggerName + "------------>" + ex.Message);
            }
        }

        public void zuoye1(JobManager job)
        {
            try
            {
                Console.WriteLine("JobManager:" + job.TriggerName + "开始执行" + DateTime.Now);

                Console.WriteLine("JobManager:" + job.TriggerName + "执行成功" + DateTime.Now);
            }
            catch (Exception ex)
            {
                Console.WriteLine(job.TriggerName + "------------>" + ex.Message);
            }
        }
    }
}