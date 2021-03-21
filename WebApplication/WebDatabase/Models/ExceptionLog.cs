using System;
using System.Collections.Generic;
using System.Text;

namespace WebDatabase.Models
{
    public class ExceptionLog
    {
        /// <summary>
        /// 操作序號
        /// </summary>
        public Guid SEQ { get; set; } = Guid.Empty;
        /// <summary>
        /// SQL 語法
        /// </summary>
        public string COMMAND { get; set; } = string.Empty;
        /// <summary>
        /// 錯誤訊息
        /// </summary>
        public string MSG { get; set; } = string.Empty;
        /// <summary>
        /// 來源
        /// </summary>
        public string SOURCE { get; set; } = string.Empty;
        /// <summary>
        /// Stored Procedure 資訊
        /// </summary>
        public string INFO { get; set; } = string.Empty;
        /// <summary>
        /// 日期時間
        /// </summary>
        public DateTime DATE { get; set; }
    }
}
