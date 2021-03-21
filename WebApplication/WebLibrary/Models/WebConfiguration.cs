using System;
using System.Collections.Generic;
using System.Text;

namespace WebLibrary.Models
{
    public class WebConfiguration
    {
        public JwtSettings JwtSettings { get; set; }
    }

    public class JwtSettings
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SignKey { get; set; }
    }
}
