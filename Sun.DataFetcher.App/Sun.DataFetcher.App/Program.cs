using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemGeneric.Logger;
using SystemGeneric.Loggers;

namespace Sun.DataFetcher.App
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LogSetup();
            Application.Run(new MainForms());
        }

        public static void LogSetup()
        {
            LoggerProperty.FilePattern = @"Log\Log-{0}.log";
            LoggerProperty.MaximumLogFiles = 7;
            LoggerProperty.MaximumLogFileSize = 1234567; //bytes
            LoggerProperty.ApplicationName = "Sun.DataFetcher.App";
            LoggerProperty.LogLevel = 0; //0-Verbose,1-Debug,2-Information,3-Warning,4-Error,5-Fatal
            Logger.Setup(AppenderType.Text);

        }
    }
}
