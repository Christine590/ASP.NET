using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDatabase.Models;

namespace WebApplication.Extensions
{
    public static class ExceptionExtension
    {
        public static ExceptionLog ToExceptionLog(this Exception ex) => new ExceptionLog
        {
            SEQ = Guid.NewGuid(),
            MSG = ex.ToString(),
            SOURCE = ex.TargetSite?.Name ?? string.Empty, // ? 用於給後方的變數初始值null
            INFO = ex.TargetSite?.DeclaringType?.FullName ?? string.Empty, // ?? 用於判斷前方變數，若為null就賦予??後的新值，否則跳過
            DATE = DateTime.Now,
        };
    }
}
