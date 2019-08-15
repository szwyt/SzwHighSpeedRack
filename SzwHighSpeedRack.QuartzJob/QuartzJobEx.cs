using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using SzwHighSpeedRack;

namespace SzwHighSpeedRack.QuartzJob
{
    public class QuartzJobEx
    {
        private static IScheduler scheduler;
        public static List<JobManager> dbJobManagerList { get; set; }
        public static string xmlPath = Directory.GetCurrentDirectory() + "\\JobConfig.xml";
        public static async void Start()
        {
            //初始化数据
            using (XmlReader xr = XmlReader.Create(xmlPath))
            {
                XmlSerializer xs = new XmlSerializer(typeof(JobManagerList));
                var jobConfig = xs.Deserialize(xr) as JobManagerList;
                dbJobManagerList = jobConfig.JobManagers;
                scheduler = await StdSchedulerFactory.GetDefaultScheduler();
                LogModule.LogWarm(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "->scheduler开始启动...");
                await scheduler.Start();
                LogModule.LogWarm(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "->scheduler启动完成...");
                bool startState = false;
                do
                {
                    try
                    {
                        SchedulerBusiness(scheduler);
                        startState = true;
                    }
                    catch
                    {

                    }
                } while (startState == false);
            }
        }
        public static void Stop()
        {
            LogModule.LogWarm(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "->scheduler开始关闭");
            if (scheduler != null)
                scheduler.Shutdown(false);
            LogModule.LogWarm(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "->scheduler关闭完成");
        }

        public static async void SchedulerBusiness(IScheduler IScheduler)
        {
            try
            {
                if (dbJobManagerList == null || dbJobManagerList.Count() == 0)
                {
                    LogModule.LogError(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "->未找到JobManager的配置数据...");
                    throw new Exception("未找到JobManager的配置数据...");
                }
                Dictionary<IJobDetail, IReadOnlyCollection<ITrigger>> keyValuePairs = new Dictionary<IJobDetail, IReadOnlyCollection<ITrigger>>();
                //任务列表塞入调度器
                dbJobManagerList.ForEach(o =>
                {
                    var jobDetail = JobBuilder.Create<JobBusinessEx>().WithIdentity(o.JobKey, o.Group)
                                                           .UsingJobData(o.JobKey, o.JobValue)
                                                           .Build();
                    var trigger = TriggerBuilder.Create().WithIdentity(o.TriggerName, o.Group)
                                                     .StartNow()
                                                     .WithCronSchedule(o.CronExpression)
                                                     .Build();
                    List<ITrigger> triggerSource = new List<ITrigger>();
                    triggerSource.Add(trigger);
                    ReadOnlyCollection<ITrigger> triggers = new ReadOnlyCollection<ITrigger>(triggerSource);
                    keyValuePairs.Add(jobDetail, triggers);
                });
                LogModule.LogWarm(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "->scheduler开始加载JobTasks");
                ReadOnlyDictionary<IJobDetail, IReadOnlyCollection<ITrigger>> triggersAndJobs = new ReadOnlyDictionary<IJobDetail, IReadOnlyCollection<ITrigger>>(keyValuePairs);
                await IScheduler.ScheduleJobs(triggersAndJobs, false);
                LogModule.LogWarm(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "->scheduler加载JobTasks完成");

            }
            catch (Exception ex)
            {
                LogModule.LogError(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "->" + ex.Message + "");
                throw new Exception(ex.Message);
            }
        }
    }
}
