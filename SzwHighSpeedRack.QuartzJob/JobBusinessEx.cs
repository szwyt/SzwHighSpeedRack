using Quartz;
using System;
using System.Linq;

namespace SzwHighSpeedRack.QuartzJob
{
    /// <summary>
    /// 有状态的任务执行
    /// </summary>
    [PersistJobDataAfterExecution]
    [DisallowConcurrentExecution]
    public class JobBusinessEx : JobBusiness
    {
        public override void ExecuteJobBusiness(IJobExecutionContext jobContext)
        {
            var dbJobManagerList = QuartzJobEx.dbJobManagerList.Where(w => w.JobKey == jobContext.Trigger.JobKey.Name.ToString()).ToList();
            try
            {
                dbJobManagerList.ForEach(o =>
                {
                    //执行Job任务
                    TaskRunBusiness(o);
                });
            }
            catch (Exception ex)
            {
                LogModule.LogError(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "->" + ex.Message + "");
                throw new Exception(ex.Message);
            }
        }
    }
}