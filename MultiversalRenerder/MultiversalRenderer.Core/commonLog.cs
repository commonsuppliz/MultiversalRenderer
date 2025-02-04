using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;

namespace MultiversalRenderer.Core
{
	using System;
	using System.IO;
	using NLog;
#if DEBUG
	using System.Diagnostics;
#endif


		/// <summary>
		/// commonLog 
		/// </summary>
#pragma warning disable IDE1006 // 命名スタイル
		public static class commonLog
#pragma warning restore IDE1006 // 命名スタイル
		{
			private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

		    public static bool LoggingEnabled
		{
			get { return NLog.LogManager.IsLoggingEnabled(); }
			set
			{
				if (value == true) { StartLogging(); } else { StopLogging(); } ;


			}
		}
		private static int _commonnlogLevel = 0;

        public static int CommonLogLevel
		{
			get
			{
                return _commonnlogLevel;

            }
			set
            {
                _commonnlogLevel = value;
                switch (value)
                {
                    case 0:
                        Logger.Info("Log Level set to Info");
                        break;
                    case 1:
                        Logger.Info("Log Level set to Debug");
                        break;
                    case 2:
                        Logger.Info("Log Level set to Trace");
                        break;
                    case 3:
                        Logger.Info("Log Level set to Warn");
                        break;
                    case 4:
                        Logger.Info("Log Level set to Error");
                        break;
                    case 5:
                        Logger.Info("Log Level set to Fatal");
                        break;
                    default:
                        Logger.Info("Log Level set to Info");
                        break;
                }
            }	
        }

			public static void LogEntry(string str, params object[] args)
			{
				Logger.Info(string.Format(str, args));
			}
			public static void LogEntry(string str)
			{
				Logger.Info(str);
			}
			public static void LogEntry(System.Exception ex)
			{
				Logger.Error(ex);
			}
			public static void LogEntry(string strName, Exception ex)
			{
				Logger.Error(ex, strName);
			}
        public static void StartLogging()
        {
            var config = new NLog.Config.LoggingConfiguration();

            // Targets where to log to: File and Console
            //var logfile = new NLog.Targets.FileTarget("logfile") { FileName = "file.txt" };
            var logconsole = new NLog.Targets.ConsoleTarget("logconsole");

            // Rules for mapping loggers to targets
            config.AddRule(LogLevel.Debug, LogLevel.Debug, logconsole);
            //config.AddRule(CommonLogLevel.Debug, CommonLogLevel.Fatal, logfile);

            // Apply config
            NLog.LogManager.Configuration = config;
        }

        // Method to shut down logging configuration
        public static void StopLogging()
        {
            NLog.LogManager.Shutdown();
        }
  
    }
	}


