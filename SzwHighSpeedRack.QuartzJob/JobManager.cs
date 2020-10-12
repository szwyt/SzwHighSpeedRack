using System.Collections.Generic;
using System.Xml.Serialization;

namespace SzwHighSpeedRack.QuartzJob
{
    [XmlRoot("JobConfig")]
    public class JobManagerList
    {
        [XmlArray("JobManagers"), XmlArrayItem("JobManager")]
        public List<JobManager> JobManagers { get; set; } = new List<JobManager>();
    }

    [XmlRoot("JobManager")]
    public class JobManager
    {
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string JobName { get; set; }

        public string JobKey { get; set; }
        public string JobValue { get; set; }

        /// <summary>
        /// 触发器名字
        /// </summary>
        public string TriggerName { get; set; }

        /// <summary>
        /// Cron表达式
        /// </summary>
        public string CronExpression { get; set; }

        public int ExecuteStatus { get; set; }

        /// <summary>
        /// 分组
        /// </summary>
        public string Group { get; set; }
    }
}