using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace WebLibrary.Extensions
{
    public static class DateTimeExtension
    {
        /// <summary>
        /// 取得當日最後一刻
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime ToDateLast(this DateTime value)
        {
            return value.Date.AddDays(1).AddMilliseconds(-1);
        }

        public static string ToStringOrEmpty(this DateTime? value, string formate = null, IFormatProvider provider = null)
        {
            return value.HasValue ?
                (formate is string ? value.Value.ToString(formate, provider ?? CultureInfo.InvariantCulture) : value.Value.ToString(provider ?? CultureInfo.InvariantCulture))
                : string.Empty;
        }
    }
}
