using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace WebLibrary
{
    public static class StringExtension
    {
        public const string DefaultDateTimeFormat = "yyyyMMdd";

        /// <summary>
        /// 日期字串嘗試轉日期物件
        /// </summary>
        /// <param name="input">日期字串</param>
        /// <param name="dt">回傳的DateTime物件</param>
        /// <returns></returns>
        public static bool TryToDateTime(this string input, out DateTime dt)
        {
            return input.TryToDateTime(DefaultDateTimeFormat, out dt);
        }

        /// <summary>
        /// 日期字串嘗試轉日期物件
        /// </summary>
        /// <param name="input">日期字串</param>
        /// <param name="DateTimeFormate">若原日期字串為特定格式(預設為yyyyMMdd)</param>
        /// <param name="dt">回傳的DateTime物件</param>
        /// <returns></returns>
        public static bool TryToDateTime(this string input, string DateTimeFormate, out DateTime dt)
        {
            if (DateTime.TryParseExact(input, DateTimeFormate, CultureInfo.InvariantCulture, DateTimeStyles.None, out var CurrentDt))
            {
                dt = CurrentDt;
                return true; // 回傳 bool 但 out 變數也會一起回傳
            }
            dt = default;
            return false;
        }

        /// <summary>
        /// 字串轉整數
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int ToInt32(this string input)
        {
            return int.Parse(input);
        }
    }
}
