using System;

namespace SzwHighSpeedRack
{
    /// <summary>
    /// 时间工具类
    /// </summary>
    public class TimeUtils
    {
        public static DateTime GetUnixStartTime()
        {
            return TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1, 8, 0, 0), TimeZoneInfo.Local); // 当地时区
        }

        public static long GetCurrentUnixTime()
        {
            System.DateTime startTime = GetUnixStartTime();
            long timeStamp = (long)(DateTime.Now - startTime).TotalSeconds;

            return timeStamp;
        }

        public static int GetUnixTimeFromDateTime(DateTime date)
        {
            System.DateTime startTime = GetUnixStartTime();
            int timeStamp = (int)(date - startTime).TotalSeconds;

            return timeStamp;
        }

        public static DateTime GetDateTimeFromUnixTime(int timestamp)
        {
            System.DateTime startTime = GetUnixStartTime();
            DateTime date = startTime.AddSeconds(timestamp);

            return date;
        }

        // 按分获取时间
        public static long GetDateTimeMinuteTimesan(DateTime dateTime)
        {
            var start = new DateTime(1970, 1, 1, 0, 0, 0);
            TimeSpan ts = dateTime.ToUniversalTime() - start;
            return System.Convert.ToInt32(ts.TotalMinutes);
        }
    }
}