using System;
using System.Collections.Generic;
using System.Text;

namespace WebLibrary
{
    public static class StringExtension
    {
        /// <summary>
        /// string轉Int32
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int ToInt32(this string input)
        {
            return int.Parse(input);
        }
    }
}
