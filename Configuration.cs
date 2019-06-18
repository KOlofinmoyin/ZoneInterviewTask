using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ZoneInterviewTask_PeterOlofinmoyin
{
    public class Configuration
    {
        public static IConfigurationRoot GetConfigurationRoot()
        {
            var path = Directory.GetCurrentDirectory();
            if (!File.Exists(Path.Combine(path, "appsettings.json")))
            {
                throw new Exception($"Application settings file not found in {path}");
            }
            return new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json", optional: true)
                .Build();
        }
    }
}