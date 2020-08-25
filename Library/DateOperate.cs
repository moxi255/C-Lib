using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Library
{
    /// <summary>
    /// 日期操作
    /// </summary>
    class DateOperate
    {
        /// <summary>
        /// 日期转换为时间戳（时间戳单位毫秒）
        /// </summary>
        /// <param name="TimeStamp"></param>
        /// <returns></returns>         
        public static long ConvertToTimeStamp(DateTime time)
        {
            DateTime Jan1st1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return (long)(time.AddHours(-8) - Jan1st1970).TotalMilliseconds;
        }
        /// <summary>
        /// 时间戳转换为日期（时间戳单位毫秒）
        /// </summary>
        /// <param name="TimeStamp"></param>
        /// <returns></returns>
        public static DateTime ConvertToDateTime(long timeStamp)
        {
            var start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return start.AddMilliseconds(timeStamp).AddHours(8);
        }
        /// <summary>
        /// 取得某年的第一天
        /// </summary>
        /// <returns></returns>
        public static DateTime FirstDayOfYear()
        {
            DateTime temp = new DateTime(DateTime.Now.Year, 1, 1);
            return temp;
        }
        /// <summary>
        /// 获取今年的最后一天
        /// </summary>
        /// <returns></returns>
        public static DateTime LastDayOfYear()
        {
            DateTime temp = new DateTime(DateTime.Now.Year, 12, 1).AddMonths(1).AddDays(-1);
            return temp;
        }
        /// <summary>
        /// 取得某月的第一天
        /// </summary>
        /// <param name="datetime">要取得月份第一天的时间</param>
        /// <returns></returns>
        public static DateTime FirstDayOfMonth(DateTime datetime)
        {
            DateTime temp = datetime.AddDays(1 - datetime.Day);
            return temp;
        }

        /// <summary>
        /// 取得某月的最后一天
        /// </summary>
        /// <param name="datetime">要取得月份最后一天的时间</param>
        /// <returns></returns>
        public static DateTime LastDayOfMonth(DateTime datetime)
        {
            return datetime.AddDays(1 - datetime.Day).AddMonths(1).AddDays(-1);
        }

        /// <summary>
        /// 取得上个月第一天
        /// </summary>
        /// <param name="datetime">要取得上个月第一天的当前时间</param>
        /// <returns></returns>
        public static DateTime FirstDayOfPreviousMonth(DateTime datetime)
        {

            return datetime.AddDays(1 - datetime.Day).AddMonths(-1);
        }
        /// <summary>
        /// 得到这一周的起止日期
        /// </summary>
        /// <param name="dtBeginDate"></param>
        /// <param name="dtEndDate"></param>
        public static void GetWeekSpan(out DateTime dtBeginDate, out DateTime dtEndDate)
        {
            DateTime currentTime = DateTime.Today;
            int week = Convert.ToInt32(currentTime.DayOfWeek);
            week = week == 0 ? 7 : week;
            DateTime startWeek = currentTime.AddDays(1 - week);  //本周周一
            DateTime endWeek = currentTime.AddDays(7 - week);  //本周周日
            dtBeginDate = startWeek;
            dtEndDate = endWeek;
        }
        /// <summary>
        /// 取得上个月的最后一天
        /// </summary>
        /// <param name="datetime">要取得上个月最后一天的当前时间</param>
        /// <returns></returns>
        public static DateTime LastDayOfPrdviousMonth(DateTime datetime)
        {
            return datetime.AddDays(1 - datetime.Day).AddDays(-1);
        }
    }
}
