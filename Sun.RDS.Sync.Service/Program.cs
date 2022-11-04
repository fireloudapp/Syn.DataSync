
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sun.RDS.Sync.Service.Rabbit;
using Sun.RDS.Sync.Service.WinService;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SystemGeneric.Logger;
using SystemGeneric.Loggers;

namespace Sun.RDS.Sync.Service
{
    class Program
    {
        private static async Task Main(string[] args)
        {
            try
            {
                LogSetup();
                Logger.Log.Information("RabbitMQ Listener LogSetup Initiated.");
                var isService = !(Debugger.IsAttached || args.Contains("--console"));

                var builder = new HostBuilder()
                    .ConfigureServices((hostContext, services) =>
                    {
                        services.AddHostedService<ReceiveService>();
                    });

                if (isService)
                {
                    Logger.Log.Information("Sync RabbitMQ Listener Service Initiated.");
                    await builder.RunAsServiceAsync();
                    Logger.Log.Information("Sync RabbitMQ Listener Service Started.");
                }
                else
                {
                    Logger.Log.Information("Sync RabbitMQ Listener Console Initiated.");
                    await builder.RunConsoleAsync();
                    Logger.Log.Information("Sync RabbitMQ Listener Console Started.");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Demystify());
            }
        }


        public static void LogSetup()
        {
            LoggerProperty.FilePattern = AppDomain.CurrentDomain.BaseDirectory + @"Log\Log-{0}.log";
            LoggerProperty.MaximumLogFiles = 7;
            LoggerProperty.MaximumLogFileSize = 1234567; //bytes
            LoggerProperty.ApplicationName = "Sun.RDS.Sync.Service";
            LoggerProperty.LogLevel = 0; //0-Verbose,1-Debug,2-Information,3-Warning,4-Error,5-Fatal
            Logger.Setup(AppenderType.Text);
        }

    }
}
