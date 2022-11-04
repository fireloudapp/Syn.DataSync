using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemGeneric.Logger;
using SystemGeneric.Loggers;

namespace Sun.WebAPI.Receiver
{
    public class Program
    {
        public static void Main(string[] args)
        {
            LogSetup();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        //Hosted in https://localhost:8083/swagger/index.html

        public static void LogSetup()
        {
            LoggerProperty.FilePattern = @"Log\Log-{0}.log";
            LoggerProperty.MaximumLogFiles = 7;
            LoggerProperty.MaximumLogFileSize = 1234567; //bytes
            LoggerProperty.ApplicationName = "Sun.WebAPI.Receiver";
            LoggerProperty.LogLevel = 0; //0-Verbose,1-Debug,2-Information,3-Warning,4-Error,5-Fatal
            Logger.Setup(AppenderType.Text);
        }
    }
}
