// <copyright file="LogModule.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SzwHighSpeedRack.Utility
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using log4net;
    using log4net.Config;
    using log4net.Repository;

    /// <summary>
    /// 日志.
    /// </summary>
    public class LogModule
    {
        private static log4net.ILog logger = null;
        private static ILoggerRepository logRepository;
        private static object objlock = new object();

        /// <summary>
        /// 日志方法.
        /// </summary>
        /// <param name="logstr">logstr</param>
        /// <param name="logger">ERROR</param>
        public static void LogError(string logstr, string logger = "ERROR")
        {
            if (InitLog4net())
            {
                LogModule.logger = LogManager.GetLogger(logRepository.Name, logger);
                LogModule.logger.Error(logstr);
            }
        }

        /// <summary>
        /// 日志方法.
        /// </summary>
        /// <param name="logstr">logstr.</param>
        /// <param name="ex">ex.</param>
        /// <param name="logger">ERROR.</param>
        public static void LogError(string logstr, Exception ex, string logger = "ERROR")
        {
            if (InitLog4net())
            {
                LogModule.logger = LogManager.GetLogger(logRepository.Name, logger);
                LogModule.logger.Error(logstr, ex);
            }
        }

        /// <summary>
        /// 日志方法.
        /// </summary>
        /// <param name="logstr">logstr</param>
        /// <param name="logger">INFO</param>
        public static void LogInfo(string logstr, string logger = "INFO")
        {
            if (InitLog4net())
            {
                LogModule.logger = LogManager.GetLogger(logRepository.Name, logger);
                LogModule.logger.Info(logstr);
            }
        }

        /// <summary>
        /// 日志方法.
        /// </summary>
        /// <param name="logstr">logstr.</param>
        /// <param name="ex">ex.</param>
        /// <param name="logger">INFO.</param>
        public static void LogInfo(string logstr, Exception ex, string logger = "INFO")
        {
            if (InitLog4net())
            {
                LogModule.logger = LogManager.GetLogger(logRepository.Name, logger);
                LogModule.logger.Info(logstr, ex);
            }
        }

        /// <summary>
        /// 日志方法.
        /// </summary>
        /// <param name="logstr">logstr.</param>
        /// <param name="logger">WARN.</param>
        public static void LogWarm(string logstr, string logger = "WARN")
        {
            if (InitLog4net())
            {
                LogModule.logger = LogManager.GetLogger(logRepository.Name, logger);
                LogModule.logger.Warn(logstr);
            }
        }

        /// <summary>
        /// 日志方法.
        /// </summary>
        /// <param name="logstr">logstr.</param>
        /// <param name="ex">ex.</param>
        /// <param name="logger">WARN.</param>
        public static void LogWarm(string logstr, Exception ex, string logger = "WARN")
        {
            if (InitLog4net())
            {
                LogModule.logger = LogManager.GetLogger(logRepository.Name, logger);
                LogModule.logger.Warn(logstr, ex);
            }
        }

        /// <summary>
        /// 日志方法.
        /// </summary>
        /// <param name="logstr">logstr.</param>
        /// <param name="logger">DEBUG.</param>
        public static void LogDebug(string logstr, string logger = "DEBUG")
        {
            Console.WriteLine(logstr);
            if (InitLog4net())
            {
                LogModule.logger = LogManager.GetLogger(logRepository.Name, logger);
                LogModule.logger.Debug(logstr);
            }
        }

        /// <summary>
        /// 日志方法.
        /// </summary>
        /// <param name="logstr">logstr.</param>
        /// <param name="ex">ex.</param>
        /// <param name="logger">DEBUG.</param>
        public static void LogDebug(string logstr, Exception ex, string logger = "DEBUG")
        {
            Console.WriteLine(ex.Message);
            if (InitLog4net())
            {
                LogModule.logger = LogManager.GetLogger(logRepository.Name, logger);
                LogModule.logger.Debug(logstr, ex);
            }
        }

        /// <summary>
        /// 单列,初始化配置.
        /// </summary>
        /// <returns>bool</returns>
        private static bool InitLog4net()
        {
            if (logger != null)
            {
                return true;
            }

            lock (objlock)
            {
                if (logRepository == null)
                {
                    logRepository = LogManager.CreateRepository("LogRepository");
                    XmlConfigurator.Configure(logRepository, new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log.config"));
                    return true;
                }
            }

            return false;
        }
    }
}
