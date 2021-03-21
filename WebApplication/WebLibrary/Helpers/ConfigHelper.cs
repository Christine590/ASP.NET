using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WebLibrary.Models;

namespace WebLibrary.Helpers
{
    public static class ConfigHelper
    {
        public static WebConfiguration AllConfig { get; } = GetAllConfig();
        private static WebConfiguration GetAllConfig()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");

            IConfiguration _config = configurationBuilder.AddJsonFile(path, false).Build();
            return _config.GetSection("WebConfiguration").Get<WebConfiguration>();
        }
    }
}
