using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace SSO.Api.ExtensionMethods
{
    public static class DateTimeExtensions
    {
        public static long ToUnixTimestamp(this DateTime d)
        {
            var epoch = d - new DateTime(1970, 1, 1, 0, 0, 0);

            return (long)epoch.TotalSeconds;
        }
        /// <summary>
        /// ????? ????? ?????? ?? ????
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string GetShamsiDate(DateTime dt)
        {
            try
            {
                string year = "", month = "", day = "";
                PersianCalendar persianCalendar = new PersianCalendar();
                year = persianCalendar.GetYear(dt).ToString();
                month = persianCalendar.GetMonth(dt).ToString();
                if (month.Length == 1)
                    month = "0" + month;
                day = persianCalendar.GetDayOfMonth(dt).ToString();
                if (day.Length == 1)
                    day = "0" + day;
                return (year + "/" + month + "/" + day).ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        /// <summary>
        /// ????? ????? ???? ?? ??????
        /// </summary>
        /// <param name="ShamsiDate"></param>
        /// <returns></returns>
        public static DateTime? GregorianDate(decimal? ShamsiDate)
        {
            try
            {
                PersianCalendar x = new  PersianCalendar();
                return x.ToDateTime(Convert.ToInt32(ShamsiDate.Value.ToString().Substring(0, 4)), Convert.ToInt32(ShamsiDate.Value.ToString().Substring(4, 2)), Convert.ToInt32(ShamsiDate.Value.ToString().Substring(6, 2)), 0, 0, 0, 0, 0);
            }
            catch
            {
                throw new Exception("Error");
            }
        }

        public static bool IsDigit(this string val)
        {
            try
            {
                return Regex.IsMatch(val, @"\d");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
